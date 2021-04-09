using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_TiecCuoi.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage= "Vui lòng nhập tên tài khoản!")]
        public string tenDangNhap { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string matKhau { get; set; }
        public bool nhoMatKhau { get; set; }
    }
}