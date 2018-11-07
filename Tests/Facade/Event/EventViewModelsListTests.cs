using Aids;
using Domain.Event;
using Facade.Event;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Event
{
    [TestClass]
    public class EventViewModelsListTests :ObjectTests<EventViewModelsList>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(EventViewModelsList);
        }

        protected override EventViewModelsList getRandomTestObject()
        {
            var l = new EventObjectsList(null, null);
            SetRandom.Values(l);
            return new EventViewModelsList(l);
        }
    }
}
