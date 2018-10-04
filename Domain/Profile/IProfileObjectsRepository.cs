using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data;

namespace Domain.Profile
{
    public interface IProfileObjectsRepository : IObjectsRepository<ProfileObject, ProfileDbRecord> { }

}
