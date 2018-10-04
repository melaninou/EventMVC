using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Data;

namespace Domain.Profile
{
    public class ProfileObjectsList : PaginatedList<ProfileObject>
    {
        public ProfileObjectsList(IEnumerable<ProfileDbRecord> items, RepositoryPage page) : base(page)
        {
            if (items is null) return; //can create null object test
            foreach (var dbRecord in items)
            {
                Add(new ProfileObject(dbRecord));
            }
        }
    }
}
