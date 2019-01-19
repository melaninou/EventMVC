using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Profile;

namespace Domain.Comment
{
    public interface ICommentObjectsRepository : ICrudRepository<CommentObject>
    {
        Task LoadEvents(ProfileObject profileObject);
        Task<CommentObject> GetObject(string eventID, string commentID);
        Task<List<CommentsProfileObject>> GetCommentsList(string id);

    }
}
