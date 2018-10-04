using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data.Common;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public abstract class BaseRepository<TObject, TDbRecord> : ICrudRepository<TObject>
        where TObject : BasicObject<TDbRecord>
        where TDbRecord : BasicDbRecord, new()
    {
        protected internal readonly DbSet<TDbRecord> dbSet;
        protected internal readonly DbContext db;

        protected internal abstract TObject createObject(TDbRecord r);

        protected internal async Task<TDbRecord> getObject(string id)
        {
            return await dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.ID == id);
        }

        protected BaseRepository(DbSet<TDbRecord> s, DbContext c)
        {
            dbSet = s;
            db = c;
        }

        public async Task<TObject> GetObject(string id)
        {
            var r = await getObject(id);
            return createObject(r);
        }

        public async Task AddObject(TObject o)
        {
            dbSet.Add(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task UpdateObject(TObject o)
        {
            dbSet.Update(o.DbRecord);
            await db.SaveChangesAsync();
        }

        public async Task DeleteObject(TObject o)
        {
            dbSet.Remove(o.DbRecord);
            await db.SaveChangesAsync();
        }
    }
}
