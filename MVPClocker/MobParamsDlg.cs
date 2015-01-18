using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MVPClocker
{
    public partial class MobParamsDlg : Form
    {
        private static Mob m_Mob;
        
        public MobParamsDlg()
        {
            InitializeComponent();
        }

        private void DoInit()
        {
            //tbID.Text = m_Mob.ID.ToString();
            tbName.Text = m_Mob.Name;
            tbRespCD.Text = m_Mob.RespCD.ToString();
        }

        private void DoCommit()
        {
            //m_Mob.ID = tbID.Text;
            m_Mob.Name = tbName.Text;
            m_Mob.RespCD = int.Parse(tbRespCD.Text);
        }

        public static bool Execute(ref Mob mob)
        {
            using (var dlg = new MobParamsDlg())
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
