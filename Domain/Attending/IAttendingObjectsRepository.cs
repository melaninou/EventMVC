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

    }
}
