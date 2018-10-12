using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Domain.Common
{
    public abstract class DomainObjectsListTests<TObject,TElement> : ObjectTests<TObject>
    {
        protected TObject createWithNullArgs;

        [TestMethod]
        public void CanCreateWithNullArgumentTest()
        {
            Assert.IsNotNull(createWithNullArgs);
        }

        [TestMethod]
        public void IsPaginatedListTest()
        {
            Assert.IsInstanceOfType(obj, typeof(PaginatedList<TElement>));
        }
    }
}
