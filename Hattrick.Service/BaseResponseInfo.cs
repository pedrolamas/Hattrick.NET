using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class BaseResponseInfo
    {
        #region Properties

        [XmlElement]
        public GenericNode<string> Filename { get; set; }

        [XmlElement]
        public GenericNode<string> Version { get; set; }

        [XmlElement("UserID")]
        public GenericNode<int> UserId { get; set; }

        [XmlElement]
        public DateTimeNode FetchedDate { get; set; }

        #endregion
    }
}