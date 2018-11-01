using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace JangMVCWebSite.Extension
{
    public static class ExtensionMethod
    {
        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetType() == typeof(int) ? (int)p.GetValue(obj, null) != 0 : p.GetValue(obj, null) != null
                             select p.Name.ToLower(CultureInfo.CurrentCulture) + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());
            return string.Join("&", properties.ToArray());
        }
    }
}