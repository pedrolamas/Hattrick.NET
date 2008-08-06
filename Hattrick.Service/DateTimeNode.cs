using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    public class DateTimeNode : GenericNode<DateTime>, IXmlSerializable
    {
        private const string DATETIME_FORMAT = @"yyyy-MM-dd hh:MM:ss";

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();

            Value = DateTime.Parse(reader.ReadString());

            reader.Read();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Value.ToString(DATETIME_FORMAT));
        }

        #endregion
    }
}