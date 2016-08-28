using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace MyRESTService.Error_handler
{
    public class ValidationErrorBodyWriter : BodyWriter
    {
        private ValidationException validationException;
        private Encoding utf8Encoding = new UTF8Encoding(false);
        public ValidationErrorBodyWriter(ValidationException validationException) : base(true)
        {
            this.validationException = validationException;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("root");
            writer.WriteAttributeString("type", "object");

            writer.WriteStartElement("ErrorMessage");
            writer.WriteAttributeString("type", "string");
            writer.WriteString(validationException.ValidationResult.ErrorMessage);
            writer.WriteEndElement();

            writer.WriteStartElement("MemberNames");
            writer.WriteAttributeString("type", "array");
            foreach (var member in validationException.ValidationResult.MemberNames)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("type", "string");
                writer.WriteString(member);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}