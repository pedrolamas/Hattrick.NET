using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Hattrick.Service.BaseClasses;
using Hattrick.Service.Components;
using Hattrick.Service.Requests;
using Hattrick.Service.Responses;

namespace Hattrick.Service
{
    public delegate void OnResponse<T>(T response) where T : BaseResponseInfo;

    public class Connection
    {
        private string _serverUrl = string.Empty;
        private Dictionary<string, string> _serverCookies = new Dictionary<string, string>();
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

        public string ServerCookies
        {
            get
            {
                var retval = string.Empty;
                foreach (var cookie in _serverCookies)
                {
                    retval += string.Format("{0}={1};", cookie.Key, cookie.Value);
                }
                return retval + " HttpOnly";
            }
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                var cookies = value;
                foreach (var cookie in cookies.Split(';'))
                {
                    var keyval = cookie.Split('=');

                    if (keyval.Length == 2)
                    {
                        _serverCookies[keyval[0]] = keyval[1];
                    }
                }
            }
        }

        public bool IsConnected { get; set; }
        public bool IsAuthenticated { get; set; }

        #endregion

        public Connection(string userAgent, string chppId, string chppKey)
        {
            UserAgent = userAgent;
            ChppId = chppId;
            ChppKey = chppKey;
        }

        #region Implemented Requests

        #region /chppxml.axd?file=servers

        public void Connect(OnResponse<ConnectionDetailsResponseInfo> onConnect)
        {
            DoRequest("http://www.hattrick.org/chppxml.axd?file=servers", delegate(ConnectionDetailsResponseInfo connectionDetails)
                                                                              {
                                                                                  _serverUrl = connectionDetails.RecommendedUrl.Value;
                                                                                  _serverDate = connectionDetails.FetchedDate.Value;
                                                                                  IsConnected = true;

                                                                                  if (onConnect != null) onConnect(connectionDetails);
                                                                              });
        }
        public ConnectionDetailsResponseInfo Connect()
        {
            ConnectionDetailsResponseInfo connectionDetails;
            connectionDetails = DoRequest<ConnectionDetailsResponseInfo>("http://www.hattrick.org/chppxml.axd?file=servers");

            _serverUrl = connectionDetails.RecommendedUrl.Value;
            _serverDate = connectionDetails.FetchedDate.Value;

            IsConnected = true;

            return connectionDetails;
        }

        #endregion

        #region /chppxml.axd?file=login
        private string LoginUrl(string username, string securityCode)
        {
            return "/chppxml.axd?file=login&actionType=login&loginname=" + username + "&readonlypassword=" +
                   securityCode + "&chppID=" + ChppId + "&chppKey=" + ChppKey;
        }
        public void LogIn(string username, string securityCode, OnResponse<LoginResponseInfo> onLogIn)
        {
            DoRequest(LoginUrl(username, securityCode), delegate(LoginResponseInfo loginResponse)
                                                            {
                                                                IsAuthenticated = (loginResponse.IsAuthenticated.Value);

                                                                if (onLogIn != null) onLogIn(loginResponse);
                                                            });
        }
        public LoginResponseInfo LogIn(string username, string securityCode)
        {
            return DoRequest<LoginResponseInfo>(LoginUrl(username, securityCode));
        }

        private string LogOutUrl()
        {
            return "/chppxml.axd?file=login&actionType=logout";
        }
        public void LogOut(OnResponse<LoginResponseInfo> onLogOut)
        {
            DoRequest(LogOutUrl(), delegate(LoginResponseInfo loginResponseInfo)
                                       {
                                           IsAuthenticated = (loginResponseInfo.IsAuthenticated.Value);

                                           if (onLogOut != null) onLogOut(loginResponseInfo);
                                       });
        }
        public LoginResponseInfo LogOut()
        {
            var retval = DoRequest<LoginResponseInfo>(LogOutUrl());

            IsAuthenticated = retval.IsAuthenticated.Value;

            return retval;
        }

        #endregion

