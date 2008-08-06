using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    [XmlRoot("HattrickData")]
    public class RegionDetailsResponseInfo : BaseResponseInfo
    {
        private LeagueDetails _league;

        #region Properties

        public LeagueDetails League
        {
            get { return _league; }
            set { _league = value; }
        }

        #endregion

        public class LeagueDetails
        {
            private GenericNode<int> _leagueId;
            private GenericNode<string> _leagueName;
            private RegionDetails _region = new RegionDetails();

            #region Properties

            [XmlElement("LeagueID")]
            public GenericNode<int> LeagueId
            {
                get { return _leagueId; }
                set { _leagueId = value; }
            }

            [XmlElement]
            public GenericNode<string> LeagueName
            {
                get { return _leagueName; }
                set { _leagueName = value; }
            }

            [XmlElement]
            public RegionDetails Region
            {
                get { return _region; }
                set { _region = value; }
            }

            #endregion
        }

        public class RegionDetails
        {
            private GenericNode<int> _regionId;
            private GenericNode<string> _regionName;
            private GenericNode<int> _weatherId;
            private GenericNode<int> _tomorrowWeatherId;
            private GenericNode<int> _numberOfUsers;
            private GenericNode<int> _numberOfUsersOnline;

            #region Properties

            [XmlElement("RegionID")]
            public GenericNode<int> RegionId
            {
                get { return _regionId; }
                set { _regionId = value; }
            }

            [XmlElement]
            public GenericNode<string> RegionName
            {
                get { return _regionName; }
                set { _regionName = value; }
            }

            [XmlElement("WeatherID")]
            public GenericNode<int> WeatherId
            {
                get { return _weatherId; }
                set { _weatherId = value; }
            }

            [XmlElement("TomorrowWeatherID")]
            public GenericNode<int> TomorrowWeatherId
            {
                get { return _tomorrowWeatherId; }
                set { _tomorrowWeatherId = value; }
            }

            public GenericNode<int> NumberOfUsers
            {
                get { return _numberOfUsers; }
                set { _numberOfUsers = value; }
            }

            public GenericNode<int> NumberOfUsersOnline
            {
                get { return _numberOfUsersOnline; }
                set { _numberOfUsersOnline = value; }
            }

            #endregion
        }
    }
}
