using System.Threading.Tasks;
using Core;
using Data;

namespace Domain.Event
{
    public interface IEventObjectsRepository : IObjectsRepository<EventObject, EventDbRecord>
    {
        Task<PaginatedList<EventObject>> GetEventList();
    }
}
