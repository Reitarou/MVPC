using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MVPClocker.Properties;

namespace MVPClocker
{
    public partial class KilledAtDlg : Form
    {
        private static Mob m_Mob;

        public KilledAtDlg()
        {
            InitializeComponent();
        }

        private void DoInit()
        {
            dtPicker.Value = DateTime.Now;
        }

        private void DoCommit()
        {
            m_Mob.LastCheck = dtPicker.Value;
            m_Mob.Status = Resources.sKilled;
        }

        public static bool Execute(ref Mob mob)
        {
            using (var dlg = new KilledAtDlg())
            {
                m_Mob = new Mob();
                m_Mob.Assign(mob);
                dlg.DoInit();
                while (true)
                {
                    switch (dlg.ShowDialog())
                    {
                        case DialogResult.Cancel:
                            return false;

                        case DialogResult.OK:
                            dlg.DoCommit();
                            mob.Assign(m_Mob);
                            return true;

                        case DialogResult.Retry:
                            break;

                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
