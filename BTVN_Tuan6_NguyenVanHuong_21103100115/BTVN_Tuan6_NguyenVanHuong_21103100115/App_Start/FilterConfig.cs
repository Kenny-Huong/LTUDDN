using System.Web;
using System.Web.Mvc;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