        #region /chppxml.axd?file=achievements
        public string GetAchievementsUrl(AchievementsRequestInfo achievementsRequestInfo)
        {
            string sUrl = "/chppxml.axd?file=achievements";

            if (achievementsRequestInfo.UserId != 0) sUrl += "&userID=" + achievementsRequestInfo.UserId.ToString();

            return sUrl;
        }
        public void GetAchievements(OnResponse<AchievementsResponseInfo> onGetAchievements)
        {
            GetAchievements(new AchievementsRequestInfo(), onGetAchievements);
        }
        public void GetAchievements(AchievementsRequestInfo achievementsRequestInfo, OnResponse<AchievementsResponseInfo> onGetAchievements)
        {
            DoRequest(GetAchievementsUrl(achievementsRequestInfo), onGetAchievements);
        }
        public AchievementsResponseInfo GetAchievements()
        {
            return GetAchievements(new AchievementsRequestInfo());
        }
        public AchievementsResponseInfo GetAchievements(AchievementsRequestInfo achievementsRequestInfo)
        {
            return DoRequest<AchievementsResponseInfo>(GetAchievementsUrl(achievementsRequestInfo));
        }
        #endregion

        #region /chppxml.axd?file=arenaDetails
        /// <summary>
        /// Get the parametrised URL
        /// </summary>
        /// <param name="arenaDetailsRequestInfo"></param>
        /// <returns></returns>
        private string GetArenaDetailsUrl(ArenaDetailsRequestInfo arenaDetailsRequestInfo)
        {
            string sUrl = "/chppxml.axd?file=arenaDetails";

            if (arenaDetailsRequestInfo.ArenaId != 0) sUrl += "&arenaID=" + arenaDetailsRequestInfo.ArenaId;
            if (arenaDetailsRequestInfo.StatsType != ArenaDetailsRequestInfo.StatsTypeEnum.MyArena) sUrl += "&StatsType=" + arenaDetailsRequestInfo.StatsType.ToString();
            if (arenaDetailsRequestInfo.MatchType != ArenaDetailsRequestInfo.MatchTypeEnum.All) sUrl += "&MatchType=" + arenaDetailsRequestInfo.MatchType.ToString();
            if (arenaDetailsRequestInfo.FirstDate != DateTime.MinValue) sUrl += "&FirstDate=" + arenaDetailsRequestInfo.FirstDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.LastDate != DateTime.MinValue) sUrl += "&LastDate=" + arenaDetailsRequestInfo.LastDate.ToString("yyyy-MM-dd HH:mm:ss");
            if (arenaDetailsRequestInfo.StatsLeagueID != 0) sUrl += "&StatsLeagueID=" + arenaDetailsRequestInfo.StatsLeagueID;

