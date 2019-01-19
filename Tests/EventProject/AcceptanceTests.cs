using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Aids;
using EventProject;
using Infra;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.TestHost;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject
{
    public abstract class AcceptanceTests<TContext> :BaseTests
    where TContext : DbContext
    {
        protected static Assembly assembly;
        protected static HttpClient client;
        protected static TContext db;
        protected static EventProjectDbContext eventProjectDbContext;
        private bool useAuthentication;
        protected static string path;
        protected static TestServer server;

        protected AcceptanceTests()
        {
            if (client != null) return;
            initializeTestServer();
        }

        protected async Task testWhenLoggedOut(string url, HttpStatusCode c)
        {
            var response = await client.GetAsync(url);
            Assert.AreEqual(c, response.StatusCode);
        }

        protected async Task testWhenLoggedIn(string url, params string[] content)
        {
            useAuthentication = true;
            await testControllerAction(url, content);
            useAuthentication = false;
        }

        protected async Task testControllerAction(string url, params string[] content)
        {
            AuthenticationHandlerTests.IsLoggedIn = useAuthentication;
            var response = await client.GetAsync(url);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                AuthenticationHandlerTests.IsLoggedIn = useAuthentication;
                response = await client.GetAsync(response.Headers.Location.OriginalString);
            }
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            foreach (var c in content) { Assert.IsTrue(stringResponse.Contains(c), c); }
        }
        protected void initializeTestServer()
        {
            assembly = typeof(Startup).GetTypeInfo()
                .Assembly;
            path = getPath();
            server = new TestServer(new WebHostBuilder().UseContentRoot(path)
                .UseStartup<TestStartup>()
                .ConfigureServices(x => configure(x, assembly)));
            initTestDatabase();
            client = server.CreateClient();
        }
        private void initTestDatabase()
        {
            var scope = server.Host.Services.CreateScope();
            var services = scope.ServiceProvider;
            db = services.GetService<TContext>();
            eventProjectDbContext = services.GetService<EventProjectDbContext>();
            initializeDatabase(db);
        }
        protected abstract void initializeDatabase(TContext context);
        private static void configure(IServiceCollection services, Assembly a)
        {
            services.Configure((RazorViewEngineOptions options) => {
                var previous = options.CompilationCallback;
                options.CompilationCallback = context => {
                    previous?.Invoke(context);
                    var assemblies = a.GetReferencedAssemblies()
                        .Select(x => MetadataReference.CreateFromFile(Assembly.Load((AssemblyName)x)
                            .Location))
                        .ToList();
                    addReference(assemblies, "netstandard");
                    addReference(assemblies, "System.Private.Corelib");
                    addReference(assemblies, "Microsoft.AspNetCore.Html.Abstractions");
                    addReference(assemblies, "System.Linq.Expressions");
                    addReference(assemblies, "Microsoft.CSharp");
                    context.Compilation = context.Compilation.AddReferences(assemblies);
                };
            });
        }

        private static void addReference(List<PortableExecutableReference> list,
            string assemblyName)
        {
            list.Add(MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName(assemblyName))
                .Location));
        }
        private static string getPath()
        {
            var n = "EventProject\\" + GetString.Tail(assembly.GetName()
                        .Name);
            var p = PlatformServices.Default.Application.ApplicationBasePath;
            var d = new DirectoryInfo(p);
            while (d != null)
            {
                var f = new FileInfo(Path.Combine(d.FullName, "EventProject.sln"));
                if (f.Exists) return Path.GetFullPath(Path.Combine(d.FullName));
                d = d.Parent;
            }

            throw new Exception($"No solution file in path <{p}>.");
        }
    }
}
