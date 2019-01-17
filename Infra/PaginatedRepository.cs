using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data.Common;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public abstract class PaginatedRepository<TObject, TDbRecord> : BaseRepository<TObject, TDbRecord>,
        IPaginatedRepository<TObject, TDbRecord>
        where TObject : BasicObject<TDbRecord>
        where TDbRecord : BasicDbRecord, new()
    {
        protected internal abstract PaginatedList<TObject> createList(List<TDbRecord> items, RepositoryPage p);

        protected PaginatedRepository(DbSet<TDbRecord> s, DbContext c) : base(s, c) { }

        public string SearchString { get; set; }

        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public SortOrder SortOrder { get; set; }
        public Func<TDbRecord, object> SortFunction { get; set; }

        public async Task<PaginatedList<TObject>> GetObjectsList()
        {
            var objects = getSorted().Where(s => s.Contains(SearchString)).AsNoTracking();
            var count = await objects.CountAsync(); //how many wanted
            var p = new RepositoryPage(count, PageIndex, PageSize); //calculating next pages' parameters
            var items = await objects.Skip(p.FirstItemIndex).Take(p.PageSize).ToListAsync(); //andmebaasist vajaliku hulga kirjete (PageSize) alates kirje vajalikust indexist (FirstItemIndex) küsimine
            return createList(items, p);
        }


        private IQueryable<TDbRecord> getSorted()
        {
            if (SortFunction is null) return getSet();
            return SortOrder == SortOrder.Descending
                ? getSet().OrderByDescending(x => SortFunction(x))
                : getSet().OrderBy(x => SortFunction(x));
        }

        private IQueryable<TDbRecord> getSet()
        {
            return from s in dbSet select s;
        }
    }
}
