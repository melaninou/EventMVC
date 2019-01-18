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

        protected override void initializeDatabase(EventProjectDbContext context)
        {
            EventProfileDbTableInitializer.Initialize(context);
        }
    }
}
