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
            Alliances = new AlliancesDetails();
        }
        #endregion

        #region Properties

        [XmlElement]
        public AlliancesDetails Alliances { get; set; }

        #endregion

        #region Auxiliary Classes

        public class AlliancesDetails
        {
            public AlliancesDetails()
            {
                Alliance = new AllianceDetails();
            }

            #region Properties


            [XmlElement]
            public AllianceDetails Alliance { get; set; }

            #endregion
        }

        public class AllianceDetails
        {
            public AllianceDetails()
            {
            }

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
