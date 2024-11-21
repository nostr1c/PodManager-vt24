using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Serializer
{
    public class SerializerException : Exception
    {
        public SerializerException() : base("Serializer related issue.") { }

        public SerializerException(string message) : base(message) { }

        public SerializerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
