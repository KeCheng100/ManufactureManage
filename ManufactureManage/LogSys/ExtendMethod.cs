using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManufactureManage.LogSys
{
    public static class ExtendMethod
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool bold = false)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            if (bold)
                box.SelectionFont = new Font(box.Font, FontStyle.Bold);
            else
                box.SelectionFont = new Font(box.Font, FontStyle.Regular);

            box.ScrollToCaret();
        }
        public static int ToInt(this string s)
        {
            if (int.TryParse(s, out int i))
                return i;
            else
                return 0;
        }

        public static double ToDouble(this string s)
        {
            if (double.TryParse(s, out double i))
                return i;
            else
                return 0;
        }

        public static double? TryToDouble(this string s)
        {
            if (double.TryParse(s, out double i))
                return i;
            else
                return null;
        }

        public static string ToString(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToString(bytes, startIndex);
        }

        public static string ToUTF8String(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
