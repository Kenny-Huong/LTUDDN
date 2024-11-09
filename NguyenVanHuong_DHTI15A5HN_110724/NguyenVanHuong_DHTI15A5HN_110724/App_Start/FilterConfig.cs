using System.Web;
using System.Web.Mvc;

namespace NguyenVanHuong_DHTI15A5HN_110724
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
