using System.Runtime.Serialization;

namespace LaNacion.Services.Services.Contacts.Exceptions
{
    [Serializable]
    public class UpdateContactException : Exception
    {
        public UpdateContactException()
        {
        }

        public UpdateContactException(string message) : base(message)
        {
        }

        public UpdateContactException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateContactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}