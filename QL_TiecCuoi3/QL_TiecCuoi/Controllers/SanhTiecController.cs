using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class SanhTiecController : Controller
    {
        //
        // GET: /SanhTiec/

        QLTCdbContext qltc = new QLTCdbContext();

        public ActionResult Index()
        {
            List<ThongTinSanh> list = qltc.ThongTinSanhs.ToList();

            return View(list);

        }

    }
}
