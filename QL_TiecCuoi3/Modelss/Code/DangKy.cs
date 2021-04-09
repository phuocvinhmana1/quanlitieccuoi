using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelss.Code
{
    public class DangKy
    {
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage="Vui lòng nhập tên đăng nhập!")]
        [Key]
        public string tendangnhap { get; set; }


                [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength=6, ErrorMessage="Độ dài mật  khẩu ít nhất 6 kí tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        public string matkhau { get; set; }

                [Display(Name = "Xác nhận mật khẩu")]
        [Compare("matkhau",ErrorMessage="Mật khẩu xác nhận không chính xác")]
        public string xacnhanmatkhau { get; set; }


                [Display(Name = "Họ và tên")]
        public string hoten { get; set; }

                [Display(Name = "Giới tính")]
                public string gioitinh { get; set; }

                [Display(Name = "Địa chỉ")]
                public string diachi { get; set; }


                [Display(Name = "Số điện thoại")]
        public string sodienthoai { get; set; }

                [Display(Name = "Email")]
                public string email { get; set; }

               


    }
}
