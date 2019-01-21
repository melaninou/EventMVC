using System.Collections.Generic;
using Core;
using Data;
using Domain.Common;
using Domain.Profile;

namespace Domain.Event
{
   public sealed class EventObject : BasicObject<EventDbRecord>
   {
       private readonly List<ProfileObject> profilesInUse;

       public EventObject(EventDbRecord r) : base(r ?? new EventDbRecord())
       {
           profilesInUse = new List<ProfileObject>();
       }

       public IReadOnlyList<ProfileObject> ProfilesInUse => profilesInUse.AsReadOnly();

       public void ProfileInUse(ProfileObject profileObject)
       {
           if (profileObject is null) return;
           if (profileObject.DbRecord.ID == Constants.Unspecified) return;
           if (profilesInUse.Find(x => x.DbRecord.ID == profileObject.DbRecord.ID) != null)
               return;
           profilesInUse.Add(profileObject);
       }


   }
}
