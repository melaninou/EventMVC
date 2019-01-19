
using Aids;
using EventProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject.Models
{
    [TestClass]
    public class ErrorViewModelTests :ObjectTests<ErrorViewModel>
    {
        protected override ErrorViewModel getRandomTestObject() => GetRandom.Object<ErrorViewModel>();
        [TestMethod]
        public void RequestIdTest()
        {
            isNullableReadWriteStringProperty(() => obj.RequestId, x => obj.RequestId = x);
            hasAttributes(o => o.RequestId);
        }

        [TestMethod]
        public void ShowRequestIdTest()
        {
            obj.RequestId = null;
            Assert.IsFalse(obj.ShowRequestId);
            obj.RequestId = string.Empty;
            Assert.IsFalse(obj.ShowRequestId);
            obj.RequestId = GetRandom.String();
            Assert.IsTrue(obj.ShowRequestId);
            hasAttributes(o => o.ShowRequestId);
        }
    }
}
