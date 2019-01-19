using Infra.Event;
using Infra.Profile;

namespace Infra
{
    public static class DbTableInitializer
    {
        public static void Initialize(EventProjectDbContext dbContext)
        {
            ProfileDbTableInitializer.Initialize(dbContext);
            EventDbTableInitializer.Initialize(dbContext);
            EventProfileDbTableInitializer.Initialize(dbContext);

        }
    }
}
