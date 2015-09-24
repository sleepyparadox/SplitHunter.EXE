using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void PerformRecursive(this Control control, Action<Control> action)
        {
            action(control);
            foreach (Control child in control.Controls)
                PerformRecursive(child, action);
        }

        public static Point GetWorldLocation(this Control control)
        {
            var worldPos = control.Location;
            var parent = control.Parent;
            while(parent != null)
            {
                worldPos.X += parent.Location.X;
                worldPos.Y += parent.Location.Y;

                parent = parent.Parent;
            }
            return worldPos;
        }

    }
}
