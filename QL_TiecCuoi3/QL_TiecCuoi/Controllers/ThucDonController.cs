using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class ThucDonController : Controller
    {
        //
        // GET: /ThucDon/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            List<ThucDon> listtd = qltc.ThucDons.ToList();
            return View(listtd);
           
        }

        public ActionResult index2()
        {
            return View();
        }

       
     

        [ChildActionOnly]

        public ActionResult layTenMonAn(int thucdon)
        {
           
          

            var ma = qltc.ChiTietThucDons.Where(d => d.MaThucDon == thucdon).ToList();



            return PartialView("MenuMonAn", ma);

        }

        [ChildActionOnly]

        public ActionResult layTenMonAn2(int mamonan)
        {



            var ma = qltc.Mon_Ans.Where(d => d.MaMonAn == mamonan).ToList();

            return PartialView("MenuMonAn2", ma);

        }
      



        public ActionResult ThucDon()
        {
            List<ThucDon> listtd = qltc.ThucDons.ToList();
            return View(listtd);
        }

    }
}
