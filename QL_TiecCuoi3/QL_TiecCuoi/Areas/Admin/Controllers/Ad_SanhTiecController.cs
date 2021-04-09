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
    public class Ad_SanhTiecController : Controller
    {
        //
        // GET: /Admin/Ad_SanhTiec/

        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var sanhtiec = qltc.ThongTinSanhs.ToList();

            return View(sanhtiec);
        }

        public ActionResult themsanhtiec()
        {
            return View();
        }



        [HttpPost]
        public ActionResult xulithemsanhtiec(FormCollection fc, HttpPostedFileBase hinh, ThongTinSanh sanhtiec)
        {

            sanhtiec.TenSanh = fc["tensanh"];
            sanhtiec.SoLuongBan = int.Parse(fc["soban"]);
            sanhtiec.LoaiSanh = fc["loaisanh"];
            sanhtiec.DonGia = fc["dongia"];
            sanhtiec.GhiChu = fc["ghichu"];
            sanhtiec.MoTa = fc["mota"];
            sanhtiec.Hinh = hinh.FileName;
            sanhtiec.TrangThai = fc["trangthai"];

            string dd = Server.MapPath("/Content/hinhanh/anhsanhtiec/" + hinh.FileName);
            hinh.SaveAs(dd);
            qltc.ThongTinSanhs.InsertOnSubmit(sanhtiec);
            qltc.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var sanh = qltc.ThongTinSanhs.Single(d => d.MaSanh == id);

            return View(sanh);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ThongTinSanh thongtinsanh)
        {
            try
            {
                // TODO: Add update logic here

                ThongTinSanh tk = qltc.ThongTinSanhs.Single(d => d.MaSanh == id);

                tk.TenSanh = thongtinsanh.TenSanh;
                tk.LoaiSanh = thongtinsanh.LoaiSanh;
                tk.SoLuongBan = thongtinsanh.SoLuongBan;
                tk.DonGia = thongtinsanh.DonGia;
                tk.GhiChu = thongtinsanh.GhiChu;
                tk.TrangThai = thongtinsanh.TrangThai;
                tk.MoTa = thongtinsanh.MoTa;

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
