using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.Models
{
    public class SanPham
    {
        [Key]
        [MaxLength(5)]
        public string maSP { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [MaxLength(20)]
        public string tenSP { get; set; }

        public virtual ICollection<BanHang> BanHangs { get; set; }
    }
}