using System.Xml.Serialization;

namespace Hattrick.Service.Components
{
    public class BooleanNode : GenericNode<bool>, IXmlSerializable
    {
        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();

            Value = bool.Parse(reader.ReadString());

            reader.Read();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Value.ToString());
        }

        #endregion
    }
}