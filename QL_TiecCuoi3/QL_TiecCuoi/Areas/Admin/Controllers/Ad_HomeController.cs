using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_HomeController : Controller
    {
        //
        // GET: /Admin/Ad_Home/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            List<LoaiMonAn> list = qltc.LoaiMonAns.ToList();

            return View(list);
        }

        public ActionResult Menu()
        {
            List<LoaiMonAn> list = qltc.LoaiMonAns.ToList();

            return PartialView("Menu",list);
        }
        public ActionResult MenuDichVu()
        {
            List<LoaiDichVu> list = qltc.LoaiDichVus.ToList();

            return PartialView("MenuDichVu", list);
        }



       

    }
}
