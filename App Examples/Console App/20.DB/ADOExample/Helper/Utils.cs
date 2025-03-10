using System.Globalization;

namespace BoscComa.Helper
{
    public static class Utils
    {
        public static string CreateUUID() 
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }

        public static DateTime ConvertToDate(string date,string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            return DateTime.Parse(date, cultureInfo);

        }
    }
}