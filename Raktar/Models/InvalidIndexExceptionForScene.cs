using System;
using System.Runtime.Serialization;

namespace Raktar.Models
{
    [Serializable]
    internal class InvalidIndexExceptionForScene : Exception
    {
        public InvalidIndexExceptionForScene()
        {
        }

        public InvalidIndexExceptionForScene(string message) : base(message)
        {
        }

        public InvalidIndexExceptionForScene(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidIndexExceptionForScene(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}