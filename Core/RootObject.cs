using System;
using Aids;
namespace Core
{
    public abstract class RootObject
    {
        protected internal string getString(ref string field, string value = Constants.Unspecified) //checks that get is not null
        {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim(); //if is: string.Empty
            return field;
        }

        protected internal void setValue<T>(ref T field, T value)
        {
            field = value;
        }

        protected internal T getValue<T>(ref T field, ref T value) where T : IComparable
        {
            Sort.Upwards(ref field, ref value);
            return field;
        }

        public virtual bool Contains(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return true;
            searchString = searchString.ToLower();
            var values = GetClass.ReadWritePropertyValues(this);
            foreach (var value in values)
            {
                if (value is null) continue;
                if (value.ToString().ToLower().Contains(searchString)) return true;
            }

            return GetType().Name.ToLower().Contains(searchString);
        }
    }
}
