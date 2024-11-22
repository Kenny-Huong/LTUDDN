using System.Web;
using System.Web.Mvc;

namespace _26_LTUDDND_NguyenVanHuong_21103100115_DHTI15A5HN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
