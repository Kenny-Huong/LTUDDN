using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LuyenDe_2310.Models
{
    public class KhachHang
    {
        [Required]
        public string MaKH {  get; set; }
        [Required]
        //Trường Ten phải có tối thiều 3 ký tự
        [MinLength(3)]
        public string Ten {  get; set; }
        [Required]
        public string DT {  get; set; }
        [Required]
        //Trường mail phải nhập đúng quy định của địa chỉ Email
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        public string GioiTinh {  get; set; }
        [Required]
        public string DiaChi {  get; set; }
    }
}