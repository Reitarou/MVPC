using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVPClocker.Properties;

namespace MVPClocker
{
    public partial class NotifierDlg : Form
    {
        public System.Media.SoundPlayer player = new System.Media.SoundPlayer("alarm.wav");
        public NotifierDlg()
        {
            InitializeComponent();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void NotifierDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            player.Stop();
        }
    }
}
