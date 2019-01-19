using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Profile;

namespace Domain.Comment
{
    public interface ICommentEventObjectsRepository : ICrudRepository<CommentEventObject>
    {
        
      
        Task<List<CommentObject>> GetCommentsList(string id);

    }
}
