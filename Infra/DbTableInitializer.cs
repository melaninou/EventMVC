using System;
using System.Collections.Generic;
using System.Text;

namespace Infra
{
    public static class DbTableInitializer
    {
        public static void Initialize(EventProjectDbContext dbContext)
        {
            ProfileDbTableInitializer.Initialize(dbContext);
            
        }
    }
}
