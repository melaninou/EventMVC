using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class IsDataTested :AssemblyTests
    {
        private const string assembly = "Data";
        protected override string Namespace(string name)
        {
            return $"{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            isAllClassesTested(assembly, Namespace("Common"));
        }
    }
}
