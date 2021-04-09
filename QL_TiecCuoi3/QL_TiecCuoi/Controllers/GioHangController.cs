using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Code;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QLTCdbContext db = new QLTCdbContext();
        

        private const string SessionGioHang = "SessionGioHang";

        public ActionResult Index()
        {
            var giohang = Session[SessionGioHang];
            var list = new List<GioHang>();
            if (giohang != null)
            {
                list = (List <GioHang>) giohang; 
            }
            return View(list);
        }

        public Modelss.Framework.ThucDon layThucDon(int mathucdon)
        {
            return db.ThucDons.Where(d => d.MaThucDon == mathucdon).FirstOrDefault();
           
        }


        public ActionResult themSanPham(int masanpham)
        {
            int soluong = 1;
            var sanpham = layThucDon(masanpham);

            var giohang = Session[SessionGioHang];
            if (giohang != null)
            {

                var list = (List <GioHang>)giohang;
                if (list.Exists(x => x.SanPham.MaThucDon == masanpham))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.MaThucDon == masanpham)
                        {
                            item.SoLuong += soluong;
                        }

                    }
                }
                else
                {
                    var item = new GioHang();
                    item.SanPham = sanpham;
                    item.SoLuong = soluong;
                    list.Add(item);
                }

                Session[SessionGioHang] = list;
                
            }
            else
            {
                // tao moi doi tuong item
                var item = new GioHang();
                item.SanPham = sanpham;
                item.SoLuong = soluong;
                var list = new List<GioHang>();

                // gan vao session
                Session[SessionGioHang] = list;

            }

            return RedirectToAction("Index");

 
        }

    }
}
