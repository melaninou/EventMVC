using System;
using Aids;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core
{
    [TestClass]
    public class RootObjectTests :ClassTests<RootObject>
    {
        private string x;
        private string y;
        private testClass obj;

        private class testClass : RootObject
        {
            public string S;
            public DateTime F;
            public DateTime T;
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass { F = DateTime.MaxValue, T = DateTime.MinValue };
            x = GetRandom.String();
            y = GetRandom.String();
        }
        
        [TestMethod]
        public void GetValueTest()
        {
            testGetValue(null, y, y);
            testGetValue("",y,y);
            testGetValue("      ", y, y);
            testGetValue(x, y, x);
        }

        private void testGetValue(string field, string value, string expected)
        {
            obj.S = field;
            obj.getString(ref obj.S, value);
            Assert.AreEqual(expected, obj.S);
        }

        [TestMethod]
        public void ContainsTest()
        {
            obj = GetRandom.Object<testClass>();
            Assert.IsFalse(obj.Contains(GetRandom.String()));
            Assert.IsTrue(obj.Contains(string.Empty));
            Assert.IsTrue(obj.Contains(null));
            Assert.IsTrue(obj.Contains(obj.Name));
            obj.Name = null;
            Assert.IsTrue(obj.Contains(obj.Date.Year.ToString()));
            Assert.IsTrue(obj.Contains(obj.Date.Day.ToString()));
            Assert.IsTrue(obj.Contains(obj.Date.Month.ToString()));
        }
    }
}
