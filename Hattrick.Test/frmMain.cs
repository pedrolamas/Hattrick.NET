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
        private const long BASE_TABLE_ID = (long)0x40000001;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btDoIt_Click(object sender, EventArgs e)
        {
            MessageBox.Show((BASE_TABLE_ID).ToString());

            //ConnectionBroker hattrickBroker = new Hattrick.Service.ConnectionBroker();

            //hattrickBroker.Connect(delegate(ConnectionDetailsResponseInfo connectionDetails)
            //{
            //    hattrickBroker.Login(txtUsername.Text, txtSecurityCode.Text, delegate(BaseResponseInfo responseInfo)
            //    {
            //        hattrickBroker.GetRegionDetails(delegate(RegionDetailsResponseInfo regionDetails)
            //        {
            //            MessageBox.Show(regionDetails.League.LeagueName.Value);
            //        });

            //        new ArenaDetailsRequest()
            //        {
            //            ArenaId = 100
            //        }
            //        .GetArenaDetails(hattrickBroker, delegate(ArenaDetailsResponseInfo arenaDetails)
            //        {
            //            MessageBox.Show(arenaDetails.Arena.ArenaName.Value);
            //        });

            //        hattrickBroker.GetArenaDetails(new ArenaDetailsRequestInfo() { ArenaId = 100 }, delegate(ArenaDetailsResponseInfo arenaDetails)
            //        {
            //            MessageBox.Show(arenaDetails.Arena.ArenaName.Value);
            //        });
            //    });
            //});
        }
    }
}