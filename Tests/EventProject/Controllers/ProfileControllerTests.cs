using System.Collections.Generic;
using System.Linq;
using Aids;
using Data;
using Domain.Profile;
using EventProject.Controllers;
using Infra;
using Infra.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.EventProject.Controllers
{
    [TestClass]
    public class ProfileControllerTests :ControllerTests<EventProjectDbContext,
    ProfileController, ProfileObject, ProfileDbRecord>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = new ProfileObjectsRepository(db);
            controller = "profile";
            detailsViewCaption = "Profile";
        }
        //protected override string createDbRecord()
        //{
        //    var r = GetRandom.Object<ProfileDbRecord>();
        //    if (db.Profiles.Contains(r) == false) db.Profiles.Add(r);
        //    db.SaveChanges();
        //    specificStringsToTestInView = new List<string> {
        //        $"{r.ID}",
        //        $"{r.Name}",
        //        $"{r.Location}",
        //        $"{r.Gender}",
        //        $"{r.BirthDay}",
        //        $"{r.Occupation}",
        //        $"{r.AboutText}",
        //        $"{r.ProfileImage}"
        //    };
        //    editViewCaption = $"Profile ({r.ID})";
        //    return r.ID;
        //}

        [TestMethod]
        public void IndexTest()
        {
            Assert.Inconclusive();
        }
        protected override void initializeDatabase(EventProjectDbContext context)
        {
            ProfileDbTableInitializer.Initialize(context);
        }

        [TestMethod]
        public void FindFriendsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void propertiesTest()
        {
            Assert.Inconclusive();
        }


    }
}
