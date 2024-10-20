using System.Web;
using System.Web.Mvc;

namespace NguyenVanHuong_17102024_TI15A5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
