using System.ComponentModel.DataAnnotations;
using Core;

namespace Facade.Common
{
    public class BasicViewModel : RootObject
    {
        private string name;
        private string location;
        private string id;

        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        [Required]
        public string Name
        {
            get => getString(ref name);
            set => name = value;
        }

        [Required]
        public string Location
        {
            get => getString(ref location);
            set => location = value;
        }
    }
}
