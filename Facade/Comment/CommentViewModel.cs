using System;
using Facade.Common;

namespace Facade.Comment
{
   public class CommentViewModel : EmptyViewModel
   {
       private string id;
       private DateTime commentAddTime;
       private string userPicture;
       private string userName;
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
       public string UserPicture
       {
           get => getString(ref userPicture);
           set => userPicture = value;
       }
       public string UserName
       {
           get => getString(ref userName);
           set => userName = value;
       }
       public string CommentText
       {
           get => getString(ref commentText);
           set => commentText = value;
       }

       
    }
}
