using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class ChiTietMonAnController : Controller
    {
        //
        // GET: /ChiTietMonAn/
        QLTCDataContext qltc = new QLTCDataContext();
        QLTCdbContext db = new QLTCdbContext();

        public ActionResult Index(int mamonan)
        {
            Modelss.Model.Mon_An monan = qltc.Mon_Ans.FirstOrDefault(t => t.MaMonAn == mamonan);
            return View(monan);
        }


        

        }


    
}
