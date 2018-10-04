using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data;

namespace Domain.Event
{
    public interface IEventObjectsRepository : IObjectsRepository<EventProfile, EventDbRecord>
    {
    }
}
