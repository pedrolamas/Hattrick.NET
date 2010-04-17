using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;

namespace Hattrick.Service.Responses
{
    [XmlRoot("HattrickData")]
    public class ArenaDetailsResponseInfo : BaseResponseInfo
    {
        #region Properties

        [XmlElement]
        public ArenaDetails Arena { get; set; }

        #endregion

        public ArenaDetailsResponseInfo()
        {
            Arena = new ArenaDetails();
        }

        #region Auxiliary Classes

        public class ArenaDetails
        {
            public ArenaDetails()
            {
                Team = new TeamDetails();
                League = new LeagueDetails();
                Region = new RegionDetails();
                CurrentCapacity = new CurrentCapacityDetails();
            }

            #region Properties

            [XmlElement("ArenaID")]
            public GenericNode<int> ArenaId { get; set; }

            [XmlElement]
            public GenericNode<string> ArenaName { get; set; }

            [XmlElement]
            public TeamDetails Team { get; set; }

            [XmlElement]
            public LeagueDetails League { get; set; }

            [XmlElement]
            public RegionDetails Region { get; set; }

            [XmlElement]
            public CurrentCapacityDetails CurrentCapacity { get; set; }

            #endregion
        }

        public class TeamDetails
        {
            #region Properties

            [XmlElement("TeamID")]
            public GenericNode<int> TeamId { get; set; }

            [XmlElement]
            public GenericNode<string> TeamName { get; set; }

            #endregion
        }

        public class LeagueDetails
        {
            #region Properties

            [XmlElement("LeagueID")]
            public GenericNode<int> LeagueId { get; set; }

            [XmlElement]
            public GenericNode<string> LeagueName { get; set; }

            #endregion
        }

        public class RegionDetails
        {
            #region Properties

            [XmlElement("RegionID")]
            public GenericNode<int> RegionId { get; set; }

            public GenericNode<string> RegionName { get; set; }

            #endregion
        }

        public class CurrentCapacityDetails
        {
            #region Properties

            [XmlElement]
            public DateTimeNode RebuiltDate { get; set; }

            [XmlElement]
            public GenericNode<int> Terraces { get; set; }

            [XmlElement]
            public GenericNode<int> Basic { get; set; }

            [XmlElement]
            public GenericNode<int> Roof { get; set; }

            [XmlElement]
            public GenericNode<int> VIP { get; set; }

            #endregion
        }

        #endregion
    }
}