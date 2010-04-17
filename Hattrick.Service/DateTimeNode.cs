using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    public class DateTimeNode : GenericNode<DateTime>, IXmlSerializable
    {
        private const string DATETIME_FORMAT = @"yyyy-MM-dd HH:mm:ss";

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToContent();

            var inputstring = reader.ReadString();

            try
            {
                Value = DateTime.ParseExact(inputstring, DATETIME_FORMAT, Thread.CurrentThread.CurrentCulture.DateTimeFormat, DateTimeStyles.AssumeLocal);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, "Invalid DateTime: " + inputstring);
            }
            reader.Read();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Value.ToString(DATETIME_FORMAT));
        }

        #endregion
    }
}