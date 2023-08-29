using System;
using System.Runtime.Serialization;

namespace LaNacion.Services.Services.Contacts.Exceptions
{
    [Serializable]
    public class DeleteContactException : Exception
    {
        public DeleteContactException()
        {
        }

        public DeleteContactException(string message) : base(message)
        {
        }

        public DeleteContactException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DeleteContactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}