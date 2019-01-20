using Core;
using Data.Comment;
using System.Collections.Generic;

namespace Domain.CommentEvent
{
    public class CommentEventObjectsList : PaginatedList<CommentEventObject>
    {
        public CommentEventObjectsList(IEnumerable<CommentEventDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CommentEventObject(dbRecord));
            }
        }
    }
}
