using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class ChiTietThucDonController : Controller
    {
        //
        // GET: /chiTiet/
        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index(int mathucdon)
        {
            ThucDon td = qltc.ThucDons.FirstOrDefault(t => t.MaThucDon == mathucdon);
            return View(td);
        }

        public ActionResult themthucdon(int mathucdon)
        {
 
            //List<ChiTietThucDon> list = qltc.ChiTietThucDons.Where(d => d.MaThucDon == mathucdon).ToList();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];



            string mathucdoncuakh = (from a in qltc.ThucDonKHChons
                                     from b in qltc.KhachHangs
                                     where a.MaKhachHang == b.MaTaiKhoan && b.MaTaiKhoan == session.id
                                     select a.MaThucDon).SingleOrDefault().ToString();

            var listct = (from a in qltc.ChiTietThucDonKHChons
                          from b in qltc.ThucDonKHChons
                          from c in qltc.KhachHangs
                          where a.MaThucDon == b.MaThucDon && b.MaKhachHang == c.MaTaiKhoan && b.MaThucDon == int.Parse(mathucdoncuakh) && c.MaTaiKhoan == session.id
                          select a).ToList();


            foreach (var item in listct)
            {
                qltc.ChiTietThucDonKHChons.DeleteOnSubmit(item);
                qltc.SubmitChanges();
            }


            var listmonan = (from a in qltc.ThucDons
                             from b in qltc.ChiTietThucDons
                             from c in qltc.Mon_Ans
                             where a.MaThucDon == b.MaThucDon && b.MaMonAn == c.MaMonAn && a.MaThucDon == mathucdon
                             select c).ToList();

            foreach (var item in listmonan)
            {
                Modelss.Model.ChiTietThucDonKHChon ct = new ChiTietThucDonKHChon();

                ct.MaThucDon = int.Parse(mathucdoncuakh);
                ct.MaMonAn = item.MaMonAn;
                qltc.ChiTietThucDonKHChons.InsertOnSubmit(ct);
                qltc.SubmitChanges();

            }




            return RedirectToAction("Index","HoSoKH");



        }



    }
}
