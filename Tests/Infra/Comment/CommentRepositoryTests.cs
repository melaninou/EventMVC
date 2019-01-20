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
    public class CommentRepositoryTests :BaseTests
    {
        protected readonly CommentRepository repository;
        protected const int count = 0;
        protected readonly EventProjectDbContext db;

        public CommentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EventProjectDbContext>()
                .UseInMemoryDatabase("TestDb").Options;
            db = new EventProjectDbContext(options);
            repository = new CommentRepository(db);
        }
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(CommentRepository);
            Assert.AreEqual(0, db.Events.Count());
            for (var i = 0; i < count; i++)
            {
                db.Comments.Add(GetRandom.Object<CommentDbRecord>());
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void GetObject()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddExtra()
        {
            Assert.Inconclusive();
        }
    }
}
