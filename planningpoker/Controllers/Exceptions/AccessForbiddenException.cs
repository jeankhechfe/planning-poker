using System;

namespace planningpoker.Controllers.Exceptions
{
    public class AccessForbiddenException : Exception
    {
        public AccessForbiddenException()
        {
        }

        public AccessForbiddenException(string? message) : base(message)
        {
        }
    }
}