using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Facade.Common
{
    public class BasicViewModel : RootObject
    {
        private string name;
        private string location;
        public string Name
        {
            get => getString(ref name, Constants.Unspecified);
            set => name = value;
        }

        public string Location
        {
            get => getString(ref location, Constants.Unspecified);
            set => location = value;
        }
    }
}
