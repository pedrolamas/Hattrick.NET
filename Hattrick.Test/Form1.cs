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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //ArenaDetailsResponseInfo s = new ArenaDetailsResponseInfo();
            //System.Text.StringBuilder ss = new System.Text.StringBuilder();
            //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(ArenaDetailsResponseInfo));
            //x.Serialize(new System.IO.StringWriter(ss), s);

            //MessageBox.Show(ss.ToString());

            //return;

            ConnectionBroker hattrickBroker = new Hattrick.Service.ConnectionBroker();

            hattrickBroker.Connect(delegate(ConnectionDetailsResponseInfo connectionDetails)
            {
               
                    hattrickBroker.GetRegionDetails(delegate(RegionDetailsResponseInfo regionDetails)
                    {
                        MessageBox.Show(regionDetails.League.LeagueName.Value );
                    });
                    hattrickBroker.GetArenaDetails(delegate(ArenaDetailsResponseInfo arenaDetails)
                    {
                        MessageBox.Show(arenaDetails.Arena.ArenaId.Value.ToString());
                    });
          
            });
        }
    }
}