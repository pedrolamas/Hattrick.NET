using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class ConnectionDetailsResponseInfo : BaseResponseInfo
    {
        #region Properties

        [XmlElement("RecommendedURL")]
        public GenericNode<string> RecommendedUrl { get; set; }

        #endregion
    }
}