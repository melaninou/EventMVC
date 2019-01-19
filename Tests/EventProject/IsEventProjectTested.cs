using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject
{
    [TestClass]
    public class IsEventProjectTested : AssemblyTests
    {
        private const string assembly = "EventProject";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsControllersTested()
        {
            isAllClassesTested(assembly, Namespace("Controllers"));
        }

        [TestMethod]
        public void IsModelsTested()
        {
            isAllClassesTested(assembly, Namespace("Models"));
        }
    }
}
