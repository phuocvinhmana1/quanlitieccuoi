using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Controllers
{
    public class ChiTietSanhTiecController : Controller
    {
        //
        // GET: /ChiTietSanhTiec/
        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index(int masanhtiec)
        {
            Modelss.Model.ThongTinSanh sanh = qltc.ThongTinSanhs.FirstOrDefault(t => t.MaSanh == masanhtiec);
            return View(sanh);
        }

    }
}
