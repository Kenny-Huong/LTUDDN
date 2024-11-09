using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan6_NguyenVanHuong_21103100115.Models
{
    public class NhanVien
    {
        [Key]
        [StringLength(4)]
        public string maNV { get; set; }
        [Display(Name ="Tên Quầy")]
        [StringLength(10)]
        public string tenQuay { get; set; }
        [Display(Name = "Họ Tên")]
        [StringLength(30)]
        public string  hoTen { get; set; }

        public virtual ICollection<BanHang> BanHangs { get; set; }
    }
}