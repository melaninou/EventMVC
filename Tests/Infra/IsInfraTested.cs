using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "Infra";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
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
    }
}
