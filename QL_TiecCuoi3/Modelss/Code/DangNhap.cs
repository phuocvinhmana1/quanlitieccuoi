using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss.Model;
using System.Data.SqlClient;

namespace Modelss.Code
{
    public class DangNhap
    {
        QLTCDataContext qltc = new QLTCDataContext();

        public KhachHang getTaiKhoan(string tendangnhap)
        {
            return qltc.KhachHangs.SingleOrDefault(d => d.TenDangNhap == tendangnhap);
        }
        public bool Login(string tendangnhap, string matkhau)
        {
            var result = qltc.KhachHangs.Count(d => d.TenDangNhap == tendangnhap && d.MatKhau == matkhau);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
   

}
