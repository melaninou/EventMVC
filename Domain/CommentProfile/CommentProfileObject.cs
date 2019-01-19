using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Comment;
using Data.Common;
using Domain.Comment;
using Domain.Common;
using Domain.Profile;

namespace Domain.CommentProfile
{
    public class CommentProfileObject : EmptyObject<CommentProfileDbRecord>
    {
        public readonly  CommentObject CommentObject;
        public readonly ProfileObject ProfileObject;

        public CommentProfileObject(CommentProfileDbRecord dbRecord) : base(dbRecord)
        {
            DbRecord.Comments= DbRecord.Comments ?? new CommentDbRecord();
            DbRecord.Profiles = DbRecord.Profiles ?? new ProfileDbRecord();

            CommentObject = new CommentObject(DbRecord.Comments);
            ProfileObject = new ProfileObject(DbRecord.Profiles);
        }
    }
}
