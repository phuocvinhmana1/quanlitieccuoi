using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Windows;
using System.IO;
using Modelss.Model;


namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_DichVuController : Controller
    {
        //
        // GET: /Admin/Ad_DichVu/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var dichvu = qltc.DichVus.ToList();

            return View(dichvu);
        }

        public ActionResult themDichVu()
        {
            List<LoaiDichVu> listloai = qltc.LoaiDichVus.ToList();
            return View(listloai);
        }

        [HttpPost]
        public ActionResult xuLythemDichVu(FormCollection fc, HttpPostedFileBase hinh, DichVu dichvu)
        {

            dichvu.TenDichVu = fc["tendichvu"];
            dichvu.LoaiDichVu = int.Parse(fc["loaidichvu"]);
            dichvu.GiaTien = fc["giatien"];
            dichvu.TrangThai = fc["trangthai"];
            dichvu.GhiChu = fc["ghichu"];
            dichvu.MoTa = fc["mota"];
            dichvu.Anh = hinh.FileName;

            string dd = Server.MapPath("/Content/hinhanh/anhdichvu/" + hinh.FileName);
            hinh.SaveAs(dd);
            qltc.DichVus.InsertOnSubmit(dichvu);
            qltc.SubmitChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {

            var dichvu = qltc.DichVus.Single(d => d.MaDichVu == id);

            return View(dichvu);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Modelss.Model.DichVu dichvu)
        {
            try
            {
                // TODO: Add update logic here

                Modelss.Model.DichVu tk = qltc.DichVus.Single(d => d.MaDichVu == id);

                tk.TenDichVu = dichvu.TenDichVu;
                tk.LoaiDichVu1.TenLoaiDichVu = dichvu.LoaiDichVu1.TenLoaiDichVu;
                tk.GhiChu = dichvu.GhiChu;
                tk.GiaTien = dichvu.GiaTien;
                tk.MoTa = dichvu.MoTa;
                tk.TrangThai = dichvu.TrangThai;

                qltc.SubmitChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /Admin/Ad_ThucDon/Delete/5

        public ActionResult Delete(int id)
        {
            var dichvu = qltc.DichVus.Single(d => d.MaDichVu == id);

            return View(dichvu);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Modelss.Model.DichVu dv)
        {
            try
            {
                // TODO: Add delete logic here
                var tk = qltc.DichVus.Single(d => d.MaDichVu == id);
                qltc.DichVus.DeleteOnSubmit(tk);
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
