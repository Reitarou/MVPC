using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVPClocker
{
    class Tools
    {
        public static string DateTimeToString(DateTime time)
        {
            var s = string.Empty;
            s += time.Year + ";";
            s += time.Month + ";";
            s += time.Day + ";";
            s += time.Hour + ";";
            s += time.Minute + ";";
            s += time.Second;
            return s;
        }

        public static string DateTimeToShortString(DateTime time)
        {
            var s = string.Empty;
            s += time.Hour + ":";
            s += time.Minute + ":";
            s += time.Second;
            return s;
        }

        public static DateTime? StringToDateTime(string s)
        {
            var array = s.Split(';');
            if (array.Length == 6)
            {
                int year, month, day, hour, minute, second;
                if (!int.TryParse(array[0], out year))
                    return null;
                if (!int.TryParse(array[1], out month))
                    return null;
                if (!int.TryParse(array[2], out day))
                    return null;
                if (!int.TryParse(array[3], out hour))
                    return null;
                if (!int.TryParse(array[4], out minute))
                    return null;
                if (!int.TryParse(array[5], out second))
                    return null;
                return new DateTime(year, month, day, hour, minute, second);
            }
            return null;
        }
    }
}
