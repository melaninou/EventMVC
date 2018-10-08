using Core;

namespace Facade.Common
{
    public class BasicViewModel : RootObject
    {
        private string name;
        private string location;
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        public string Location
        {
            get => getString(ref location);
            set => location = value;
        }
    }
}
