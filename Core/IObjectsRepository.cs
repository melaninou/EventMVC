using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IObjectsRepository<TObject, TRecord> :
        IPaginatedRepository<TObject, TRecord>,
        ICrudRepository<TObject>
    {
        bool IsInitialized();
    }
}
