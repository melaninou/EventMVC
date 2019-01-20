using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Domain.CommentProfile
{
    public interface ICommentProfileObjectsRepository : ICrudRepository<CommentProfileObject>
    {
        Task<string> GetObjectString(string commentID);
    }
}
