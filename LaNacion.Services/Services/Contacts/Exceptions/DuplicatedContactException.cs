using System;
using System.Runtime.Serialization;

namespace LaNacion.Services.Services.Contacts.Exceptions
{
    [Serializable]
    public class DuplicatedContactException : Exception
    {
        public DuplicatedContactException()
        {
        }

        public DuplicatedContactException(string message) : base(message)
        {
        }

        public DuplicatedContactException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedContactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}