using System;
using System.Collections.Generic;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
    [TestClass]
    public class LogTests : BaseTests
    {
        internal class testLogBook : ILogBook
        {
            public string LoggedMessage { get; private set; }
            public Exception LoggedException { get; private set; }
            public List<Exception> LoggedExceptions { get; } = new List<Exception>();
            public void WriteEntry(string message)
            {
                LoggedMessage = message;
            }

            public void WriteEntry(Exception e)
            {
                LoggedException = e;
                LoggedExceptions.Add(e);
            }
        }
        private testLogBook logBook;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(Log);
            logBook = new testLogBook();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }
        
        
        [TestMethod]
        public void MessageTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void ExceptionTest()
        {
            Assert.Inconclusive();
        }
    }
}
