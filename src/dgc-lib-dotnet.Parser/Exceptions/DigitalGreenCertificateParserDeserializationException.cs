using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace dgc_lib_dotnet.Parser.Exceptions
{
    [Serializable]
    public sealed class DigitalGreenCertificateParserDeserializationException : Exception
    {
        public DigitalGreenCertificateParserDeserializationException()
        {
        }

        public DigitalGreenCertificateParserDeserializationException(string message):base(message)
        {
        }

        public DigitalGreenCertificateParserDeserializationException(string message, Exception innerException):base(message, innerException)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private DigitalGreenCertificateParserDeserializationException(SerializationInfo info, StreamingContext context):base(info, context)
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