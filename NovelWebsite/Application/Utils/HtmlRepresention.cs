using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace NovelWebsite.Application.Utils
{
    public static class HtmlRepresention 
    { 
        public static string HtmlEncode(string value)
        {
            // call the normal HtmlEncode first
            char[] chars = HttpUtility.HtmlEncode(value).ToCharArray();
            StringBuilder encodedValue = new StringBuilder();
            foreach (char c in chars)
            {
                if (c > 127) // above normal ASCII
                    encodedValue.Append("&#" + (int)c + ";");
                else
                    encodedValue.Append(c);
            }
            return encodedValue.ToString();
        }
    }
}
