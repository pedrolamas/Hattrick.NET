using System;
using Hattrick.Service.BaseClasses;

namespace Hattrick.Service.Requests
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
    }
}