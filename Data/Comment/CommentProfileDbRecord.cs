using System;
using System.Collections.Generic;
using System.Text;
using Data.Common;

namespace Data.Comment
{
    public class CommentProfileDbRecord : EmptyDbRecord
    {
        private string commentID;
        private string profileID;

        public string CommentID
        {
            get => getString(ref commentID);
            set => commentID = value;
        }
        public string ProfileID
        {
            get => getString(ref profileID);
            set => profileID = value;
        }
        public virtual  ProfileDbRecord Profiles { get; set; }
        public virtual CommentDbRecord Comments { get; set; }
    }
}
