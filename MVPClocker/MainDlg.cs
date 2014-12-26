using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using MVPClocker.Properties;

namespace MVPClocker
{
    public partial class MainDlg : Form
    {
        private string m_IniPath = "mvpc.ini";
        private string m_DBPath = string.Empty;
        private List<Mob> m_Mobs = new List<Mob>();

        private class MobComparer : IComparer<Mob>
        {
            #region IComparer<Mob> Members

            public int Compare(Mob x, Mob y)
            {
                if ((x.Status == Resources.sKilled) && (y.Status == Resources.sKilled))
                {
                    return x.RespIn.CompareTo(y.RespIn);
                }
                else
                {
                    if (x.Status == Resources.sKilled)
                        return -1;
                    else
                        return 1;
                }
            }

            #endregion
        }

        public MainDlg()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var fp = m_IniPath;
            if (!File.Exists(fp))
            {
                CreateDefaultIni();
            }

            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            XmlNodeList list = xd.GetElementsByTagName("dbPath");
            XmlElement dbPath = (XmlElement)xd.GetElementsByTagName("dbPath")[0];
            m_DBPath = dbPath.InnerText;
            fs.Close();

            fp = m_DBPath;
            if (!File.Exists(fp))
            {
                XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
                xtw.WriteStartDocument();
                xtw.WriteStartElement("mob_db");
                xtw.WriteEndDocument();
                xtw.Close();
            }

            RefreshDB();
        }

        private void RefreshDB()
        {
            m_Mobs.Clear();

            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            var nMobs = xd.GetElementsByTagName("mob");
            for (int i = 0; i < nMobs.Count; i++)
            {
                var eMob = nMobs[i];
                m_Mobs.Add(new Mob(eMob));
            }
            fs.Close();

            foreach (var mob in m_Mobs)
            {
                int respCD;
                if (int.TryParse(mob.RespCD, out respCD))
                {
                    var date = mob.LastCheck.AddMinutes(respCD);
                    mob.RespIn = date;
                }
            }

            m_Mobs.Sort(new MobComparer());

            dgvMobs.Rows.Clear();
            foreach (var mob in m_Mobs)
            {
                var index = dgvMobs.Rows.Add();
                if(dgvMobs.Columns[dgvcID.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcID.Name].Value = mob.ID;
                if (dgvMobs.Columns[dgvcName.Name].Visible)
                dgvMobs.Rows[index].Cells[dgvcName.Name].Value = mob.Name;
                if (dgvMobs.Columns[dgvcRespCD.Name].Visible)
                dgvMobs.Rows[index].Cells[dgvcRespCD.Name].Value = mob.RespCD;
                if (dgvMobs.Columns[dgvcStatus.Name].Visible)
                dgvMobs.Rows[index].Cells[dgvcStatus.Name].Value = mob.Status;

                var respIn = "--:--:--";
                if (mob.Status == Resources.sKilled)
                {
                    respIn = Tools.DateTimeToShortString(mob.RespIn);
                }
                if (dgvMobs.Columns[dgvcRespIn.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcRespIn.Name].Value = respIn;
            }
        }

        private void CreateDefaultIni()
        {
            var fp = m_IniPath;
            XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("mvpc_settings");
            xtw.WriteEndDocument();
            xtw.Close();

            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);
            XmlElement eDBPath = xd.CreateElement("dbPath");
            XmlText tDBPath = xd.CreateTextNode("MobDB.xml");
            eDBPath.AppendChild(tDBPath);
            xd.DocumentElement.AppendChild(eDBPath);
            fs.Close();
            xd.Save(fp);
        }

        #region Buttons

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newMob = new Mob();
            if (MobParamsDlg.Execute(ref newMob))
            {
                SetMobToDB(newMob);
                RefreshDB();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();
            var mob = GetMobFromDB(name);
            if (MobParamsDlg.Execute(ref mob))
            {
                if (mob.Name == name)
                {
                    RemoveMobFromDB(name);
                }
                SetMobToDB(mob);
                RefreshDB();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();
            RemoveMobFromDB(name);
            RefreshDB();
        }

        private void btnKilled_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();

            foreach (var mob in m_Mobs)
            {
                if (mob.Name == name)
                {
                    mob.LastCheck = DateTime.Now;
                    mob.Status = Resources.sKilled;
                    SetMobToDB(mob);
                    RefreshDB();
                    break;
                }
            }
        }

        #endregion

        #region DB

        private Mob GetMobFromDB(string name)
        {
            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            XmlElement eMob = xd.CreateElement("mob");
            var nMobs = xd.GetElementsByTagName("mob");
            for (int i = 0; i < nMobs.Count; i++)
            {
                var nMob = nMobs[i];
                var dbMob = new Mob(nMob);
                if (dbMob.Name == name)
                {
                    eMob = (XmlElement)nMob;
                    break;
                }
            }
            var mob = new Mob(eMob);
            fs.Close();
            return mob;
        }

        private void SetMobToDB(Mob mob)
        {
            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);

            XmlElement eMob = xd.CreateElement("mob");
            var nMobs = xd.GetElementsByTagName("mob");
            for (int i = 0; i < nMobs.Count; i++)
            {
                var nMob = nMobs[i];
                var dbMob = new Mob(nMob);
                if (dbMob.Name == mob.Name)
                {
                    eMob = (XmlElement)nMob;
                    break;
                }
            }
            mob.SetToElement(ref eMob, xd);
            xd.DocumentElement.AppendChild(eMob);
            fs.Close();
            xd.Save(fp);
        }

        private void RemoveMobFromDB(string name)
        {
            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);

            var changed = false;
            var nMobs = xd.GetElementsByTagName("mob");
            for (int i = 0; i < nMobs.Count; i++)
            {
                var nMob = nMobs[i];
                var dbMob = new Mob(nMob);
                if (dbMob.Name == name)
                {
                    xd.DocumentElement.RemoveChild(nMob);
                    changed = true;
                    break;
                }
            }
            fs.Close();
            if (changed)
            {
                xd.Save(fp);
            }
        }

        #endregion

        private void checkTimer_Tick(object sender, EventArgs e)
        {
            var changed = false;

            foreach (var mob in m_Mobs)
            {
                if ((mob.Status == Resources.sKilled) && (DateTime.Now > mob.RespIn))
                {
                    mob.LastCheck = DateTime.Now;
                    mob.Status = Resources.sAlive;
                    SetMobToDB(mob);
                    var dlg = new NotifierDlg();
                    dlg.Left = SystemInformation.PrimaryMonitorSize.Width - dlg.Width;
                    dlg.Top = SystemInformation.PrimaryMonitorSize.Height - dlg.Height;
                    dlg.lbMessage.Text = string.Format(Resources.sMobResped, mob.Name);
                    dlg.Show();
                    dlg.player.Play();
                    changed = true;
                }

                var tooLate = mob.LastCheck.AddHours(3);
                if ((mob.Status == Resources.sAlive) && (DateTime.Now > tooLate))
                {
                    mob.Status = Resources.sUnknown;
                    SetMobToDB(mob);
                    changed = true;
                }
            }

            if (changed)
            {
                RefreshDB();
            }

        }

        
    }
}
