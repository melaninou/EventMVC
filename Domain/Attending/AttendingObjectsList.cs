using System.Collections.Generic;
using Core;
using Data;

namespace Domain.Attending
{
    public class AttendingObjectsList : PaginatedList<AttendingObject>
    {
        public AttendingObjectsList(IEnumerable<AttendingDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new AttendingObject(dbRecord));
            }
        }
    }
}
