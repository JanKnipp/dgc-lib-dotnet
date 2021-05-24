using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace dgc_lib_dotnet.Parser.Exceptions
{
    [Serializable]
    public sealed class DigitalGreenCertificateParserSerializationException : Exception
    {
        public DigitalGreenCertificateParserSerializationException()
        {
        }

        public DigitalGreenCertificateParserSerializationException(string message) : base(message)
        {
        }

        public DigitalGreenCertificateParserSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private DigitalGreenCertificateParserSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            base.GetObjectData(info, context);
        }
    }
}