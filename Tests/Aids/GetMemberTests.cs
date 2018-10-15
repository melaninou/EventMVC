using System;
using System.Linq.Expressions;
using Aids;
using Data;
using Domain.Profile;
using Facade.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
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
            Assert.AreEqual("Age", GetMember.DisplayName<ProfileViewModel>(o => o.Age));
            Assert.AreEqual("Name", GetMember.DisplayName<ProfileViewModel>(o => o.Name));
            Assert.AreEqual("Gender", GetMember.DisplayName<ProfileViewModel>(o => o.Gender));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<ProfileViewModel>(null));
        }
    }
}
