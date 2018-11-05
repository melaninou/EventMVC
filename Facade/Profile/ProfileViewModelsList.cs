using Core;
using Domain.Profile;

namespace Facade.Profile
{
    public class ProfileViewModelsList : PaginatedList<ProfileViewModel>
    {
        public ProfileViewModelsList(IPaginatedList<ProfileObject> list)
        {
            if (list is null) return;
            PageIndex = list.PageIndex;
            TotalPages = list.TotalPages;
            foreach (var e in list)
            {
                Add(ProfileViewModelFactory.Create(e));
            }
        }
    }
}
