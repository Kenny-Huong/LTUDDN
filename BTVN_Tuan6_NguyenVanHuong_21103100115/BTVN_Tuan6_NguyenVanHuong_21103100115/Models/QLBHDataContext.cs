using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.Models
{
    public partial class QLBHDataContext : DbContext
    {
        public QLBHDataContext()
            : base("name=QLBHDataContext")
        {
        }
        public DbSet<BanHang> banHangs { get; set; }
        public DbSet<NhanVien> nhanViens  { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Xóa quy tắc ??t tên bảng số nhiều
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
