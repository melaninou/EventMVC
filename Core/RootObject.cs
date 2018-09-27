

using Microsoft.VisualBasic;

namespace Core
{
    public abstract class RootObject
    {
        protected internal string getString(ref string field, string value = Constants.Unspecified) //checks that get is not null
        {
            if (string.IsNullOrWhiteSpace(field)) field = (value ?? string.Empty).Trim(); //if is: string.Empty
            return field;
        }
    }
}