            return sUrl;
        }
        public void GetArenaDetails(OnResponse<ArenaDetailsResponseInfo> onGetArenaDetails)
        {
            GetArenaDetails(new ArenaDetailsRequestInfo(), onGetArenaDetails);
        }
        public void GetArenaDetails(ArenaDetailsRequestInfo arenaDetailsRequestInfo, OnResponse<ArenaDetailsResponseInfo> onGetArenaDetails)
        {
            DoRequest(GetArenaDetailsUrl(arenaDetailsRequestInfo), onGetArenaDetails);
        }
        public ArenaDetailsResponseInfo GetArenaDetails()
        {
            return GetArenaDetails(new ArenaDetailsRequestInfo());
        }
        public ArenaDetailsResponseInfo GetArenaDetails(ArenaDetailsRequestInfo arenaDetailsRequestInfo)
        {
            return DoRequest<ArenaDetailsResponseInfo>(GetArenaDetailsUrl(arenaDetailsRequestInfo));
        }

        #endregion

        #region /chppxml.axd?file=alliances

        public string GetAlliancesUrl(AlliancesRequestInfo alliancesRequestInfo)
        {
            string sUrl = "/chppxml.axd?file=alliances&version=1.2";

            sUrl += "&SearchFor=" + alliancesRequestInfo.SearchFor;
            if (alliancesRequestInfo.PageIndex != 0) sUrl += "&PageIndex=" + alliancesRequestInfo.PageIndex.ToString();
            if (alliancesRequestInfo.SearchLanguageID != 0) sUrl += "&SearchLanguageID=" + alliancesRequestInfo.SearchLanguageID.ToString();
            if (alliancesRequestInfo.SearchType != AlliancesRequestInfo.SearchTypeEnum.NameBeginsWith) sUrl += "&SearchType=" + ((int)alliancesRequestInfo.SearchType).ToString();
            return sUrl;
        }

        public void GetAlliances(OnResponse<AlliancesResponseInfo> onGetAlliances)
        {
            GetAlliances(new AlliancesRequestInfo(), onGetAlliances);
        }

        public void GetAlliances(AlliancesRequestInfo alliancesRequestInfo,
                         OnResponse<AlliancesResponseInfo> onGetAlliances)
        {
            DoRequest(GetAlliancesUrl(alliancesRequestInfo), onGetAlliances);
        }

        public AlliancesResponseInfo GetAlliances()
        {
            return GetAlliances(new AlliancesRequestInfo());
        }

        public AlliancesResponseInfo GetAlliances(AlliancesRequestInfo alliancesRequestInfo)
        {
            return DoRequest<AlliancesResponseInfo>(GetAlliancesUrl(alliancesRequestInfo));
        }

        #endregion

        #region /chppxml.axd?file=allianceDetails

        //public string GetAllianceDetailsUrl(AllianceDetailsRequestInfo allianceDetailsRequestInfo)
        //{
        //    string sUrl = "/chppxml.axd?file=allianceDetails&version=1.4";

        //    // if (allianceDetailsRequestInfo.UserId != 0) sUrl += "&userID=" + allianceDetailsRequestInfo.UserId.ToString();

        //    return sUrl;
        //}

        //public void GetAllianceDetails(OnResponse<AllianceDetailsResponseInfo> onGetAllianceDetails)
        //{
        //    GetAllianceDetails(new AllianceDetailsRequestInfo(), onGetAllianceDetails);
        //}

        //public void GetAllianceDetails(AllianceDetailsRequestInfo allianceDetailsRequestInfo,
        //                 OnResponse<AllianceDetailsResponseInfo> onGetAllianceDetails)
        //{
        //    DoRequest(GetAllianceDetailsUrl(allianceDetailsRequestInfo), onGetAllianceDetails);
        //}

        //public AllianceDetailsResponseInfo GetAllianceDetails()
        //{
        //    return GetAllianceDetails(new AllianceDetailsRequestInfo());
        //}

        //public AllianceDetailsResponseInfo GetAllianceDetails(AllianceDetailsRequestInfo allianceDetailsRequestInfo)
        //{
        //    return DoRequest<AllianceDetailsResponseInfo>(GetAllianceDetailsUrl(allianceDetailsRequestInfo));
        //}

        #endregion

        #region /chppxml.axd?file=club

        public string GetClubUrl(ClubRequestInfo clubRequestInfo)
        {
            string sUrl = "/chppxml.axd?file=club";

            // if (clubRequestInfo.UserId != 0) sUrl += "&userID=" + clubRequestInfo.UserId.ToString();

            return sUrl;
        }

        public void GetClub(OnResponse<ClubResponseInfo> onGetClub)
        {
            GetClub(new ClubRequestInfo(), onGetClub);
        }

        public void GetClub(ClubRequestInfo clubRequestInfo, OnResponse<ClubResponseInfo> onGetClub)
        {
            DoRequest(GetClubUrl(clubRequestInfo), onGetClub);
        }

        public ClubResponseInfo GetClub()
        {
            return GetClub(new ClubRequestInfo());
        }

        public ClubResponseInfo GetClub(ClubRequestInfo clubRequestInfo)
        {
            return DoRequest<ClubResponseInfo>(GetClubUrl(clubRequestInfo));
        }

        #endregion

        #region /chppxml.axd?file=economy

        public string GetEconomyUrl(EconomyRequestInfo economyRequestInfo)
        {
            string sUrl = "/chppxml.axd?file=economy";

            // if (economyRequestInfo.UserId != 0) sUrl += "&userID=" + economyRequestInfo.UserId.ToString();

            return sUrl;
        }

        public void GetEconomy(OnResponse<EconomyResponseInfo> onGetEconomy)
        {
            GetEconomy(new EconomyRequestInfo(), onGetEconomy);
        }

        public void GetEconomy(EconomyRequestInfo economyRequestInfo, OnResponse<EconomyResponseInfo> onGetEconomy)
        {
            DoRequest(GetEconomyUrl(economyRequestInfo), onGetEconomy);
        }

        public EconomyResponseInfo GetEconomy()
        {
            return GetEconomy(new EconomyRequestInfo());
        }

        public EconomyResponseInfo GetEconomy(EconomyRequestInfo economyRequestInfo)
        {
            return DoRequest<EconomyResponseInfo>(GetEconomyUrl(economyRequestInfo));
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

        #region /chppxml.axd?file=regionDetails
        private string GetRegionDetailsUrl(int regionID)
        {
            string sUrl = "/chppxml.axd?file=regionDetails";

            if (regionID != 0) sUrl += "&regionID=" + regionID;
            return sUrl;
        }
        public void GetRegionDetails(OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            GetRegionDetails(0, onGetRegionDetails);
        }
        public void GetRegionDetails(int regionID, OnResponse<RegionDetailsResponseInfo> onGetRegionDetails)
        {
            string sUrl = GetRegionDetailsUrl(regionID);

            DoRequest(sUrl, onGetRegionDetails);
        }
        public RegionDetailsResponseInfo GetRegionDetails()
        {
            return GetRegionDetails(0);
        }
        public RegionDetailsResponseInfo GetRegionDetails(int regionID)
        {
            string sUrl = GetRegionDetailsUrl(regionID);

            return DoRequest<RegionDetailsResponseInfo>(sUrl);
        }
        #endregion

        #endregion

        #region Request Methods

        /// <summary>
        /// Perform async request at Hattrick CHPP Service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="onResponse"></param>
        public void DoRequest<T>(string url, OnResponse<T> onResponse) where T : BaseResponseInfo
        {
            HttpWebRequest cRequest = GetWebRequest(url);

            try
            {
                cRequest.BeginGetResponse(delegate(IAsyncResult asyncResult)
                    {
                        HttpWebResponse cResponse = (HttpWebResponse)cRequest.EndGetResponse(asyncResult);

                        if (onResponse != null)
                        {
                            onResponse(ProcessWebResponse<T>(cResponse));
                        }

                    }, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Perform sync request at Hattrick CHPP Service
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T DoRequest<T>(string url)
        {
            HttpWebRequest cRequest = GetWebRequest(url);

            HttpWebResponse cResponse = (HttpWebResponse)cRequest.GetResponse();

            return ProcessWebResponse<T>(cResponse);
        }

        private HttpWebRequest GetWebRequest(string url)
        {
            if (_serverUrl != string.Empty && !url.StartsWith("http://")) url = _serverUrl + url;

            HttpWebRequest cRequest = (HttpWebRequest)WebRequest.Create(url);

            cRequest.UserAgent = UserAgent;
            cRequest.Headers.Add("Cookie", ServerCookies);
            return cRequest;
        }

        private T ProcessWebResponse<T>(HttpWebResponse cResponse)
        {
            ServerCookies = cResponse.Headers.Get("Set-Cookie");

            string sResponse;

            using (StreamReader strResponseReader = new StreamReader(cResponse.GetResponseStream()))
            {
                sResponse = strResponseReader.ReadToEnd();
            }

            // Find out if errors have occurred
            XmlSerializer cXmlSerializer = new XmlSerializer(typeof(ErrorDetailsResponseInfo));
            try
            {
                // We'll deserialize the responsestring to an ErrorDetailsResponseInfo object to see if
                // something went wrong
                using (StringReader strResponseReader = new StringReader(sResponse))
                {
                    ErrorDetailsResponseInfo cErrorDetailsResponseInfo = (ErrorDetailsResponseInfo)cXmlSerializer.Deserialize(strResponseReader);

                    if (cErrorDetailsResponseInfo.Error != null)
                    {
                        throw new HattrickException(cErrorDetailsResponseInfo.Error.Value);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            using (StringReader strResponseReader = new StringReader(sResponse))
            {
                cXmlSerializer = new XmlSerializer(typeof(T));

                return (T)cXmlSerializer.Deserialize(strResponseReader);
            }
        }

        #endregion
    }
}