using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;
using Hattrick.Service;
using Hattrick.Service.Requests;
using Hattrick.Service.Responses;
using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    public class ConnectionTest
    {
        private string _username = "";
        private string _securityCode = "";
        private string _chppId = "";
        private string _chppKey = "";
        private Connection _hattrickBroker;

        private bool DoConnect()
        {
            if (!_hattrickBroker.IsConnected)
            {
                return _hattrickBroker.Connect().RecommendedUrl.Value.Length > 0;
            }
            else
            {
                return false;
            }
        }

        private bool DoLogin()
        {
            if (!_hattrickBroker.IsAuthenticated)
            {
                return _hattrickBroker.LogIn(_username, _securityCode).IsAuthenticated.Value;
            }
            else
            {
                return false;
            }
        }

        private void DoLogout()
        {
            if (!_hattrickBroker.IsAuthenticated)
            {
                _hattrickBroker.LogOut();
            }
        }

        [SetUp]
        public void Init()
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"));

                _username = xmlDoc.GetElementsByTagName("username")[0].InnerText;
                _securityCode = xmlDoc.GetElementsByTagName("securitycode")[0].InnerText;
                _chppId = xmlDoc.GetElementsByTagName("chppid")[0].InnerText;
                _chppKey = xmlDoc.GetElementsByTagName("chppkey")[0].InnerText;

                _hattrickBroker = new Hattrick.Service.Connection("Hattrick Module Suite for DotNetNuke", _chppId, _chppKey);
            }
            catch
            {
                throw new Exception("Copy config.xml file to '{0}' and fill with your CHPP details.");
            }

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Connect_ValidConfig_CanConnect()
        {
            _hattrickBroker.Connect();

            Assert.AreNotEqual(_hattrickBroker.ServerUrl, string.Empty);
        }

        [Test]
        public void LogIn_ValidCredentials_CanLogin()
        {
            if (!_hattrickBroker.IsConnected) _hattrickBroker.Connect();

            LoginResponseInfo responseInfo = _hattrickBroker.LogIn(_username, _securityCode);

            Assert.IsTrue(responseInfo.IsAuthenticated.Value);
        }

        [Test]
        [TestCase(1223640)]
        [TestCase(0)]
        public void GetArenaDetails_ValidArenaId_LoadsArena(int arenaId)
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            if (arenaId <= 0)
            {
                ArenaDetailsResponseInfo arenaDetails = _hattrickBroker.GetArenaDetails();
                Assert.IsNotNull(arenaDetails.Arena.ArenaName, string.Format("Arena of user has ID {0} and is called {1}", arenaDetails.Arena.ArenaId.Value, arenaDetails.Arena.ArenaName.Value));
            }
            else
            {
                ArenaDetailsResponseInfo arenaDetails = _hattrickBroker.GetArenaDetails(new ArenaDetailsRequestInfo() { ArenaId = arenaId });
                Assert.IsNotNull(arenaDetails.Arena.ArenaName, String.Format("Arena with ID {0}: {1}", arenaId, arenaDetails.Arena.ArenaName.Value));
            }

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        [TestCase(0)]
        [TestCase(895)]
        public void GetRegionDetails_ValidId_LoadsRegion(int regionId)
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            if (regionId <= 0)
                Assert.IsNotNull(_hattrickBroker.GetRegionDetails().League);
            else
                Assert.IsNotNull(_hattrickBroker.GetRegionDetails(regionId).League);

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        public void GetAchievements_LoggedIn_LoadsAchievements()
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();
            var result = _hattrickBroker.GetAchievements(new AchievementsRequestInfo());

            Assert.IsNotNull(result.AchievementList);
            Assert.Greater(result.AchievementList.Count, 0);

            // Logout if we logged on too););
            if (localLogin) DoLogout();
        }

        [Test]
        [TestCase("Bott")]
        [TestCase("Bare")]
        public void GetAlliances_SearchNameBeginsWith_HasResults(string searchString)
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            var result = _hattrickBroker.GetAlliances(
                new AlliancesRequestInfo()
                    {
                        SearchType = AlliancesRequestInfo.SearchTypeEnum.NameBeginsWith,
                        SearchFor = searchString
                    });
            Assert.Greater(result.Alliances.Count, 0);

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        public void GetClub_LoggedIn_LoadsStaffAndYouth()
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            var result = _hattrickBroker.GetClub();
    
            Assert.IsNotEmpty(result.Team.TeamName.ToString());

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        public void GetEconomy_LoggedIn_LoadsEconomyDetails()
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            var result = _hattrickBroker.GetEconomy();

            Assert.Greater(result.Team.IncomeSum.Value, 0);

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        [Ignore("Template test.")]
        public void TemplateTest()
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            Assert.IsTrue(true);

            // Logout if we logged on too
            if (localLogin) DoLogout();
        }

        [Test]
        public void LogoutTest()
        {
            // Connect if not already connected
            DoConnect();
            // Login if not already logged in
            bool localLogin = DoLogin();

            Assert.IsFalse(_hattrickBroker.LogOut().IsAuthenticated.Value);
        }
    }
}
