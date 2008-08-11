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
            ConnectionBroker hattrickBroker = new Hattrick.Service.ConnectionBroker();

            hattrickBroker.Connect(delegate(ConnectionDetailsResponseInfo connectionDetails)
            {
                hattrickBroker.Login(txtUsername.Text, txtSecurityCode.Text, delegate(BaseResponseInfo responseInfo)
                {
                    hattrickBroker.GetRegionDetails(delegate(RegionDetailsResponseInfo regionDetails)
                    {
                        MessageBox.Show(regionDetails.League.LeagueName.Value);
                    });

                    hattrickBroker.GetArenaDetails(delegate(ArenaDetailsResponseInfo arenaDetails)
                    {
                        MessageBox.Show(arenaDetails.Arena.ArenaId.Value.ToString());
                    });
                });
            });
        }
    }
}