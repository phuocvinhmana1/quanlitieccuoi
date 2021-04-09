using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class DangKyController : Controller
    {
        //
        // GET: /DangKy/

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Modelss.Model.KhachHang kh)
        {

            QLTCDataContext qltc = new QLTCDataContext();

            qltc.KhachHangs.InsertOnSubmit(kh);
           
            qltc.SubmitChanges();
            ViewBag.thanhcong = "Chúc mừng bạn đã đăng kí thành công!";

            ThucDonKHChon tdkh = new ThucDonKHChon();
            tdkh.MaKhachHang = kh.MaTaiKhoan;
            tdkh.TenThucDon = kh.TenKhachHang;
            qltc.ThucDonKHChons.InsertOnSubmit(tdkh);

            GoiDichVuKHChon gdv = new GoiDichVuKHChon();
            gdv.MaKhachHang = kh.MaTaiKhoan;
            gdv.TenGoi = kh.TenKhachHang;
            qltc.GoiDichVuKHChons.InsertOnSubmit(gdv);

            qltc.SubmitChanges();
            
            return RedirectToAction("Index","DangNhap");
        }


    }
}
