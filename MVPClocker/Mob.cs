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
        public bool Track = true;
        public string Name = string.Empty;
        public int RespCD = 0;
        public string Status = Resources.sUnknown;
        public DateTime LastCheck = DateTime.MinValue;
        public DateTime RespIn = DateTime.MaxValue;

        public Mob()
        {
        }

        public Mob(XmlNode eMob)
        {
            var nTrack = eMob.SelectSingleNode("Track");
            if (nTrack != null)
            {
                if (nTrack.InnerText == "False")
                {
                    Track = false;
                }
            }

            var nName = eMob.SelectSingleNode("Name");
            if (nName != null)
            {
                Name = nName.InnerText;
            }

            var nRespCD = eMob.SelectSingleNode("RespCD");
            if (nRespCD != null)
            {
                int iRespCD;
                if (int.TryParse(nRespCD.InnerText, out iRespCD))
                {
                    RespCD = iRespCD;
                }
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
            Track = mob.Track;
            Name = mob.Name;
            RespCD = mob.RespCD;
            Status = mob.Status;
            LastCheck = mob.LastCheck;
        }

        public void SetToElement(ref XmlElement eMob, XmlDocument xd)
        {
            eMob.RemoveAll();
            eMob.AppendChild(AddNode(xd, "Track", Track));
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

        public XmlElement AddNode(XmlDocument xd, string key, bool value)
        {
            var xe = xd.CreateElement(key);
            var sValue = value.ToString();
            var xet = xd.CreateTextNode(sValue);
            xe.AppendChild(xet);
            return xe;
        }

        public XmlElement AddNode(XmlDocument xd, string key, int value)
        {
            var xe = xd.CreateElement(key);
            var sValue = value.ToString();
            var xet = xd.CreateTextNode(sValue);
            xe.AppendChild(xet);
            return xe;
        }
    }
}
