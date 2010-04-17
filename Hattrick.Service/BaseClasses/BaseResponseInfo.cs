using System.Xml.Serialization;
using Hattrick.Service.Components;

namespace Hattrick.Service.BaseClasses
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