using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_ThucDonController : Controller
    {
        //
        // GET: /Admin/Ad_ThucDon/
        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var td = from a in qltc.ThucDons
                           select a;

            return View(td);
        }

        public ActionResult Details(int id)
        {
           var ct = (from a in qltc.ChiTietThucDons
                         from b in qltc.ThucDons
                         from c in qltc.Mon_Ans
                         where a.MaThucDon == b.MaThucDon && a.MaThucDon == id && a.MaMonAn == c.MaMonAn
                         select c);

           Session.Add(Modelss.Common.CommonConstans.MaThucDon_SESSTION, id);

            
 
            return View(ct);
        }



        public ActionResult Edit(int id)
        {

            var thucdon = qltc.ThucDons.Single(d => d.MaThucDon == id);

            return View(thucdon);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Modelss.Model.ThucDon td)
        {
            try
            {
                // TODO: Add update logic here

                Modelss.Model.ThucDon tk = qltc.ThucDons.Single(d => d.MaThucDon == id);

                tk.TenThucDon = td.TenThucDon;
                tk.TrangThai = td.TrangThai;
                tk.SoLuongMon = td.SoLuongMon;
                tk.TongDonGia = td.TongDonGia;
                tk.HinhAnh = td.HinhAnh;
                tk.GhiChu = td.GhiChu;

                qltc.SubmitChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


      

        public ActionResult delete(int id)
        {
            xoamonan(id);


            return RedirectToAction("Index", "Ad_ThucDon");

        }
        public bool xoamonan(int mamonan)
        {
          
            var session = Session[Modelss.Common.CommonConstans.MaThucDon_SESSTION];

            int mathucdon = int.Parse(session.ToString());

            int machitiet = (from a in qltc.ChiTietThucDons
                             where a.MaMonAn == mamonan  && a.MaThucDon == mathucdon
                             select a.MaChiTietThucDon).SingleOrDefault();

            var tim = qltc.ChiTietThucDons.Where(d => d.MaChiTietThucDon == machitiet).SingleOrDefault();
            qltc.ChiTietThucDons.DeleteOnSubmit(tim);
            qltc.SubmitChanges();
            return true;

        }

        public ActionResult themmonan()
        {
            List<Mon_An> listmonan = qltc.Mon_Ans.ToList();
            return View(listmonan);
        }
        [HttpPost]
        public ActionResult xulithemmonan(FormCollection fc, ChiTietThucDon ct)
        {
            var session = Session[Modelss.Common.CommonConstans.MaThucDon_SESSTION];

            ct.MaMonAn = int.Parse(fc["tenmonan"]);
            ct.MaThucDon = int.Parse(session.ToString());

            
            qltc.ChiTietThucDons.InsertOnSubmit(ct);
            qltc.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult themthucdon()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult xulithemthucdon(FormCollection fc, HttpPostedFileBase hinh, Modelss.Model.ThucDon thucdon)
        {

            thucdon.TenThucDon = fc["tenthucdon"];
            thucdon.SoLuongMon = int.Parse(fc["soluongmon"]);
            thucdon.TongDonGia = "0";
            thucdon.TrangThai = fc["trangthai"];
            thucdon.GhiChu = fc["ghichu"];

            thucdon.HinhAnh = hinh.FileName;

            string dd = Server.MapPath("/Content/hinhanh/anhthucdon/" + hinh.FileName);
            hinh.SaveAs(dd);
            qltc.ThucDons.InsertOnSubmit(thucdon);
            qltc.SubmitChanges();

            return RedirectToAction("Index");
        }


    }
}
