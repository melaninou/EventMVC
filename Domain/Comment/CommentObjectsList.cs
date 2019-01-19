using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Comment;

namespace Domain.Comment
{
    public class CommentObjectsList : PaginatedList<CommentObject>
    {
        public CommentObjectsList(IEnumerable<CommentDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CommentObject(dbRecord));
            }
        }
    }
}
