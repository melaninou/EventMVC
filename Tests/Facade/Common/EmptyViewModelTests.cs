using Aids;
using Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Common
{
    [TestClass]
    public class EmptyViewModelTests :ViewModelTests<EmptyViewModel, EmptyViewModel>
    {
        class testClass : EmptyViewModel { }
        protected override EmptyViewModel getRandomTestObject()
        {
            return GetRandom.Object<testClass>();
        }
    }
}
