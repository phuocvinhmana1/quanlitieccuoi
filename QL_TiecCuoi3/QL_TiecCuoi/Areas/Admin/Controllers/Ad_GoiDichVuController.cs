using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_GoiDichVuController : Controller
    {
        //
        // GET: /Admin/Ad_GoiDichVu/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var gdv = from a in qltc.GoiDichVus
                     select a;

            return View(gdv);
        }

        public ActionResult Details(int id)
        {
            var ct = (from a in qltc.ChiTietGoiDichVus
                      from b in qltc.GoiDichVus
                      from c in qltc.DichVus
                      where a.MaGoiDichVu == b.MaGoiDichVu && a.MaGoiDichVu == id && a.MaDichVu == c.MaDichVu
                      select c);

            Session.Add(Modelss.Common.CommonConstans.MaGoiDichVu_SESSTION, id);



            return View(ct);
        }





        public ActionResult delete(int id)
        {
            xoadichvu(id);


            return RedirectToAction("Index", "Ad_GoiDichVu");

        }
        public bool xoadichvu(int madichvu)
        {

            var session = Session[Modelss.Common.CommonConstans.MaGoiDichVu_SESSTION];

            int magoidichvu = int.Parse(session.ToString());

            int machitiet = (from a in qltc.ChiTietGoiDichVus
                             where a.MaDichVu == madichvu && a.MaGoiDichVu == magoidichvu
                             select a.MaChiTietGoiDV).SingleOrDefault();

            var tim = qltc.ChiTietGoiDichVus.Where(d => d.MaChiTietGoiDV == machitiet).SingleOrDefault();
            qltc.ChiTietGoiDichVus.DeleteOnSubmit(tim);
            qltc.SubmitChanges();
            return true;

        }

        public ActionResult themdichvu()
        {
            List<DichVu> listdichvu = qltc.DichVus.ToList();
            return View(listdichvu);
        }
        [HttpPost]
        public ActionResult xulithemdichvu(FormCollection fc, ChiTietGoiDichVu ct)
        {
            var session = Session[Modelss.Common.CommonConstans.MaGoiDichVu_SESSTION];

            ct.MaDichVu = int.Parse(fc["tendichvu"]);
            ct.MaGoiDichVu = int.Parse(session.ToString());


            qltc.ChiTietGoiDichVus.InsertOnSubmit(ct);
            qltc.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult themgoidichvu()
        {

            return View();
        }

        [HttpPost]
        public ActionResult xulithemgoidichvu(FormCollection fc, HttpPostedFileBase hinh, Modelss.Model.GoiDichVu goidichvu)
        {

            goidichvu.TenGoiDichVu = fc["tengoidichvu"];
            goidichvu.SoLuong = int.Parse(fc["soluong"]);
            goidichvu.TongTien = "0";
            goidichvu.TrangThai = fc["trangthai"];
            goidichvu.GhiChu = fc["ghichu"];

            goidichvu.HinhAnh = hinh.FileName;

            string dd = Server.MapPath("/Content/hinhanh/anhgoidichvu/" + hinh.FileName);
            hinh.SaveAs(dd);
            qltc.GoiDichVus.InsertOnSubmit(goidichvu);
            qltc.SubmitChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {

            var gdv = qltc.GoiDichVus.Single(d => d.MaGoiDichVu == id);

            return View(gdv);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Modelss.Model.GoiDichVu td)
        {
            try
            {
                // TODO: Add update logic here

                Modelss.Model.GoiDichVu tk = qltc.GoiDichVus.Single(d => d.MaGoiDichVu == id);

                tk.TenGoiDichVu = td.TenGoiDichVu;
                tk.TrangThai = td.TrangThai;
                tk.SoLuong = td.SoLuong;
                tk.TongTien = td.TongTien;
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


    }
}
