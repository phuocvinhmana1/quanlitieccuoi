using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss.Code
{
    public class DangNhapModel
    {
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Vui lòng nhập tài khoản")]
        public string tendangnhap { get; set; }

        [Required(ErrorMessage="Vui lòng nhập mật khẩu")]
        [Display(Name="Mật khẩu")]
        public string matkhau { get; set; }
    }
}
