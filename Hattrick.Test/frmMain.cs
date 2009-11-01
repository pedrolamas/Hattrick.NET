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

            try
            {
                txtUsername.Text=Application.UserAppDataRegistry.GetValue("UserId") as string;
                txtSecurityCode.Text = Application.UserAppDataRegistry.GetValue("SecurityCode") as string;
                txtChppId.Text = Application.UserAppDataRegistry.GetValue("ChppId") as string;
                txtChppKey.Text = Application.UserAppDataRegistry.GetValue("ChppKey") as string;

            }
            catch
            {
            }
        }

        private void btDoIt_Click(object sender, EventArgs e)
        {
            if(chkSave.Checked)
            {
                Application.UserAppDataRegistry.SetValue("UserId",txtUsername.Text);
                Application.UserAppDataRegistry.SetValue("SecurityCode", txtSecurityCode.Text);
                Application.UserAppDataRegistry.SetValue("ChppId", txtChppId.Text);
                Application.UserAppDataRegistry.SetValue("ChppKey", txtChppKey.Text);
            }

            Connection hattrickBroker = new Hattrick.Service.Connection("Hattrick Module Suite for DotNetNuke", txtChppId.Text, txtChppKey.Text);

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