using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace NguyenVanHuong_DHTI15A5HN_110724.Models
{
    public partial class ShopDataContext : DbContext
    {
        public ShopDataContext()
            : base("name=ShopDataContext")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Xóa quy ??c ??t tên b?ng s? nhi?u
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
