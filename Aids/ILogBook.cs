using System;

namespace Aids
{
    public interface ILogBook
    {
        void WriteEntry(string message);
        void WriteEntry(Exception e);
    }
}
