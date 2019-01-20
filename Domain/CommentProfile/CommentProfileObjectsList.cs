using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data.Comment;

namespace Domain.CommentProfile
{
    public class CommentProfileObjectsList : PaginatedList<CommentProfileObject>
    {
        public CommentProfileObjectsList(IEnumerable<CommentProfileDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CommentProfileObject(dbRecord));
            }
        }
    }
}
