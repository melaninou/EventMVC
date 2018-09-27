using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace Data
{
    public class ProfileDbRecord
    {
        private string id;
        private string name;
        private string age;
        private string location;
        private string gender;

        //TODO think override
        public string ID
        {
            get => getString(ref id, Name);
            set => id = value;
        }

        public string Name
        {
            get => getString(ref name, Name);
            set => name = value;
        }

        public string Age
        {
            get => getString(ref age, Constants.Unspecified);
            set => age = value;
        }

        public string Location
        {
            get => getString(ref location, Constants.Unspecified);
            set => location = value;
        }

        public string Gender
        {
            get => getString(ref gender, Constants.Unspecified);
            set => gender = value;
        }

        //TODO move to rootobject
        protected internal string getString(ref string field, string value = Constants.Unspecified) //checks that get is not null
        {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim(); //if is: string.Empty
            return field;
        }
    }

    //TODO create a new class
    public static class Constants
    {
        public const string Unspecified = "Unspecified";
    }
}
