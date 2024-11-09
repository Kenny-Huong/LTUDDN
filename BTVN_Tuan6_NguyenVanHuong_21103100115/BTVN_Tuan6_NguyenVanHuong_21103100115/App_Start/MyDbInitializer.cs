using BTVN_Tuan6_NguyenVanHuong_21103100115.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.App_Start
{
    public class MyDbInitializer : DropCreateDatabaseAlways<QLBHDataContext>
    {
        protected override void Seed(QLBHDataContext context)
        {
            context.nhanViens.Add(new NhanVien { maNV = "NV01", tenQuay = "Quầy 2", hoTen = "Mai Lan" });
            context.nhanViens.Add(new NhanVien { maNV = "NV02", tenQuay = "Quầy 1", hoTen = "Hồng Nhung" });
            context.SaveChanges();

            context.SanPhams.Add(new SanPham { maSP = "SP001", tenSP = "Áo thun" });
            context.SanPhams.Add(new SanPham { maSP = "SP002", tenSP = "Áo khoác" });
            context.SanPhams.Add(new SanPham { maSP = "SP003", tenSP = "Quần jean" });
            context.SaveChanges();

            context.banHangs.Add(new BanHang { maNV = "NV01", maSP = "SP001", dinhMuc = 30, soLuongBan = 25 });
            context.banHangs.Add(new BanHang { maNV = "NV01", maSP = "SP002", dinhMuc = 30, soLuongBan = 35 });
            context.banHangs.Add(new BanHang { maNV = "NV02", maSP = "SP002", dinhMuc = 30, soLuongBan = 34 });
            context.banHangs.Add(new BanHang { maNV = "NV02", maSP = "SP003", dinhMuc = 30, soLuongBan = 36 });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}