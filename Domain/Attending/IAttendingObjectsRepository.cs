using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Domain.Event;
using Domain.Profile;

namespace Domain.Attending
{
    public interface IAttendingObjectsRepository : ICrudRepository<AttendingObject>
    {
        Task LoadEvents(ProfileObject profileObject);
        Task LoadProfiles(EventObject eventObject);
        Task RemoveListObjects(EventObject eventObject);
        Task<object> FindObject(string eventID, string userID);
        Task<AttendingObject> GetObject(string eventID, string userID);
        Task<List<EventObject>> GetUserEventsList(string userID);
    }
}
