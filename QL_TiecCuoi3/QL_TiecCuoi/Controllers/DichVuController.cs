using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class DichVuController : Controller
    {
        //
        // GET: /DichVu/
        QLTCdbContext qltc = new QLTCdbContext();

        public ActionResult Index()
        {
            List<DichVu> list = qltc.DichVus.ToList();
            return View(list);
        }

        [ChildActionOnly]


        public ActionResult layTenDichVu(int magoidichvu)
        {

            //Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();

            var dichvu = (from a in qltc.GoiDichVus
                                   from b in qltc.ChiTietGoiDichVus
                                   from c in qltc.DichVus
                                   where a.MaGoiDichVu == b.MaGoiDichVu && b.MaDichVu == c.MaDichVu && b.MaGoiDichVu == magoidichvu
                                   select c).ToList();

            return View(dichvu);

        }

        [ChildActionOnly]

        public ActionResult layTenDichVu2(int madichvu)
        {



            var ma = qltc.DichVus.Where(d => d.MaDichVu == madichvu).ToList();

            return PartialView("MenuDichVu2", ma);

        }


    }
}
