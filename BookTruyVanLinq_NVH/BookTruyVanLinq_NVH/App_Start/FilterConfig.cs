using System.Web;
using System.Web.Mvc;

namespace BookTruyVanLinq_NVH
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
