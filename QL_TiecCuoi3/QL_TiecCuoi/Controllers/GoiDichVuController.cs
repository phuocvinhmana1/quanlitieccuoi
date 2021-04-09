using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class GoiDichVuController : Controller
    {
        //
        // GET: /DichVu/

        QLTCdbContext qltc = new QLTCdbContext();

        public ActionResult Index()
        {
            List<GoiDichVu> list = qltc.GoiDichVus.ToList();
            return View(list);

        }


        [ChildActionOnly]

        public ActionResult layTenGoiDichVu(int goidichvu)
        {



            var ma = qltc.ChiTietGoiDichVus.Where(d => d.MaDichVu == goidichvu).ToList();



            return PartialView("MenuDichVu", ma);

        }


    }
}
