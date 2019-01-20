using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class IsDataTested :AssemblyTests
    {
        private const string assembly = "Data";
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
        public void IsCommentTested()
        {
            isAllClassesTested(assembly, Namespace("Comment"));
        }
    }
}
