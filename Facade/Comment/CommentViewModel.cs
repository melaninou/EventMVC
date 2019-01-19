using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Facade.Common;
using Facade.Event;
using Facade.Profile;

namespace Facade.Comment
{
   public class CommentViewModel : EmptyViewModel
   {
       private string id;
       private DateTime commentAddTime;
       private string subject;
       private string email;
       private string commentText;
       private ProfileViewModel profileViewModel;

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

       public ProfileViewModel ProfileViewModel { get; set; }
    }
}
