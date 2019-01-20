using Data.Comment;
using Domain.Common;

namespace Domain.Comment
{
    public sealed class CommentObject : BasicObject<CommentDbRecord>
    {
       
        public CommentObject(CommentDbRecord dDbRecord) : base(dDbRecord ?? new CommentDbRecord())
        {
           
        }

    }
}
