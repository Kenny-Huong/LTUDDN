using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTVN_Tuan4.Models
{
    public class NhanVien
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int maNV { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Họ tên")]
        public string hoTen { get; set; }
        [Required]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ngaySinh { get; set; }
        [Display(Name = "Giới tính")]
        [Required]
        public bool gioiTinh { get; set; }
        [Display(Name ="Giới tính")]
        public string GenderText
        {
            get { return gioiTinh ? "Nam" : "Nữ"; }
        }
        [Required]
        [Display(Name = "Điện thoại")]
        [StringLength(10)]
        public string dienThoai { get; set; }
        [Required]
        [Display(Name = "Hệ số lương")]
        [Range(1, 4)]
        public int HSL { get; set; }
        [Required]
        [Display(Name = "Lương")]
        public double Luong { get; set; }
        [Required]
        [Display(Name = "Tên phòng")]
        [StringLength(20)]
        public string tenPhong { get; set; }

        
    }
}