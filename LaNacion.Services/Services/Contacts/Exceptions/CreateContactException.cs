using System;
using System.Runtime.Serialization;

namespace LaNacion.Services.Services.Contacts.Exceptions
{
    [Serializable]
    public class CreateContactException : Exception
    {
        public CreateContactException()
        {
        }

        public CreateContactException(string message) : base(message)
        {
        }

        public CreateContactException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CreateContactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}