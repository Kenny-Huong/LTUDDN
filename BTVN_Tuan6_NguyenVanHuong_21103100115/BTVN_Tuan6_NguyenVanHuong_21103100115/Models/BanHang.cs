using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.Models
{
    public class BanHang
    {
        [Key]
        public int Id { get; set; } // Khóa chính tự tăng
        [StringLength(4)]
        public string maNV { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [StringLength(5)]
        public string  maSP { get; set; }
        public virtual SanPham SanPham { get; set; }
        [Display(Name = "Định mức")]
        public int dinhMuc { get; set; }
        [Display(Name = "Số lượng bán")]
        public int soLuongBan { get; set; }
    }
}