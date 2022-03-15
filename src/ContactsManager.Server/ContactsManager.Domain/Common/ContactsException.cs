using System;

namespace ContactsManager.Domain.Common
{
    public class ContactsException : Exception
    {
        public ContactsException()
        { }

        public ContactsException(string message)
            : base(message)
        { }

        public ContactsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
