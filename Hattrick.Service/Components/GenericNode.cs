using System.Xml;
using System.Xml.Serialization;

namespace Hattrick.Service.Components
{
    public class GenericNode<T>
    {
        private T _value;
        private XmlAttribute[] _unknownAttributes;
        //private XmlElement[] _unknownElements;

        #region Properties

        [XmlText]
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        [XmlAnyAttribute]
        public XmlAttribute[] UnknownAttributes
        {
            get { return _unknownAttributes; }
            set { _unknownAttributes = value; }
        }

        //[XmlAnyElement]
        //public XmlElement[] UnknownElements
        //{
        //    get { return _unknownElements; }
        //    set { _unknownElements = value; }
        //}

        #endregion
    }
}