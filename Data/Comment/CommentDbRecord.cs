using System;
using Data.Common;

namespace Data.Comment
{
    public class CommentDbRecord : BasicDbRecord
    {
        private DateTime commentAddTime;
        protected string id;
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
      
        public string CommentText
        {
            get => getString(ref commentText);
            set => commentText = value;
        }

       

    }
}
