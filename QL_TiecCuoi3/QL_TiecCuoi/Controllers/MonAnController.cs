using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class MonAnController : Controller
    {
        //
        // GET: /MonAn/
        QLTCdbContext qltc = new QLTCdbContext();

        public ActionResult Index()
        {
            List<Mon_An> list = qltc.Mon_An.ToList();
            return View(list);
            
        }

       

    }
}
