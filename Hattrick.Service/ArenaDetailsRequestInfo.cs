using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hattrick.Service
{
    public class ArenaDetailsRequestInfo : BaseRequestInfo
    {
        #region Enumerations

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

        #region Properties

        public int ArenaId { get; set; }

        public StatsTypeEnum StatsType { get; set; }

        public MatchTypeEnum MatchType { get; set; }

        public DateTime FirstDate { get; set; }

        public DateTime LastDate { get; set; }

        public int StatsLeagueID { get; set; }

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