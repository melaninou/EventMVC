using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Attending;
using Domain.Event;
using Domain.Profile;

namespace Domain.Following
{
    public interface IFollowingObjectsRepository : ICrudRepository<FollowingObject>
    {
        Task<FollowingObject> GetObject(string userID, string followedUserID);
        Task<object> FindObject(string userID, string followedUserID);
        Task LoadFollowers(ProfileObject userObject);

    }
}
