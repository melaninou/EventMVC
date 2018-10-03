using Core;

namespace Data.Common
{
    public abstract class UniqueDbRecord : RootObject
    {
        protected string id;
        internal string name;
        internal string location;
        public virtual string ID
        {
            get => getString(ref id, Constants.Unspecified);
            set => id = value;
        }
        public virtual string Name
        {
            get => getString(ref name, Constants.Unspecified);
            set => name = value;
        }
        public virtual string Location
        {
            get => getString(ref location, Constants.Unspecified);
            set => location = value;
        }
    }
}
