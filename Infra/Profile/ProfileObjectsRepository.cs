using System.Collections.Generic;
using Core;
using Data;
using Domain.Profile;
using Open.Infra;

namespace Infra.Profile
{
    public class ProfileObjectsRepository : ObjectsRepository<ProfileObject, ProfileDbRecord>,
        IProfileObjectsRepository
    {
        public ProfileObjectsRepository(EventProjectDbContext c) : base(c?.Profiles, c) { }

        protected internal override ProfileObject createObject(ProfileDbRecord r)
        {
            return new ProfileObject(r);
        }

        protected internal override PaginatedList<ProfileObject> createList(
            List<ProfileDbRecord> l, RepositoryPage p)
        {
            return new ProfileObjectsList(l, p);
        }
    }
}
