using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class RegionDetailsResponseInfo : BaseResponseInfo
    {
        #region Properties

        public LeagueDetails League { get; set; }

        #endregion

        public RegionDetailsResponseInfo()
        {
            League = new LeagueDetails();
        }

        #region Auxiliary Classes

        public class LeagueDetails
        {
            public LeagueDetails()
            {
                Region = new RegionDetails();
            }

            #region Properties

            [XmlElement("LeagueID")]
            public GenericNode<int> LeagueId { get; set; }

            [XmlElement]
            public GenericNode<string> LeagueName { get; set; }

            [XmlElement]
            public RegionDetails Region { get; set; }

            #endregion
        }

        public class RegionDetails
        {
            #region Properties

            [XmlElement("RegionID")]
            public GenericNode<int> RegionId { get; set; }

            [XmlElement]
            public GenericNode<string> RegionName { get; set; }

            [XmlElement("WeatherID")]
            public GenericNode<int> WeatherId { get; set; }

            [XmlElement("TomorrowWeatherID")]
            public GenericNode<int> TomorrowWeatherId { get; set; }

            public GenericNode<int> NumberOfUsers { get; set; }

            public GenericNode<int> NumberOfUsersOnline { get; set; }

            #endregion
        }

        #endregion
    }
}