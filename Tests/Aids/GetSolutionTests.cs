using System;
using Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Aids
{
    [TestClass]
    public class GetSolutionTests : BaseTests
    {
        //private static string assemblyName => "EventProject.Aids";
        //private const string dummyName = "bla-bla";
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GetSolution);
        }
        [TestMethod]
        public void DomainTest()
        {
            var expected = AppDomain.CurrentDomain;
            var actual = GetSolution.Domain;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssemblyByNameTest()
        {
            Assert.Inconclusive();
            //Assert.IsNull(GetSolution.AssemblyByName(dummyName));
            //var assembly = GetSolution.AssemblyByName(assemblyName);
            //Assert.IsTrue(assembly.FullName.StartsWith(assemblyName));
        }
        [TestMethod]
        public void TypesForAssemblyTest()
        {
            Assert.Inconclusive();
            //var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            //var actual = GetSolution.TypesForAssembly(dummyName);
            //Assert.AreEqual(0, actual.Count);
            //Assert.IsInstanceOfType(actual, typeof(List<Type>));
            //actual = GetSolution.TypesForAssembly(assemblyName);
            //Assert.AreEqual(expected.Length, actual.Count);
            //foreach (var e in expected) Assert.IsTrue(actual.Contains(e));
        }
        [TestMethod]
        public void TypeNamesForAssemblyTest()
        {
            Assert.Inconclusive();
            //var expected = GetSolution.AssemblyByName(assemblyName).GetTypes();
            //var actual = GetSolution.TypeNamesForAssembly(dummyName);
            //Assert.AreEqual(0, actual.Count);
            //Assert.IsInstanceOfType(actual, typeof(List<string>));
            //actual = GetSolution.TypeNamesForAssembly(assemblyName);
            //Assert.AreEqual(expected.Length, actual.Count);
            //foreach (var e in expected)
            //    Assert.IsTrue(actual.Contains(e.FullName));
        }
    }
}
