using Data.Common;

namespace Data.Comment
{
   public class CommentDbRecord : EmptyDbRecord
   {
       private string eventID;
       private string commentID;

       public string EventID
       {
           get => getString(ref eventID);
           set => eventID = value;
       }

       public string CommentID
       {
           get => getString(ref commentID);
           set => commentID = value;
       }

       public virtual EventDbRecord Events { get; set; }
       public virtual CommentsProfileDbRecord CommentsProfile {get; set; }
    }
}
