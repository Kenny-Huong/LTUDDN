﻿using System.Web;
using System.Web.Mvc;

namespace BTVN_TUAN6_NGUYENVANHUONG
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
