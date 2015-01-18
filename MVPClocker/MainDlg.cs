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
        private const string c_Ver = "1.5";

        private string m_IniPath = "mvpc.ini";
        private string m_DBPath = string.Empty;
        private int m_TimeZone = 0;
        private DateTime m_DBver;
        private List<Mob> m_Mobs = new List<Mob>();
        private Dictionary<string, bool> m_Notifiers;

        private class MobComparer : IComparer<Mob>
        {
            #region IComparer<Mob> Members

            public int Compare(Mob x, Mob y)
            {
                if (x.Status == Resources.sAlive)
                {
                    if (y.Status == Resources.sAlive)
                    {
                        return x.Name.CompareTo(y.Name);
                    }
                    else if (y.Status == Resources.sKilled)
                    {
                        return -1;
                    }
                    else //if (y.Status == Resources.sUnknown)
                    {
                        return -1;
                    }
                }
                else if (x.Status == Resources.sKilled)
                {
                    if (y.Status == Resources.sAlive)
                    {
                        return 1;
                    }
                    else if (y.Status == Resources.sKilled)
                    {
                        return x.RespIn.CompareTo(y.RespIn);
                    }
                    else //if (y.Status == Resources.sUnknown)
                    {
                        return -1;
                    }
                }
                else //if (x.Status == Resources.sUnknown)
                {
                    if (y.Status == Resources.sAlive)
                    {
                        return 1;
                    }
                    else if (y.Status == Resources.sKilled)
                    {
                        return 1;
                    }
                    else //if (y.Status == Resources.sUnknown)
                    {
                        return x.Name.CompareTo(y.Name);
                    }
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
            this.Text = string.Format("MVP Resp Calc v.{0} by Rei", c_Ver);

            var fp = m_IniPath;
            if (!File.Exists(fp))
            {
                CreateDefaultIni();
            }

            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            XmlNodeList list = xd.GetElementsByTagName("dbPath");
            XmlElement xe = (XmlElement)xd.GetElementsByTagName("dbPath")[0];
            m_DBPath = xe.InnerText;

            list = xd.GetElementsByTagName("TimeZone");
            xe = (XmlElement)xd.GetElementsByTagName("TimeZone")[0];
            m_TimeZone = int.Parse(xe.InnerText);

            fs.Close();

            fp = m_DBPath;
            if (!File.Exists(fp))
            {
                var result = MessageBox.Show("База данных не найдена. Создать новую?", "Ошибка", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    XmlTextWriter xtw = new XmlTextWriter(fp, Encoding.UTF8);
                    xtw.WriteStartDocument();
                    xtw.WriteStartElement("mob_db");
                    xtw.WriteEndDocument();
                    xtw.Close();
                }
                else
                {
                    Close();
                }
            }

            RefreshDB();

            m_Notifiers = new Dictionary<string,bool>();
            foreach (var mob in m_Mobs)
            {
                m_Notifiers.Add(mob.Name, false);
            }

            RefreshNextMVPLabel();
        }

        private void RefreshDB()
        {
            m_Mobs.Clear();

            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            var nVers = xd.GetElementsByTagName(Resources.sDBver);
            if (nVers.Count > 0)
            {
                var eVer = (XmlElement)nVers[0];
                var sVer = eVer.InnerText;
                var DBver = Tools.StringToDateTime(sVer);
                if (DBver != null)
                {
                    m_DBver = DBver.Value;
                }
                else
                {
                    m_DBver = DateTime.MinValue;
                }
            }
            else
            {
                m_DBver = DateTime.MinValue;
            }

            var nMobs = xd.GetElementsByTagName("mob");
            for (int i = 0; i < nMobs.Count; i++)
            {
                var eMob = nMobs[i];
                m_Mobs.Add(new Mob(eMob));
            }
            fs.Close();

            foreach (var mob in m_Mobs)
            {
                var date = mob.LastCheck.AddMinutes(mob.RespCD);
                mob.RespIn = date;
            }

            m_Mobs.Sort(new MobComparer());

            RefreshTable();
            RefreshNextMVPLabel();
        }

        private void RefreshNextMVPLabel()
        {
            var list = new List<Mob>();

            foreach (var mob in m_Mobs)
            {
                if (mob.Status == Resources.sKilled)
                {
                    list.Add(mob);
                }
            }

            list.Sort(new MobComparer());

            if (list.Count > 0)
            {
                lbNextMVP1.Text = string.Format(Resources.sKnownResp, list[0].Name, (list[0].RespIn - DateTime.Now).TotalMinutes.ToString("F0"));
            }
            else
            {
                lbNextMVP1.Text = Resources.sUnknownResp;
            }

            if (list.Count > 1)
            {
                lbNextMVP2.Text = string.Format(Resources.sKnownResp, list[1].Name, (list[1].RespIn - DateTime.Now).TotalMinutes.ToString("F0"));
            }
            else
            {
                lbNextMVP2.Text = Resources.sUnknownResp;
            }

            if (list.Count > 2)
            {
                lbNextMVP3.Text = string.Format(Resources.sKnownResp, list[2].Name, (list[2].RespIn - DateTime.Now).TotalMinutes.ToString("F0"));
            }
            else
            {
                lbNextMVP3.Text = Resources.sUnknownResp;
            }
        }

        private void RefreshTable()
        {
            dgvMobs.Rows.Clear();
            foreach (var mob in m_Mobs)
            {
                if (cbUseNameFilter.Checked)
                {
                    var filter = tbFilter.Text.ToLower();
                    if (filter.Length > 0)
                    {
                        var name = mob.Name.ToLower();
                        if (!name.Contains(filter))
                        {
                            continue;
                        }
                    }
                }

                var index = dgvMobs.Rows.Add();
                if (dgvMobs.Columns[dgvcTrack.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcTrack.Name].Value = mob.Track;
                if (dgvMobs.Columns[dgvcName.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcName.Name].Value = mob.Name;
                if (dgvMobs.Columns[dgvcStatus.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcStatus.Name].Value = mob.Status;
                var respIn = "--:--:--";
                var killedAt = "--:--:--";
                if (mob.Status == Resources.sKilled)
                {
                    var riTime = mob.RespIn.AddHours(m_TimeZone);
                    respIn = Tools.DateTimeToShortString(riTime);
                }
                var lcTime = mob.LastCheck.AddHours(m_TimeZone);
                killedAt = Tools.DateTimeToLongString(lcTime);

                if (dgvMobs.Columns[dgvcRespIn.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcRespIn.Name].Value = respIn;
                if (dgvMobs.Columns[dgvcName.Name].Visible)
                    dgvMobs.Rows[index].Cells[dgvcKilledAt.Name].Value = killedAt;
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

            XmlElement eTimeZone = xd.CreateElement("TimeZone");
            XmlText tTimeZone = xd.CreateTextNode("0");
            eTimeZone.AppendChild(tTimeZone);
            xd.DocumentElement.AppendChild(eTimeZone);

            fs.Close();
            xd.Save(fp);
        }

        

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
            var dbVer = GetDBfileVer();
            var mskTime = DateTime.Now.AddHours(-1 * m_TimeZone);
            var minTime = 5;
            if ((mskTime - dbVer).TotalSeconds < minTime)
            {
                MessageBox.Show("База только что изменена. Подождите {0} сек.", minTime.ToString());
                return;
            }

            var fp = m_DBPath;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.ReadWrite);
            xd.Load(fs);

            var vers = xd.GetElementsByTagName(Resources.sDBver);
            XmlElement eVer;
            if (vers.Count > 0)
            {
                eVer = (XmlElement)vers[0];
            }
            else
            {
                eVer = xd.CreateElement(Resources.sDBver);
            }
            eVer.RemoveAll();
            XmlText tDBPath = xd.CreateTextNode(Tools.DateTimeToString(mskTime));
            eVer.AppendChild(tDBPath);
            xd.DocumentElement.AppendChild(eVer);

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
            var ver = DateTime.MinValue;
            ver = GetDBfileVer();

            if (ver > m_DBver)
            {
                RefreshDB();
                return;
            }

            var changed = false;

            foreach (var mob in m_Mobs)
            {
                var mskTime = DateTime.Now.AddHours(-1 * m_TimeZone);
                if ((mob.Status == Resources.sKilled) && (mob.RespIn.Subtract(mskTime).TotalMinutes < (double)numericUpDown1.Value))
                {
                    if ((m_Notifiers.ContainsKey(mob.Name) && (m_Notifiers[mob.Name] == false)))
                    {
                        m_Notifiers[mob.Name] = true;
                        var dlg = new NotifierDlg();
                        dlg.lbMessage.Text = string.Format(Resources.sKnownResp, mob.Name, mob.RespIn.Subtract(mskTime).TotalMinutes.ToString("F0"));
                    dlg.Show();
                    dlg.Left = SystemInformation.PrimaryMonitorSize.Width - dlg.Width;
                    dlg.Top = SystemInformation.PrimaryMonitorSize.Height - dlg.Height - 80;
                    changed = true;
                    }
                    
                }


                if ((mob.Status == Resources.sKilled) && (mskTime > mob.RespIn))
                {
                    mob.Status = Resources.sAlive;
                    SetMobToDB(mob);

                    if (m_Notifiers.ContainsKey(mob.Name))
                    {
                        m_Notifiers[mob.Name] = false;
                    }
                    var dlg = new NotifierDlg();
                    dlg.lbMessage.Text = string.Format(Resources.sMobResped, mob.Name);
                    dlg.Show();
                    dlg.Left = SystemInformation.PrimaryMonitorSize.Width - dlg.Width;
                    dlg.Top = SystemInformation.PrimaryMonitorSize.Height - dlg.Height-80;
                    
                    changed = true;
                }

                var tooLate = mob.LastCheck.AddMinutes(mob.RespCD+30);
                if ((mob.Status == Resources.sAlive) && (mskTime > tooLate))
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

        private DateTime GetDBfileVer()
        {
            var result = DateTime.MinValue;
            var fp = m_DBPath;
            if (!File.Exists(fp))
            {
                CreateDefaultIni();
            }

            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(fp, FileMode.Open, FileAccess.Read);
            xd.Load(fs);

            XmlNodeList list = xd.GetElementsByTagName(Resources.sDBver);
            if (list.Count > 0)
            {
                XmlElement xe = (XmlElement)xd.GetElementsByTagName(Resources.sDBver)[0];
                var ver = Tools.StringToDateTime(xe.InnerText);
                if (ver.HasValue)
                {
                    result = ver.Value;
                }
            }
            fs.Close();
            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RefreshTable();
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



        private void btnKilledAt_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();
            var mob = GetMobFromDB(name);
            if (KilledAtDlg.Execute(ref mob))
            {
                SetMobToDB(mob);
                RefreshDB();
            }
        }

        private void btnKilled_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();

            foreach (var mob in m_Mobs)
            {
                if (mob.Name == name)
                {
                    var mskTime = DateTime.Now.AddHours(-1 * m_TimeZone);
                    mob.LastCheck = mskTime;
                    mob.Status = Resources.sKilled;
                    SetMobToDB(mob);
                    RefreshDB();
                    break;
                }
            }
        }

        private void btnNA_Click(object sender, EventArgs e)
        {
            var name = dgvMobs.SelectedRows[0].Cells[dgvcName.Name].Value.ToString();
            foreach (var mob in m_Mobs)
            {
                if (mob.Name == name)
                {
                    var mskTime = DateTime.Now.AddHours(-1 * m_TimeZone);
                    mob.LastCheck = mskTime;
                    mob.Status = Resources.sUnknown;
                    SetMobToDB(mob);
                    RefreshDB();
                    break;
                }
            }
        }

        #endregion

        
    }
}
