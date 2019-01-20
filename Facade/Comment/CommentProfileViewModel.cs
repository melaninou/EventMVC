using Facade.Common;
using System;

namespace Facade.Comment
{
    public class CommentProfileViewModel : EmptyViewModel
    {
        private string id;
        private DateTime commentAddTime;
        private string subject;
        private string email;
        private string commentText;
        private string name;
        private string image;
       

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
        public string Subject
        {
            get => getString(ref subject);
            set => subject = value;
        }

        public string Image
        {
            get => getString(ref image);
            set => image = value;
        }
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }
        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }
        public string CommentText
        {
            get => getString(ref commentText);
            set => commentText = value;
        }
    }
}
