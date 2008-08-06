using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ConnectionDetailsResponseInfo: BaseResponseInfo
    {
        private string _recommendedUrl;

        #region Properties

        [XmlElement("RecommendedURL")]
        public string RecommendedUrl
        {
            get { return _recommendedUrl; }
            set { _recommendedUrl = value; }
        }

        #endregion
    }
}