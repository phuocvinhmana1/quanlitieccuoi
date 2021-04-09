using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class ChiTietGoiDichVuController : Controller
    {
        QLTCDataContext qltc = new QLTCDataContext();
        //
        // GET: /ChiTietGoiDichVu/

        public ActionResult Index(int magoidichvu)
        {
            GoiDichVu goidichvu = qltc.GoiDichVus.FirstOrDefault(t => t.MaGoiDichVu == magoidichvu);

            return View(goidichvu);
        }

        public ActionResult themgoidichvu(int magoidichvu)
        {

            //List<ChiTietThucDon> list = qltc.ChiTietThucDons.Where(d => d.MaThucDon == mathucdon).ToList();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];



            string magoidichvucuakh = (from a in qltc.GoiDichVuKHChons
                                     from b in qltc.KhachHangs
                                     where a.MaKhachHang == b.MaTaiKhoan && b.MaTaiKhoan == session.id
                                     select a.MaGoiDichVuKHChon).SingleOrDefault().ToString();

            var listct = (from a in qltc.ChiTietGoiDichVuKHChons
                          from b in qltc.GoiDichVuKHChons
                          from c in qltc.KhachHangs
                          where a.MaGoiDichVuKHChon == b.MaGoiDichVuKHChon && b.MaKhachHang == c.MaTaiKhoan && b.MaGoiDichVuKHChon == int.Parse(magoidichvucuakh) && c.MaTaiKhoan == session.id
                          select a).ToList();


            foreach (var item in listct)
            {
                qltc.ChiTietGoiDichVuKHChons.DeleteOnSubmit(item);
                qltc.SubmitChanges();
            }


            var listdichvu = (from a in qltc.GoiDichVus
                             from b in qltc.ChiTietGoiDichVus
                             from c in qltc.DichVus
                             where a.MaGoiDichVu == b.MaGoiDichVu && b.MaDichVu == c.MaDichVu && a.MaGoiDichVu == magoidichvu
                             select c).ToList();

            foreach (var item in listdichvu)
            {
                Modelss.Model.ChiTietGoiDichVuKHChon ct = new ChiTietGoiDichVuKHChon();

                ct.MaGoiDichVuKHChon = int.Parse(magoidichvucuakh);
                ct.MaDichVu = item.MaDichVu;
                qltc.ChiTietGoiDichVuKHChons.InsertOnSubmit(ct);
                qltc.SubmitChanges();

            }




            return RedirectToAction("Index", "HoSoKH");



        }

    }
}
