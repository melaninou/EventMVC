using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Domain.Comment
{
    public interface ICommentObjectsRepository : ICrudRepository<CommentObject>
    {
    }
}
