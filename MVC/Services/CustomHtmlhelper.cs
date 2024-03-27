using System.Text.RegularExpressions;

namespace Rama.MVC.Services
{
    public class CustomHtmlhelper
    {
        public static string StripHtmlTags(string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }
    }
}
