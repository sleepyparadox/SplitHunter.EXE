using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitHunter.EXE
{
    public static class Helper
    {
        public const string FileFriendlyDateTimeFormat = "yyyy-MM-dd_hh-mm-ss-tt";
        public static string NullableToString<T>(this T? val) where T : struct
        {
            if (val.HasValue)
                return val.ToString();
            else
                return "//null";
        }

        public static string ToFileFriendlyString(this DateTime dateTime)
        {
            return dateTime.ToString(FileFriendlyDateTimeFormat);
        }

        //Windows is the slash exception handle it once here
        public static string ToBackSlashPath(this string forwardSlashedPath)
        {
            return forwardSlashedPath.Replace("/", "\\");
        }

        public static string ToForwardPath(this string backwardSlashedPath)
        {
            return backwardSlashedPath.Replace("\\", "/");
        }
    }
}
