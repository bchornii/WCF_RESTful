using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace MyRESTService
{
    public class UserErrorBodyWriter : BodyWriter
    {
        Exception exception;
        public UserErrorBodyWriter(Exception exception) : base(true)
        {
            this.exception = exception;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("root");
            writer.WriteAttributeString("type", "object");

            writer.WriteStartElement("Error type");
            writer.WriteAttributeString("type", "string");
            writer.WriteString(exception.GetType().ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("Error message");
            writer.WriteAttributeString("type", "string");
            writer.WriteString(exception.Message);
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}