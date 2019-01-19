using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data;
using Data.Comment;

namespace Domain.Comment
{
    public class CommentProfilesObjectsList : PaginatedList<CommentsProfileObject>
    {
        public CommentProfilesObjectsList(IEnumerable<CommentsProfileDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return;
            foreach (var dbRecord in items)
            {
                Add(new CommentsProfileObject(dbRecord));
            }
        }
    }
}
