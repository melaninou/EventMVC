using System;
using System.Linq.Expressions;
using Aids;
using Data;
using Domain.Profile;
using Facade.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
    [TestClass]
    public class GetMemberTests :BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GetMember);
        }

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual("DbRecord", GetMember.Name<ProfileObject>(o => o.DbRecord));
            Assert.AreEqual("Name", GetMember.Name<ProfileDbRecord>(o => o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<ProfileDbRecord, object>>)null));
        }

        [TestMethod]
        public void DisplayNameTest()
        {
            Assert.AreEqual("DbRecord", GetMember.DisplayName<ProfileObject>(o => o.DbRecord));
            Assert.AreEqual("BirthDay", GetMember.DisplayName<ProfileViewModel>(o => o.BirthDay));
            Assert.AreEqual("Name", GetMember.DisplayName<ProfileViewModel>(o => o.Name));
            Assert.AreEqual("Gender", GetMember.DisplayName<ProfileViewModel>(o => o.Gender));
            Assert.AreEqual("Location", GetMember.DisplayName<ProfileViewModel>(o => o.Location));
            Assert.AreEqual("Little bit about Me:", GetMember.DisplayName<ProfileViewModel>(o => o.AboutText));
            Assert.AreEqual("Occupation", GetMember.DisplayName<ProfileViewModel>(o => o.Occupation));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<ProfileViewModel>(null));
        }
    }
}
