using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class ChiTietDichVuController : Controller
    {
        //
        // GET: /ChiTietDichVu/

        QLTCDataContext qltc = new QLTCDataContext();


        public ActionResult Index(int madichvu)
        {
            DichVu dichvu = qltc.DichVus.FirstOrDefault(t => t.MaDichVu == madichvu);

            return View(dichvu);
        }

    }
}
