using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IPaginatedList<T> : IList<T>
    {
        int PageIndex { get; }
        int TotalPages { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}
