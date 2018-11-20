using Core;

namespace Data.Common
{
    public abstract class BasicDbRecord : RootObject
    {
        protected string id;
        internal string name;
        internal string location;
        public virtual string ID
        {
            get => getString(ref id);
            set => id = value;
        }
        public virtual string Name
        {
            get => getString(ref name, ID);
            set => name = value;
        }
        public virtual string Location
        {
            get => getString(ref location);
            set => location = value;
        }
    }
}
