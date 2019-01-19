using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        private const string assembly = "Facade";
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
        public void IsCommentTested()
        {
            isAllClassesTested(assembly, Namespace("Comment"));
        }
    }
}
