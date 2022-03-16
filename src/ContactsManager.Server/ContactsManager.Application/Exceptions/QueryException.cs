using System;

namespace ContactsManager.Application.Exceptions
{
    public class QueryException : Exception
    {
        public QueryException()
        { }

        public QueryException(string message)
            : base(message)
        { }

        public QueryException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
