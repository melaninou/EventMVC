using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Domain.Profile;

namespace Domain.Comment
{
    public static class CommentObjectFactory
    {
        public static CommentObject Create(string id,  DateTime commentAddTime,
             string commentText, string subject, string email)
        {
            var o = new CommentDbRecord
            {
               ID = id,
               CommentAddTime = commentAddTime,
               CommentText = commentText,
                Name = subject,
                Location = email
             
            };
            return new CommentObject(o);
        }
    }
}
