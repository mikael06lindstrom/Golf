using System;

namespace Golf
{
    public class ForManyStrokeException : Exception
    {
        public ForManyStrokeException(string message) : base(message) { }
    }
}
