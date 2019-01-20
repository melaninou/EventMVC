using System.Linq;
using Aids;
using Data.Comment;
using Infra;
using Infra.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Comment
{
    [TestClass]
    public class CommentProfileRepositoryTests :BaseTests
    {
        protected readonly CommentProfileRepository repository;
        protected const int count = 0;
        protected readonly EventProjectDbContext db;

        public CommentProfileRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EventProjectDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            db = new EventProjectDbContext(options);
            repository = new CommentProfileRepository(db);
        }
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentProfileRepository);
            Assert.AreEqual(0, db.Events.Count());
            for (var i = 0; i < count; i++)
            {
                db.CommentProfile.Add(GetRandom.Object<CommentProfileDbRecord>());
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void GetObjectTest()
        {
            Assert.Inconclusive();
        }


        [TestMethod]
        public void DeleteObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddObjectTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpdateObjectTest()
        {
            Assert.Inconclusive();
        }


        [TestMethod]
        public void GetObjectStringTest()
        {
            Assert.Inconclusive();
        }

    }
}
