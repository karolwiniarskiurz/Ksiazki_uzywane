using System;

namespace UzywaneKsiazki.Helpers.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException()
        {
        }

        public PostNotFoundException(string message) : base(message)
        {
        }

        public PostNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}