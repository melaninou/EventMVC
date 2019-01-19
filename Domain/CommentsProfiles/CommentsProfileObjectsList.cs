using System.Collections.Generic;
using Core;
using Data.Comment;

namespace Domain.CommentsProfiles
{
    public class CommentsProfileObjectsList : PaginatedList<CommentsProfileObject>
    {
        public CommentsProfileObjectsList(IEnumerable<CommentsProfileDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CommentsProfileObject(dbRecord));
            }
        }
    }
}
