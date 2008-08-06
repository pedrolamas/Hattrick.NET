using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class ArenaDetailsResponseInfo : BaseResponseInfo
    {
        private ArenaDetails _arena = new ArenaDetails();

        #region Properties

        [XmlElement]
        public ArenaDetails Arena
        {
            get { return _arena; }
            set { _arena = value; }
        }

        #endregion

        public class ArenaDetails
        {
            private GenericNode<int> _arenaId;
            private GenericNode<string> _arenaName;
            private TeamDetails _team = new TeamDetails();
            private LeagueDetails _league = new LeagueDetails();
            private RegionDetails _region = new RegionDetails();
            private CurrentCapacityDetails _currentCapacity = new CurrentCapacityDetails();

            #region Properties

            [XmlElement("ArenaID")]
            public GenericNode<int> ArenaId
            {
                get { return _arenaId; }
                set { _arenaId = value; }
            }

            [XmlElement]
            public GenericNode<string> ArenaName
            {
                get { return _arenaName; }
                set { _arenaName = value; }
            }

            [XmlElement]
            public TeamDetails Team
            {
                get { return _team; }
                set { _team = value; }
            }

            [XmlElement]
            public LeagueDetails League
            {
                get { return _league; }
                set { _league = value; }
            }

            [XmlElement]
            public RegionDetails Region
            {
                get { return _region; }
                set { _region = value; }
            }

            [XmlElement]
            public CurrentCapacityDetails CurrentCapacity
            {
                get { return _currentCapacity; }
                set { _currentCapacity = value; }
            }

            #endregion
        }

        public class TeamDetails
        {
            private GenericNode<int> _teamId;
            private GenericNode<string> _teamName;

            #region Properties

            [XmlElement("TeamID")]
            public GenericNode<int> TeamId
            {
                get { return _teamId; }
                set { _teamId = value; }
            }

            [XmlElement]
            public GenericNode<string> TeamName
            {
                get { return _teamName; }
                set { _teamName = value; }
            }

            #endregion
        }

        public class LeagueDetails
        {
            private int _leagueId;
            private string _leagueName;

            #region Properties

            [XmlElement("LeagueID")]
            public int LeagueId
            {
                get { return _leagueId; }
                set { _leagueId = value; }
            }

            [XmlElement]
            public string LeagueName
            {
                get { return _leagueName; }
                set { _leagueName = value; }
            }

            #endregion
        }

        public class RegionDetails
        {
            private GenericNode<int> _regionId;
            private GenericNode<string> _regionName;

            #region Properties

            [XmlElement("RegionID")]
            public GenericNode<int> RegionId
            {
                get { return _regionId; }
                set { _regionId = value; }
            }

            public GenericNode<string> RegionName
            {
                get { return _regionName; }
                set { _regionName = value; }
            }

            #endregion
        }

        public class CurrentCapacityDetails
        {
            private DateTimeNode _rebuiltDate;
            private GenericNode<int> _terraces;
            private GenericNode<int> _basic;
            private GenericNode<int> _roof;
            private GenericNode<int> _vip;

            #region Properties

            [XmlElement]
            public DateTimeNode RebuiltDate
            {
                get { return _rebuiltDate; }
                set { _rebuiltDate = value; }
            }

            [XmlElement]
            public GenericNode<int> Terraces
            {
                get { return _terraces; }
                set { _terraces = value; }
            }

            [XmlElement]
            public GenericNode<int> Basic
            {
                get { return _basic; }
                set { _basic = value; }
            }

            [XmlElement]
            public GenericNode<int> Roof
            {
                get { return _roof; }
                set { _roof = value; }
            }

            [XmlElement]
            public GenericNode<int> VIP
            {
                get { return _vip; }
                set { _vip = value; }
            }

            #endregion
        }
    }
}