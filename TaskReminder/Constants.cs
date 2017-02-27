using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder
{
    public class Constants
    {
        public static string DateFormat = "yyyy-MM-dd";
        public static string KeySplitLines = "\r\n|\r|\n";
        public static char KeySplitLine = '|';
        public static int MaxItemsInTaskLine = 2;

        public static string Today = "today";
        public static string Tomorrow = "tomorrow";
        public static string AfterTomorrow = "after_tomorrow";

        public static string JHead = "jhead";
        public static string JBody = "jbody";

        public static string LastDate = "LastDate";

        public static string Config = "Config.ini";
    }
}
