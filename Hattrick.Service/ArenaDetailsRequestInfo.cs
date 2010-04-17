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
    }
}