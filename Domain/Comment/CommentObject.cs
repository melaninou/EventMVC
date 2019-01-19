using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Domain.Common;
using Domain.Event;
using Domain.Profile;

namespace Domain.Comment
{
    public sealed class CommentObject : BasicObject<CommentDbRecord>
    {
       
        public CommentObject(CommentDbRecord dDbRecord) : base(dDbRecord ?? new CommentDbRecord())
        {
           
        }

    }
}
