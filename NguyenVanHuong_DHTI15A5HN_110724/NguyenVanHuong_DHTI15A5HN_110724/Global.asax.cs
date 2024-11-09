using NguyenVanHuong_DHTI15A5HN_110724.App_Start;
using NguyenVanHuong_DHTI15A5HN_110724.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NguyenVanHuong_DHTI15A5HN_110724
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Khởi tạo bảng không có dữ liệu cho Database mà mình vừa liên kết với DataContext
            //Database.SetInitializer(new DropCreateDatabaseAlways<ShopDataContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShopDataContext>());
            Database.SetInitializer(new MyDbInitializer());
        }
    }
}
