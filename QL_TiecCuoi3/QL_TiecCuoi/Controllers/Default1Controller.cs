using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/

        public ActionResult Index(int madattiec)
        {
            QLTCDataContext qltc = new QLTCDataContext();

            DatTiec dt = qltc.DatTiecs.Where(d => d.MaDacTiec == madattiec).FirstOrDefault();

            return View(dt);
        }

        [ChildActionOnly]
        public ActionResult laykhachhang()
        {
            QLTCDataContext qltc = new QLTCDataContext();
            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            KhachHang kh = qltc.KhachHangs.Where(d => d.MaTaiKhoan == session.id).FirstOrDefault();

            return PartialView("View1", kh);
        }


        [ChildActionOnly]
        public ActionResult laydanhsachmonan()
        {
            QLTCDataContext qltc = new QLTCDataContext();
            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string matd = qltc.ThucDonKHChons.Where(d => d.MaKhachHang == session.id).SingleOrDefault().ToString();

            List<Modelss.Model.Mon_An> list = (from a in qltc.ChiTietThucDonKHChons
                                      from b in qltc.ThucDonKHChons
                                      from c in qltc.Mon_Ans
                                      where a.MaThucDon == b.MaThucDon && a.MaMonAn == c.MaMonAn && b.MaThucDon == int.Parse(matd)
                                      select c).ToList();

            return PartialView("View2", list);
        }




    }
}
