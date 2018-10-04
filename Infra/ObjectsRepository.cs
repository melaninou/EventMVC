using System.Linq;
using Core;
using Data.Common;
using Domain.Common;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace Open.Infra
{
    public abstract class ObjectsRepository<TObject, TRecord> : PaginatedRepository<TObject, TRecord>, IObjectsRepository<TObject, TRecord>
        where TObject : BasicObject<TRecord>
        where TRecord : BasicDbRecord, new()
    {
        protected ObjectsRepository(DbSet<TRecord> s, DbContext c) : base(s, c) { }

        public bool IsInitialized()
        {
            db.Database.EnsureCreated();
            return dbSet.Any();
        }
    }
}
