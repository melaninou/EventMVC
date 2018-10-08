using Core;
using Data;

namespace Domain.Event
{
    public interface IEventObjectsRepository : IObjectsRepository<EventObject, EventDbRecord>
    {
    }
}
