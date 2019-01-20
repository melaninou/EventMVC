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
    public class CommentEventRepositoryTests :BaseTests
    {
        protected readonly CommentEventRepository repository;
        protected const int count = 0;
        protected readonly EventProjectDbContext db;

        public CommentEventRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EventProjectDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            db = new EventProjectDbContext(options);
            repository = new CommentEventRepository(db);
        }
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentEventRepository);
            Assert.AreEqual(0, db.Events.Count());
            for (var i = 0; i < count; i++)
            {
                db.CommentEvent.Add(GetRandom.Object<CommentEventDbRecord>());
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void AddObject()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpdateObject()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DeleteObject()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetObject()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetCommentsList()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetCommentsIDList()
        {
            Assert.Inconclusive();
        }
    }
}
