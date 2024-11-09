using NguyenVanHuong_DHTI15A5HN_110724.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NguyenVanHuong_DHTI15A5HN_110724.App_Start
{
    public class MyDbInitializer : DropCreateDatabaseAlways<ShopDataContext>
    {
        protected override void Seed(ShopDataContext context)
        {
            context.Customers.Add(new Customer { CustomerId = 1, Name = "Nguyễn Văn Hướng" });
            context.Customers.Add(new Customer { CustomerId = 2, Name = "Nguyễn Trọng Bằng" });
            context.Customers.Add(new Customer { CustomerId = 3, Name = "Nguyễn Thùy Linh" });
            context.SaveChanges();
            context.Orders.Add(new Order { CustomerId = 1, ProductName = "Bánh mỳ", 
                Price = 50000, Quantity=3 });
            context.Orders.Add(new Order { CustomerId = 2, ProductName = "Máy giặt", 
                Price = 34000000, Quantity=1 });
            context.Orders.Add(new Order { CustomerId = 3, ProductName = "IP 16Pro Max",
                Price = 36000000, Quantity=1 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}