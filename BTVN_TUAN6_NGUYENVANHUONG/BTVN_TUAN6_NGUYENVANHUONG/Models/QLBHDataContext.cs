using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BTVN_TUAN6_NGUYENVANHUONG.Models
{
    public partial class QLBHDataContext : DbContext
    {
        public QLBHDataContext()
            : base("name=QLBHDataContext")
        {
        }
        public DbSet<BanHang> banHangs { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
