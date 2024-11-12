using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_TUAN6_NGUYENVANHUONG.Models
{
    public class SanPham
    {
        [Key]
        [MaxLength(5)]
        public string maSP { get; set; }
        [Display(Name ="Tên sản phẩm")]
        [MaxLength(20)]
        public string tenSP { get; set; }

        public virtual ICollection<BanHang> BanHangs { get; set; }
    }
}