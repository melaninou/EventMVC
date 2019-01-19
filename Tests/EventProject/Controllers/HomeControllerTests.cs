using System.Threading.Tasks;
using EventProject.Controllers;
using Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject.Controllers
{
    [TestClass]
    public class HomeControllerTests : AcceptanceTests<EventProjectDbContext>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(HomeController);
        }

        [TestMethod]
        public async Task IndexTest()
        {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Index());
            await testControllerAction(a, ""); 
        }

        [TestMethod]
        public async Task AboutTest()
        {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.About());
            await testControllerAction(a, "AboutText");
        }

        [TestMethod]
        public async Task ContactTest()
        {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Contact());
            await testControllerAction(a, "Contact");
        }

        [TestMethod]
        public async Task PrivacyTest()
        {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Privacy());
            await testControllerAction(a, "Privacy");
        }


        [TestMethod]
        public async Task ErrorTest()
        {
            var a = GetUrl.ForControllerAction<HomeController>(x => x.Error());
            await testControllerAction(a, "Error.");
        }

        protected override void initializeDatabase(EventProjectDbContext context)
        {
            EventProfileDbTableInitializer.Initialize(context);
        }
    }
}
