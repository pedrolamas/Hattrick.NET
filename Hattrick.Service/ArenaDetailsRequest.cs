using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hattrick.Service
{
    public class ArenaDetailsRequest : BaseRequestInfo<ArenaDetailsResponseInfo>
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

        protected override string RequestUrl()
        {
            string sUrl = "/common/arenaDetails.asp?outputType=XML&actionType=view";

            if (ArenaId != 0) sUrl += "&arenaID=" + ArenaId;
            if (StatsType != ArenaDetailsRequest.StatsTypeEnum.MyArena) sUrl += "&StatsType=" + StatsType.ToString();
            if (MatchType != ArenaDetailsRequest.MatchTypeEnum.All) sUrl += "&MatchType=" + MatchType.ToString();
            if (FirstDate != DateTime.MinValue) sUrl += "&FirstDate=" + FirstDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (LastDate != DateTime.MinValue) sUrl += "&LastDate=" + LastDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (StatsLeagueID != 0) sUrl += "&StatsLeagueID=" + StatsLeagueID;

            return sUrl;
        }
    }
}