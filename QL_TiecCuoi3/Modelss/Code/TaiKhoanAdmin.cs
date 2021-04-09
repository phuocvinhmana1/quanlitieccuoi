using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelss.Model;
using System.Data.SqlClient;

namespace Modelss.Code
{
    
    public class TaiKhoanAdmin
    {
        QLTCDataContext qltc = new QLTCDataContext();

        public List<KhachHang> getListTaiKhoanAdmin()
        {
            return qltc.KhachHangs.ToList();
        }

        public bool taoTaiKhoan(string tendangnhap, string matkhau, string loaitaikhoan, int trangthai)
        {
            KhachHang insert = new KhachHang();
            insert.TenDangNhap = tendangnhap;
            insert.MatKhau = matkhau;
            insert.LoaiTaiKhoan = loaitaikhoan;
            insert.TrangThai = trangthai;

            qltc.KhachHangs.InsertOnSubmit(insert);
            qltc.SubmitChanges();
            return true;
        }


    }
}
