using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ConnectionDetailsResponseInfo : BaseResponseInfo
    {
        #region Properties

        [XmlElement("RecommendedURL")]
        public string RecommendedUrl { get; set; }

        #endregion
    }
}