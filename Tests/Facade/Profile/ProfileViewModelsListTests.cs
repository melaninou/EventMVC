using Aids;
using Domain.Profile;
using Facade.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Profile
{
    [TestClass]
    public class ProfileViewModelsListTests :ObjectTests<ProfileViewModelsList>
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ProfileViewModelsList);
        }
        protected override ProfileViewModelsList getRandomTestObject()
        {
            var l = new ProfileObjectsList(null, null);
            SetRandom.Values(l);
            return new ProfileViewModelsList(l);
        }
    }
}
