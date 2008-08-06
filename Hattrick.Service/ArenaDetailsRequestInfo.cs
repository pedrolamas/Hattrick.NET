using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hattrick.Service
{
    public class ArenaDetailsRequestInfo : BaseRequestInfo
    {
        #region Enums

        public enum StatsTypeEnum
        {
            MyArena,
            OthersArenas
        }

        public enum MatchTypeEnum
        {
            All,
            LeagueOnly,
            CompOnly,
            FriendlyOnly
        }

        #endregion

        private int _arenaId;
        private StatsTypeEnum _statsType;
        private MatchTypeEnum _matchType;
        private DateTime _firstDate;
        private DateTime _lastDate;
        private int _statsLeagueID;

        #region Properties

        public int ArenaId
        {
            get { return _arenaId; }
            set { _arenaId = value; }
        }

        public StatsTypeEnum StatsType
        {
            get { return _statsType; }
            set { _statsType = value; }
        }

        public MatchTypeEnum MatchType
        {
            get { return _matchType; }
            set { _matchType = value; }
        }

        public DateTime FirstDate
        {
            get { return _firstDate; }
            set { _firstDate = value; }
        }

        public DateTime LastDate
        {
            get { return _lastDate; }
            set { _lastDate = value; }
        }

        public int StatsLeagueID
        {
            get { return _statsLeagueID; }
            set { _statsLeagueID = value; }
        }

        #endregion

        //public override void DoRequest(ConnectionBroker connectionBroker, OnResponse<ArenaDetailsResponseInfo> onResponse)
        //{
        //    string url = "/common/arenaDetails.asp?outputType=XML&actionType=view";

        //    if (_arenaId != 0) url += "&arenaID=" + _arenaId;
        //    if (_statsType != ArenaDetailsRequestInfo.StatsTypeEnum.MyArena) url += "&StatsType=" + _statsType.ToString();
        //    if (_matchType != ArenaDetailsRequestInfo.MatchTypeEnum.All) url += "&MatchType=" + _matchType.ToString();
        //    if (_firstDate != DateTime.MinValue) url += "&FirstDate=" + _firstDate.ToString("yyyy-MM-dd HH:mm:ss");
        //    if (_lastDate != DateTime.MinValue) url += "&LastDate=" + _lastDate.ToString("yyyy-MM-dd HH:mm:ss");
        //    if (_statsLeagueID != 0) url += "&StatsLeagueID=" + _statsLeagueID;

        //    connectionBroker.DoRequest2(url, onResponse);
        //}
    }
}