using System.Collections.Generic;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class AlliancesResponseInfo : BaseResponseInfo
    {
        #region Enumerations - not generated
        #endregion
        #region Constructors
        public AlliancesResponseInfo()
        {
            Alliances = new List<Alliance>();
        }
        #endregion

        #region Properties

        [XmlArray]
        public List<Alliance> Alliances { get; set; }

        #endregion

        #region Auxiliary Classes

        public class Alliance
        {
            #region Properties

            [XmlElement]
            public GenericNode<int> AllianceID { get; set; }
            [XmlElement]
            public GenericNode<string> AllianceName { get; set; }
            [XmlElement]
            public GenericNode<string> AllianceDescription { get; set; }

            #endregion
        }


        #endregion
    }
}
