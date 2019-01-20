using Core;
using Domain.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.CommentEvent
{
    public interface ICommentEventObjectsRepository : ICrudRepository<CommentEventObject>
    {
        
      
        Task<List<CommentObject>> GetCommentsList(string id);

    }
}
