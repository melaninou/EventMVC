using Core;
using Domain.CommentsProfiles;
using Domain.Profile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Comment
{
    public interface ICommentObjectsRepository : ICrudRepository<CommentObject>
    {
        Task LoadEvents(ProfileObject profileObject);
        Task<CommentObject> GetObject(string eventID, string commentID);
        Task<List<CommentsProfileObject>> GetCommentsList(string id);

    }
}
