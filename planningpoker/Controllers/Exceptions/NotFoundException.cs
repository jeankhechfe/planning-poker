using System;

namespace planningpoker.Controllers.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {
            
        }
    }
}