using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using Hattrick.Service;

namespace Hattrick.Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btDoIt_Click(object sender, EventArgs e)
        {
            ConnectionBroker hattrickBroker = new Hattrick.Service.ConnectionBroker("Hattrick.net 0.1", txtChppId.Text, txtChppKey.Text);

            hattrickBroker.Connect(delegate(ConnectionDetailsResponseInfo connectionDetails)
            {
                hattrickBroker.LogIn(txtUsername.Text, txtSecurityCode.Text, delegate(LoginResponseInfo responseInfo)
                {
                    hattrickBroker.GetRegionDetails(delegate(RegionDetailsResponseInfo regionDetails)
                    {
                        MessageBox.Show(regionDetails.League.LeagueName.Value);
                    });

                    hattrickBroker.GetArenaDetails(new ArenaDetailsRequestInfo() { ArenaId = 100 }, delegate(ArenaDetailsResponseInfo arenaDetails)
                    {
                        MessageBox.Show(arenaDetails.Arena.ArenaName.Value);
                    });

                    //new ArenaDetailsRequest()
                    //{
                    //    ArenaId = 100
                    //}
                    //.GetArenaDetails(hattrickBroker, delegate(ArenaDetailsResponseInfo arenaDetails)
                    //{
                    //    MessageBox.Show(arenaDetails.Arena.ArenaName.Value);
                    //});

                });
            });
        }
    }
}