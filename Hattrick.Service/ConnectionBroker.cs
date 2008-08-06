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
    public delegate void OnResponse<T>(T response);

    public class ConnectionBroker
    {
        private string _serverUrl = string.Empty;
        private string _serverCookies = string.Empty;
        private DateTime _serverDate;

        #region Properties

        public string ServerUrl
        {
            get { return _serverUrl; }
        }

        public DateTime ServerDate
        {
            get { return _serverDate; }
        }

        #endregion

        public void Connect(OnResponse<ConnectionDetailsResponseInfo> onConnect)
        {
            DoRequest("http://www.hattrick.org/common/menu.asp?outputType=XML", delegate(ConnectionDetailsResponseInfo connectionDetails)
            {
                _serverUrl = connectionDetails.RecommendedUrl;
                _serverDate = connectionDetails.FetchedDate.Value;

                if (onConnect != null) onConnect(connectionDetails);
            });
        }

        public void Login(string username, string password, OnResponse<BaseResponseInfo> onLogin)
        {
            DoRequest("/common/default.asp?outputType=XML&actionType=login&loginType=CHPP&loginName=" + username + "&readonlyPassword=" + password, onLogin);
        }

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

        //public void GetLiveMatches(OnResponse<XDocument> onGetLiveMatches)
        //{
        //    DoRequest("/common/chpp/chppxml.axd?file=live&actionType=viewNew", onGetLiveMatches);
        //}

        //public void DeleteLiveMatch(int matchID, OnResponse<XDocument> onDeleteLiveMatch)
        //{
        //    DoRequest("/common/chpp/chppxml.axd?file=live&actionType=deleteMatch&matchID=" + matchID, onDeleteLiveMatch);
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

        public void GetRegionDetails(OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            DoRequest("/common/regionDetails.asp?outputType=XML&actionType=view", onGetRegionDetails);
        }
        public void GetRegionDetails(int regionID, OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            string sUrl = "/common/regionDetails.asp?outputType=XML&actionType=view";

            if (regionID != 0) sUrl += "&regionID=" + regionID;

            DoRequest(sUrl, onGetRegionDetails);
        }

        public void GetArenaDetails(OnResponse<ArenaDetailsResponseInfo> onGetArenaDetails)
        {
            DoRequest("/common/arenaDetails.asp?outputType=XML&actionType=view", onGetArenaDetails);
        }
        public void GetArenaDetails(ArenaDetailsRequestInfo arenaDetailsRequestInfo, OnResponse<XDocument> onGetArenaDetails)
        {
            string sUrl = "/common/arenaDetails.asp?outputType=XML&actionType=view";

            if (arenaDetailsRequestInfo.ArenaId != 0) sUrl += "&arenaID=" + arenaDetailsRequestInfo.ArenaId;
            if (arenaDetailsRequestInfo.StatsType != ArenaDetailsRequestInfo.StatsTypeEnum.MyArena) sUrl += "&StatsType=" + arenaDetailsRequestInfo.StatsType.ToString();
            if (arenaDetailsRequestInfo.MatchType != ArenaDetailsRequestInfo.MatchTypeEnum.All) sUrl += "&MatchType=" + arenaDetailsRequestInfo.MatchType.ToString();
            if (arenaDetailsRequestInfo.FirstDate != DateTime.MinValue) sUrl += "&FirstDate=" + arenaDetailsRequestInfo.FirstDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.LastDate != DateTime.MinValue) sUrl += "&LastDate=" + arenaDetailsRequestInfo.LastDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.StatsLeagueID != 0) sUrl += "&StatsLeagueID=" + arenaDetailsRequestInfo.StatsLeagueID;

            DoRequest(sUrl, onGetArenaDetails);
        }

        //public void GetClubDetails(OnResponse<XDocument> onGetClubDetails)
        //{
        //    DoRequest("/common/club.asp?outputType=XML&actionType=view", onGetClubDetails);
        //}

        //public void GetChallanges(OnResponse<XDocument> onGetChallanges)
        //{
        //    DoRequest("/common/challanges.asp?outputType=XML&actionType=view", onGetChallanges);
        //}

        //public void GetBookmarks(int bookmarkType, OnResponse<XDocument> onGetBookmarks)
        //{
        //    DoRequest("/common/chppxml.axd?file=bookmarks&BookmarkTypeID=" + bookmarkType, onGetBookmarks);
        //}

        public void DoRequest<T>(string url, OnResponse<T> onResponse)
        {
            if (_serverUrl != string.Empty) url = _serverUrl + url;

            WebRequest cRequest = WebRequest.Create(url);

            cRequest.Headers.Add("Cookie", _serverCookies);

            cRequest.BeginGetResponse(delegate(IAsyncResult asyncResult)
            {
                WebResponse cResponse = cRequest.EndGetResponse(asyncResult);

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