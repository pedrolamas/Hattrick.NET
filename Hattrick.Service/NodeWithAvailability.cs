using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    public class NodeWithAvailability<T> : GenericNode<T>
    {
        private bool _available;

        #region Properties

        [XmlAttribute]
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }

        #endregion
    }
}