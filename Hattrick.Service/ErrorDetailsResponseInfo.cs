using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ErrorDetailsResponseInfo : BaseResponseInfo
    {
        #region Properties

        [XmlElement]
        public GenericNode<string> Error { get; set; }

        [XmlElement]
        public GenericNode<int> ErrorCode { get; set; }

        [XmlElement]
        public GenericNode<Guid> ErrorGuid { get; set; }

        #endregion
    }
}