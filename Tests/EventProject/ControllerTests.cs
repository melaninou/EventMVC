using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Aids;
using Core;
using Data.Common;
using EventProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject
{
    public abstract class ControllerTests<Tcontext, TController,
        TObject, TRecord> : AcceptanceTests<Tcontext>
        where Tcontext : DbContext
        where TRecord : BasicDbRecord, new()
        where TController : Controller, IEventProjectController
    {
        protected IPaginatedRepository<TObject, TRecord> repository { get; set; }
        protected string controller { get; set; }
        protected string actualEditAction { get; set; } = "Edit";
        protected string detailsViewCaption { get; set; }
        protected string editViewCaption { get; set; }
        protected List<string> specificStringsToTestInView { get; set; }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(TController);
            generateRandomDbRecords();
        }

        private void generateRandomDbRecords()
        {
            for (var i = 0; i < GetRandom.UInt8(15, 20); i++)
                createDbRecord();
        }

        protected virtual string createDbRecord() => string.Empty;

        [TestMethod]
        public async Task IndexTest()
        {
            var a = GetUrl.ForControllerAction<TController>(x => x.Index(null, null, null, null));
            await testWhenLoggedOut(a, HttpStatusCode.Redirect);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            await createTest(x => x.Create(), controller, detailsViewCaption);
        }

        protected async Task createTest(Expression<Func<TController, object>> action,
            string controllerName,
            string header, string postAction = "create")
        {
            var a = GetUrl.ForControllerAction(action);
            await testWhenLoggedOut(a, HttpStatusCode.Redirect);
        }
        [TestMethod]
        public async Task DeleteTest()
        {
            var id = createDbRecord();
            await deleteTest(id);
        }
        private async Task deleteTest(string id)
        {
            var a = GetUrl.ForControllerAction<TController>(x => x.Delete(""));
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Redirect);
        }
        [TestMethod]
        public async Task DetailsTest()
        {
            var id = createDbRecord();
            var a = GetUrl.ForControllerAction<TController>(x => x.Details(""));
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Redirect);
        }

        [TestMethod]
        public async Task EditTest()
        {
            await editTest(x => x.Edit(""), () => actualEditAction, () => editViewCaption, () => specificStringsToTestInView);
        }
        protected async Task editTest(Expression<Func<TController, object>> actionMethod, Func<string> actionName,
            Func<string> header, Func<List<string>> stringsToTestInView)
        {
            var id = createDbRecord();
            var a = GetUrl.ForControllerAction(actionMethod);
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Redirect);
        }
    }
}
