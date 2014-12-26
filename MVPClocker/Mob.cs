using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using MVPClocker.Properties;

namespace MVPClocker
{
    public class Mob
    {
        public string ID = string.Empty;
        public string Name = string.Empty;
        public string RespCD = "0";
        public string Status = Resources.sUnknown;
        public DateTime LastCheck = DateTime.MinValue;
        public DateTime RespIn = DateTime.MaxValue;

        public Mob()
        {
        }

        public Mob(XmlNode eMob)
        {
            var nID = eMob.SelectSingleNode("ID");
            if (nID != null)
            {
                ID = nID.InnerText;
            }

            var nName = eMob.SelectSingleNode("Name");
            if (nName != null)
            {
                Name = nName.InnerText;
            }

            var nRespCD = eMob.SelectSingleNode("RespCD");
            if (nRespCD != null)
            {
                RespCD = nRespCD.InnerText;
            }

            var nStatus = eMob.SelectSingleNode("Status");
            if (nStatus != null)
            {
                Status = nStatus.InnerText;
            }

            var nLastCheck = eMob.SelectSingleNode("LastCheck");
            if (nLastCheck != null)
            {
                var date = Tools.StringToDateTime(nLastCheck.InnerText);
                if (date.HasValue)
                {
                    LastCheck = date.Value;
                }
            }
        }

        public void Assign(Mob mob)
        {
            ID = mob.ID;
            Name = mob.Name;
            RespCD = mob.RespCD;
            Status = mob.Status;
            LastCheck = mob.LastCheck;
        }

        public void SetToElement(ref XmlElement eMob, XmlDocument xd)
        {
            eMob.RemoveAll();
            eMob.AppendChild(AddNode(xd, "ID", ID));
            eMob.AppendChild(AddNode(xd, "Name", Name));
            eMob.AppendChild(AddNode(xd, "RespCD", RespCD));
            eMob.AppendChild(AddNode(xd, "Status", Status));
            eMob.AppendChild(AddNode(xd, "LastCheck", Tools.DateTimeToString(LastCheck)));
        }

        public XmlElement AddNode(XmlDocument xd, string key, string value)
        {
            var xe = xd.CreateElement(key);
            var xet = xd.CreateTextNode(value);
            xe.AppendChild(xet);
            return xe;
            
        }
    }
}
