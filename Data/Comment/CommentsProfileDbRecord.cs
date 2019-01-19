using System;
using Data.Common;

namespace Data.Comment
{
    public class CommentsProfileDbRecord : BasicDbRecord
    {
        private DateTime commentAddTime;
        protected string id;
        private string userName;
        private string userPicture;
        private string commentText;


        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public DateTime CommentAddTime
        {
            get => getValue(ref commentAddTime, ref commentAddTime);
            set => setValue(ref commentAddTime, value);
        }
        public string UserName
        {
            get => getString(ref userName);
            set => userName = value;
        }
        public string UserPicture
        {
            get => getString(ref userPicture);
            set => userPicture = value;
        }
        public string CommentText
        {
            get => getString(ref commentText);
            set => commentText = value;
        }

        private string profileID;


        public string ProfileID
        {
            get => getString(ref profileID);
            set => profileID = value;
        }
      
        public virtual ProfileDbRecord Profiles { get; set; }

    }
}
