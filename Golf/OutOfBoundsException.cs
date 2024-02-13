using System;

namespace Golf
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string message) : base(message)
        {}
    }
}
