using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Model;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_TaiKhoanController : Controller
    {
        //
        // GET: /Admin/Ad_TaiKhoan/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var taikhoan = from a in qltc.TaiKhoans
                           select a;

            return View(taikhoan);
        }

        //
        // GET: /Admin/Ad_TaiKhoan/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Ad_TaiKhoan/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Create

        [HttpPost]
        public ActionResult Create(TaiKhoan taikhoan)
        {
            try
            {
                // TODO: Add insert logic here

                qltc.TaiKhoans.InsertOnSubmit(taikhoan);
                qltc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Ad_TaiKhoan/Edit/5

        public ActionResult Edit(int id)
        {
            var taikhoan = qltc.TaiKhoans.Single(d => d.MaTaiKhoan == id);

            return View(taikhoan);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, TaiKhoan taikhoan)
        {
            try
            {
                // TODO: Add update logic here

                TaiKhoan tk = qltc.TaiKhoans.Single(d=>d.MaTaiKhoan == id);

                tk.TenDangNhap = taikhoan.TenDangNhap;
                tk.MatKhau = taikhoan.MatKhau;
                tk.HoTen = taikhoan.HoTen;
                tk.DiaChi = taikhoan.DiaChi;
                tk.SoDienThoai = taikhoan.SoDienThoai;
                tk.TinhTrang = tk.TinhTrang;

                qltc.SubmitChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Ad_TaiKhoan/Delete/5

        public ActionResult Delete(int id)
        {
            var taikhoan = qltc.TaiKhoans.Single(d => d.MaTaiKhoan == id);

            return View(taikhoan);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TaiKhoan taikhoan)
        {
            try
            {
                // TODO: Add delete logic here
                var tk = qltc.TaiKhoans.Single(d=>d.MaTaiKhoan == id);
                qltc.TaiKhoans.DeleteOnSubmit(tk);
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
