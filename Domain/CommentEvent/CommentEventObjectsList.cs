using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Comment;

namespace Domain.Comment
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
