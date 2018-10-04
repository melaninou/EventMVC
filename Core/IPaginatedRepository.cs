using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IPaginatedRepository<TObject, TRecord>
    {
        string SearchString { get; set; }
        int? PageIndex { get; set; }
        int? PageSize { get; set; }
        SortOrder SortOrder { get; set; }

        Func<TRecord, object> SortFunction { get; set; }
        Task<PaginatedList<TObject>> GetObjectsList();
    }
}
