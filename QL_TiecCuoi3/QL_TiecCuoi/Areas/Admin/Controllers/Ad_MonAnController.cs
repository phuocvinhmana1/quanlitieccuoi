using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Windows;
using System.IO;
using Modelss.Model;
using Modelss.Framework;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_MonAnController : Controller
    {
        //
        // GET: /Admin/Ad_ThucDon/
        QLTCDataContext qltc = new QLTCDataContext();

        public ActionResult Index()
        {
            var thucdon = qltc.Mon_Ans.ToList();
          
            return View(thucdon);
        }

        //
        // GET: /Admin/Ad_ThucDon/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Ad_ThucDon/Create

        public ActionResult themMonAn()
        {
            List<Modelss.Model.LoaiMonAn> listloai = qltc.LoaiMonAns.ToList();
            return View(listloai);
        }
        [HttpPost]
        public ActionResult xuLythemMonAn(FormCollection fc, HttpPostedFileBase hinh, Modelss.Model.Mon_An monan)
        {

            monan.TenMonAn = fc["tenmonan"];
            monan.LoaiMonAn = int.Parse(fc["loaimonan"]);
            monan.GiaTien = fc["giatien"];
            monan.TrangThai = fc["trangthai"];
            monan.GhiChu = fc["ghichu"];
            monan.MoTa = fc["mota"];
            monan.HinhAnh = hinh.FileName;

            string dd = Server.MapPath("/Content/hinhanh/anhmonan/" + hinh.FileName);
            hinh.SaveAs(dd);
            qltc.Mon_Ans.InsertOnSubmit(monan);
            qltc.SubmitChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            Modelss.Model.Mon_An monan = new Modelss.Model.Mon_An();
            return View(monan);
        }

        //
        // POST: /Admin/Ad_ThucDon/Create

        [HttpPost]
        public ActionResult Create(Modelss.Model.Mon_An monan)
        {
            try
                {
                // TODO: Add insert logic here
                
                    //string file = Path.GetFileNameWithoutExtension(monan.ImageUpload.FileName);
                    //string extension = Path.GetExtension(monan.ImageUpload.FileName);
                    //file = file + extension;  
                    //monan.HinhAnh = "~/Assert/img/" + file;
                    //monan.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Assert/img/"),file));
                    qltc.Mon_Ans.InsertOnSubmit(monan);
                    qltc.SubmitChanges();



                    return RedirectToAction("Index");
                }            
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Ad_ThucDon/Edit/5


        public ActionResult Edit(int id)
        {
          
            var monan = qltc.Mon_Ans.Single(d => d.MaMonAn == id);

            return View(monan);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Modelss.Model.Mon_An monan)
        {
            try
            {
                // TODO: Add update logic here

                Modelss.Model.Mon_An tk = qltc.Mon_Ans.Single(d => d.MaMonAn == id);

                tk.TenMonAn = monan.TenMonAn;
                tk.LoaiMonAn1.TenLoaiMonAn = monan.LoaiMonAn1.TenLoaiMonAn;
                tk.GhiChu = monan.GhiChu;
                tk.GiaTien = monan.GiaTien;
                tk.MoTa = monan.MoTa;
                tk.TrangThai = monan.TrangThai;

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
            var monan = qltc.Mon_Ans.Single(d => d.MaMonAn == id);

            return View(monan);
        }

        //
        // POST: /Admin/Ad_TaiKhoan/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Modelss.Model.Mon_An monan)
        {
            try
            {
                // TODO: Add delete logic here
                var tk = qltc.Mon_Ans.Single(d => d.MaMonAn == id);
                qltc.Mon_Ans.DeleteOnSubmit(tk);
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
