using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain
{
    [TestClass]
    public class IsDomainTested :AssemblyTests
    {

        private const string assembly = "Domain";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            isAllClassesTested(assembly, Namespace("Common"));
        }
        [TestMethod]
        public void IsEventTested()
        {
            isAllClassesTested(assembly, Namespace("Event"));
        }

        [TestMethod]
        public void IsProfileTested()
        {
            isAllClassesTested(assembly, Namespace("Profile"));
        }
        

        [TestMethod]
        public void IsAttendingTested()
        {
            isAllClassesTested(assembly, Namespace("Attending"));
        }
    }
}
