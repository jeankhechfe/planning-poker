using System;

namespace planningpoker.Controllers.Exceptions
{
    public class IncompleteDataException : Exception
    {
        public IncompleteDataException(string msg) : base(msg)
        {
            
        }
    }
}