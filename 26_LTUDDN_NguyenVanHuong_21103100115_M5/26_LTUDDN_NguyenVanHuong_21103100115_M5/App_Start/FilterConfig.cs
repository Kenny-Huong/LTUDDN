using System.Web;
using System.Web.Mvc;

namespace _26_LTUDDN_NguyenVanHuong_21103100115_M5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
