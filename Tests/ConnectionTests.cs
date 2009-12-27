using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;
using Gallio.Framework;
using Hattrick.Service;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;

namespace Tests
{

    [TestFixture]
    public class ConnectionTest
    {
        private string Username = "";
        private string SecurityCode = "";
        private string ChppId = "";
        private string ChppKey = "";
        private Connection hattrickBroker;

        public ConnectionTest()
        {
            try
            {
                System.Xml.XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"));

                Username = xmlDoc.GetElementsByTagName("username")[0].InnerText;
                SecurityCode = xmlDoc.GetElementsByTagName("securitycode")[0].InnerText;
                ChppId = xmlDoc.GetElementsByTagName("chppid")[0].InnerText;
                ChppKey = xmlDoc.GetElementsByTagName("chppkey")[0].InnerText;

                hattrickBroker = new Hattrick.Service.Connection("Hattrick Module Suite for DotNetNuke", ChppId, ChppKey);
            }
            catch
            {
                throw new Exception("Copy config.xml file to '{0}' and fill with your CHPP details.");
            }
        }

        private bool doConnect()
        {
            if (!hattrickBroker.IsConnected)
            {
                return hattrickBroker.Connect().RecommendedUrl.Value.Length > 0;
            }
            else
            {
                return false;
            }
        }

        private bool doLogin()
        {
            if (!hattrickBroker.IsAuthenticated)
            {
                return hattrickBroker.LogIn(Username, SecurityCode).IsAuthenticated.Value;
            }
            else
            {
                return false;
            }
        }

        private void doLogout()
        {
            if (!hattrickBroker.IsAuthenticated)
            {
                hattrickBroker.LogOut();
            }
        }

        [Test]
        public void ConnectTest()
        {
            hattrickBroker.Connect();

            Assert.AreNotEqual<string>(hattrickBroker.ServerUrl, string.Empty);
        }

        [Test]
        [DependsOn("ConnectTest")]
        public void LoginTest()
        {
            if (!hattrickBroker.IsConnected) hattrickBroker.Connect();

            LoginResponseInfo responseInfo = hattrickBroker.LogIn(Username, SecurityCode);

            Assert.IsTrue(responseInfo.IsAuthenticated.Value);
        }

        [Test]
        [DependsOn("ConnectTest")]
        [DependsOn("LoginTest")]
        [Row(1223640, "Nou Kampi")]
        [Row(0, "Users own arena")]
        public void GetArenaDetailsTest(int arenaId)
        {
            // Connect if not already connected
            doConnect();
            // Login if not already logged in
            bool localLogin = doLogin();

            if (arenaId <= 0)
            {
                ArenaDetailsResponseInfo arenaDetails = hattrickBroker.GetArenaDetails();
                Assert.IsNotNull(arenaDetails.Arena.ArenaName, string.Format("Arena of user has ID {0} and is called {1}", arenaDetails.Arena.ArenaId.Value, arenaDetails.Arena.ArenaName.Value));
            }
            else
            {
                ArenaDetailsResponseInfo arenaDetails = hattrickBroker.GetArenaDetails(new ArenaDetailsRequestInfo() { ArenaId = arenaId });
                Assert.IsNotNull(arenaDetails.Arena.ArenaName, String.Format("Arena with ID {0}: {1}", arenaId, arenaDetails.Arena.ArenaName.Value));
            }

            // Logout if we logged on too
            if (localLogin) doLogout();
        }

        [Test]
        [DependsOn("ConnectTest")]
        [DependsOn("LoginTest")]
        [Row(0, "User's own region")]
        [Row(895, "Region Kuala Lumpur, Malaysia")]
        public void GetRegionDetailsTest(int regionId)
        {
            // Connect if not already connected
            doConnect();
            // Login if not already logged in
            bool localLogin = doLogin();

            if (regionId <= 0)
                Assert.IsNotNull(hattrickBroker.GetRegionDetails().League);
            else
                Assert.IsNotNull(hattrickBroker.GetRegionDetails(regionId).League);

            // Logout if we logged on too
            if (localLogin) doLogout();
        }

        [Test]
        [Description("Template test. Also functions as dependancy for logoutTest")]
        [DependsOn("ConnectTest")]
        [DependsOn("LoginTest")]
        public void TemplateTest()
        {
            // Connect if not already connected
            doConnect();
            // Login if not already logged in
            bool localLogin = doLogin();

            Assert.IsTrue(true);

            // Logout if we logged on too
            if (localLogin) doLogout();
        }

        [Test]
        [DependsOn("TemplateTest")]
        public void LogoutTest()
        {
            // Connect if not already connected
            doConnect();
            // Login if not already logged in
            bool localLogin = doLogin();

            Assert.IsFalse(hattrickBroker.LogOut().IsAuthenticated.Value);
        }
    }
}
