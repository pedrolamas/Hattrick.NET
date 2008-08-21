using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Hattrick.Service
{
    public delegate void OnResponse<T>(T response) where T : BaseResponseInfo;

    public class Connection
    {
        private string _serverUrl = string.Empty;
        private string _serverCookies = string.Empty;
        private DateTime _serverDate;

        #region Properties

        public string UserAgent { get; set; }

        public string ChppId { get; set; }

        public string ChppKey { get; set; }

        public string ServerUrl
        {
            get { return _serverUrl; }
        }

        public DateTime ServerDate
        {
            get { return _serverDate; }
        }

        #endregion

        public Connection(string userAgent, string chppId, string chppKey)
        {
            UserAgent = userAgent;
            ChppId = chppId;
            ChppKey = chppKey;
        }

        #region /chppxml.axd?file=achievements (TODO)

        public void GetAchievements(OnResponse<AchievementsResponseInfo> onGetAchievements)
        {
            GetAchievements(0, onGetAchievements);
        }

        public void GetAchievements(int userId, OnResponse<AchievementsResponseInfo> onGetAchievements)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=arenaDetails

        public void GetArenaDetails(OnResponse<ArenaDetailsResponseInfo> onGetArenaDetails)
        {
            GetArenaDetails(new ArenaDetailsRequestInfo(), onGetArenaDetails);
        }
        public void GetArenaDetails(ArenaDetailsRequestInfo arenaDetailsRequestInfo, OnResponse<ArenaDetailsResponseInfo> onGetArenaDetails)
        {
            string sUrl = "/chppxml.axd?file=arenaDetails";

            if (arenaDetailsRequestInfo.ArenaId != 0) sUrl += "&arenaID=" + arenaDetailsRequestInfo.ArenaId;
            if (arenaDetailsRequestInfo.StatsType != ArenaDetailsRequestInfo.StatsTypeEnum.MyArena) sUrl += "&StatsType=" + arenaDetailsRequestInfo.StatsType.ToString();
            if (arenaDetailsRequestInfo.MatchType != ArenaDetailsRequestInfo.MatchTypeEnum.All) sUrl += "&MatchType=" + arenaDetailsRequestInfo.MatchType.ToString();
            if (arenaDetailsRequestInfo.FirstDate != DateTime.MinValue) sUrl += "&FirstDate=" + arenaDetailsRequestInfo.FirstDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.LastDate != DateTime.MinValue) sUrl += "&LastDate=" + arenaDetailsRequestInfo.LastDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.StatsLeagueID != 0) sUrl += "&StatsLeagueID=" + arenaDetailsRequestInfo.StatsLeagueID;

            DoRequest(sUrl, onGetArenaDetails);
        }

        #endregion

        #region /chppxml.axd?file=alliances (TODO)

        public void GetAlliances(OnResponse<AlliancesResponseInfo> onGetAlliances)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=allianceDetails (TODO)

        public void GetAllianceDetails(OnResponse<AllianceDetailsResponseInfo> onGetAllianceDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=bookmarks (TODO)

        public void GetBookmarks(int bookmarkType, OnResponse<BookmarksResponseInfo> onGetBookmarks)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=challanges (TODO)

        public void GetChallanges(OnResponse<ChallangesResponseInfo> onGetChallanges)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=club

        public void GetClubDetails(OnResponse<ClubDetailsResponseInfo> onGetClubDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=cupMatches (TODO)

        public void GetCupMatches(OnResponse<CupMatchesResponseInfo> onGetCupMatches)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=economy (TODO)

        public void GetEconomy(OnResponse<EconomyResponseInfo> onGetEconomy)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=fans (TODO)

        public void GetFans(OnResponse<FansResponseInfo> onGetFans)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=leagueDetails (TODO)

        public void GetLeagueDetails(OnResponse<LeagueDetailsResponseInfo> onGetLeagueDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=leagueFixtures (TODO)

        public void GetLeagueFixtures(OnResponse<LeagueFixturesResponseInfo> onGetLeagueFixtures)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=live

        public void AddLiveMatch(int matchId, bool isYouth, OnResponse<LiveMatchesResponseInfo> onAddLiveMatch)
        {
            throw new NotImplementedException();
        }

        public void DeleteLiveMatch(int matchId, bool isYouth, OnResponse<LiveMatchesResponseInfo> onDeleteLiveMatch)
        {
            throw new NotImplementedException();
        }

        public void ClearLiveMatches(OnResponse<LiveMatchesResponseInfo> onClearLiveMatches)
        {
            throw new NotImplementedException();
        }

        public void GetLiveMatches(OnResponse<LiveMatchesResponseInfo> onGetLiveMatches)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=login

        public void LogIn(string username, string securityCode, OnResponse<LoginResponseInfo> onLogIn)
        {
            DoRequest("/chppxml.axd?file=login&actionType=login&loginname=" + username + "&readonlypassword=" + securityCode + "&chppID=" + ChppId + "&chppKey=" + ChppKey, onLogIn);
        }

        public void LogOut(OnResponse<LoginResponseInfo> onLogOut)
        {
            DoRequest("/chppxml.axd?file=login&actionType=logout", onLogOut);
        }

        #endregion

        #region /chppxml.axd?file=matches (TODO)

        public void GetMatches(OnResponse<MatchesResponseInfo> onGetMatches)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=matchesArchive (TODO)

        public void GetMatchesArchive(OnResponse<MatchesArchiveResponseInfo> onGetMatchesArchive)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=matchDetails (TODO)

        public void GetMatchDetails(OnResponse<MatchDetailsResponseInfo> onGetMatchDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=matchLineup (TODO)

        public void GetMatchLineup(OnResponse<MatchLineupResponseInfo> onGetMatchLineup)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=matchOrders (TODO)

        public void GetMatchOrders(OnResponse<MatchOrdersResponseInfo> onGetMatchOrders)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=players (TODO)

        public void GetPlayers(OnResponse<PlayersResponseInfo> onGetPlayers)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=playerDetails (TODO)

        public void GetPlayerDetails(OnResponse<PlayerDetailsResponseInfo> onGetPlayerDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=playerEvents (TODO)

        public void GetPlayerEvents(OnResponse<PlayerEventsResponseInfo> onGetPlayerEvents)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=regionDetails

        public void GetRegionDetails(OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            GetRegionDetails(0, onGetRegionDetails);
        }
        public void GetRegionDetails(int regionID, OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            string sUrl = "/chppxml.axd?file=regionDetails";

            if (regionID != 0) sUrl += "&regionID=" + regionID;

            DoRequest(sUrl, onGetRegionDetails);
        }

        #endregion

        #region /chppxml.axd?file=search (TODO)

        public void Search(OnResponse<SearchResponseInfo> onSearch)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=servers

        public void Connect(OnResponse<ConnectionDetailsResponseInfo> onConnect)
        {
            DoRequest("http://www.hattrick.org/chppxml.axd?file=servers", delegate(ConnectionDetailsResponseInfo connectionDetails)
            {
                _serverUrl = connectionDetails.RecommendedUrl.Value;
                _serverDate = connectionDetails.FetchedDate.Value;

                if (onConnect != null) onConnect(connectionDetails);
            });
        }

        #endregion

        #region /chppxml.axd?file=teamDetails (TODO)

        public void GetTeamDetails(OnResponse<TeamDetailsResponseInfo> onGetTeamDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=training (TODO)

        public void GetTraining(OnResponse<TrainingResponseInfo> onGetTraining)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=trainingEvents (TODO)

        public void GetTrainingEvents(OnResponse<TrainingEventsResponseInfo> onGetTrainingEvents)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=transfersTeam (TODO)

        public void GetTransfersTeam(OnResponse<TransfersTeamResponseInfo> onGetTransfersTeam)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region /chppxml.axd?file=transfersPlayer (TODO)

        public void GetTransfersPlayer(OnResponse<TransfersPlayerResponseInfo> onGetTransfersPlayer)
        {
            throw new NotImplementedException();
        }

        #endregion

        //public void GetTeamDetails(int teamID, OnResponse<XDocument> onGetTeamDetails)
        //{
        //    DoRequest("/common/teamDetails.asp?outputType=XML&actionType=view" + (teamID == 0 ? string.Empty : "&teamID=" + teamID), onGetTeamDetails);
        //}

        //public void GetMatches(int teamID, OnResponse<XDocument> onGetMatches)
        //{
        //    DoRequest("/common/chpp/chppxml.axd?file=matches" + (teamID == 0 ? "" : "&teamID=" + teamID), onGetMatches);
        //}

        //public void GetMatchDetails(int matchID, OnResponse<XDocument> onGetMatchDetails)
        //{
        //    DoRequest("/common/chpp/chppxml.axd?file=matchdetails&matchID=" + matchID, onGetMatchDetails);
        //}

        //public void GetPlayers(int teamID, OnResponse<XDocument> onGetPlayers)
        //{
        //    DoRequest("/common/players.asp?outputType=XML&actionType=view&orderBy=PlayerNumber&outputVersion=1.3" + (teamID == 0 ? "" : "&teamID=" + teamID), onGetPlayers);
        //}

        //public void GetPlayerDetails(int playerID, OnResponse<XDocument> onGetPlayerDetails)
        //{
        //    DoRequest("/common/playerDetails.asp?outputType=XML&actionType=view&playerID=" + playerID, onGetPlayerDetails);
        //}

        //public void AddLiveMatch(int matchID, OnResponse<XDocument> onAddLiveMatch)
        //{
        //    DoRequest("/common/chpp/chppxml.axd?file=live&actionType=addMatch&matchID=" + matchID, onAddLiveMatch);
        //}

        //public void GetLeagueDetails(int leagueUnitID, OnResponse<XDocument> onGetLeagueDetails)
        //{
        //    DoRequest("/common/leagueDetails.asp?outputType=XML&actionType=view" + (leagueUnitID == 0 ? "" : "&leagueLevelUnitID=" + leagueUnitID), onGetLeagueDetails);
        //}

        //public void GetEconomy(OnResponse<XDocument> onGetEconomy)
        //{
        //    DoRequest("/common/economy.asp?outputType=XML&actionType=view", onGetEconomy);
        //}

        //public void GetWorldDetails(OnResponse<XDocument> onGetWorldDetails)
        //{
        //    DoRequest("/common/chppxml.axd?file=worlddetails", onGetWorldDetails);
        //}

        public void DoRequest<T>(string url, OnResponse<T> onResponse) where T : BaseResponseInfo
        {
            if (_serverUrl != string.Empty) url = _serverUrl + url;

            HttpWebRequest cRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            cRequest.UserAgent = UserAgent;
            cRequest.Headers.Add("Cookie", _serverCookies);

            cRequest.BeginGetResponse(delegate(IAsyncResult asyncResult)
            {
                HttpWebResponse cResponse = (HttpWebResponse)cRequest.EndGetResponse(asyncResult);

                _serverCookies = cResponse.Headers.Get("Set-Cookie");

                string sResponse;

                using (StreamReader strResponseReader = new StreamReader(cResponse.GetResponseStream()))
                {
                    sResponse = strResponseReader.ReadToEnd();
                }

                XmlSerializer cXmlSerializer = new XmlSerializer(typeof(ErrorDetailsResponseInfo));

                try
                {
                    using (StringReader strResponseReader = new StringReader(sResponse))
                    {
                        ErrorDetailsResponseInfo cErrorDetailsResponseInfo = (ErrorDetailsResponseInfo)cXmlSerializer.Deserialize(strResponseReader);

                        throw new HattrickException(cErrorDetailsResponseInfo.Error.Value);
                    }
                }
                catch (HattrickException ex)
                {
                    throw ex;
                }
                catch
                {
                }

                if (onResponse != null)
                {
                    using (StringReader strResponseReader = new StringReader(sResponse))
                    {
                        cXmlSerializer = new XmlSerializer(typeof(T));

                        T cResponse2 = (T)cXmlSerializer.Deserialize(strResponseReader);

                        onResponse(cResponse2);
                    }
                }
            }, null);
        }
    }
}