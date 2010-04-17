using System;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
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