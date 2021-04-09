using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class DatTiecController : Controller
    {
        //
        // GET: /DatTiec/
        QLTCdbContext qltc = new QLTCdbContext();
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult dattiec()
        {
            return View();
        }

        public static string buoi;
        public static string ngay;
        [HttpPost]
        public ActionResult xulidattiec(FormCollection fc,Modelss.Model.DatTiec dattiec)
        {
            Modelss.Model.QLTCDataContext qltc = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            //dattiec.MaSanh = int.Parse(fc["tensanh"]);
          
            ngay = fc["ngaytochuc"];
            buoi = fc["buoi"];

            var list = (from a in qltc.DatTiecs
                        from b in qltc.ThongTinSanhs
                        where a.Buoi == buoi && a.NgayToChuc == ngay && a.MaSanh == b.MaSanh
                        select b).ToList();

            if (list != null)
            {
                var tt = qltc.ThongTinSanhs.ToList();

                for (int i = 0; i < tt.Count; i++)
                {

                    for (int i2 = 0; i2 < list.Count; i2++)
                    {
                        if (tt[i].MaSanh.ToString() == list[i2].MaSanh.ToString())
                        {
                            tt.RemoveAt(i);
                        }
                    }
                }

                return PartialView("hienthisanhtiecphuhop", tt);
            }
                //dattiec.MaThucDonKHChon = int.Parse(laymathucdon(session.id));
                //dattiec.MaGoiDichVuKHChon = int.Parse(laymagoidichvu(session.id));


                //qltc.DatTiecs.InsertOnSubmit(dattiec);
                //qltc.SubmitChanges();
                //var list = qltc.ThongTinSanhs.ToList();
            var tt2 = qltc.ThongTinSanhs.ToList();
            return PartialView("hienthisanhtiecphuhop", tt2);
           
        }


        [HttpPost]
        public ActionResult xulihoantatdattiec(FormCollection fc, Modelss.Model.DatTiec dattiec)
        {
            Modelss.Model.QLTCDataContext qltc = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            dattiec.MaSanh = int.Parse(fc["tensanh"]);
            dattiec.NgayToChuc = ngay;
            dattiec.MaKhachHang = session.id;
            dattiec.Buoi = buoi;
            dattiec.MaThucDonKHChon = int.Parse(laymathucdon(session.id));
            dattiec.MaGoiDichVuKHChon = int.Parse(laymagoidichvu(session.id));
            //dattiec.TongTien = 
            int tongtien = int.Parse(Modelss.Common.CommonConstans.tiengoidichvu) + int.Parse(Modelss.Common.CommonConstans.tienthucdon);
            dattiec.TongTien = tongtien.ToString();
            dattiec.TrangThai = "Chưa xác nhận";
            qltc.DatTiecs.InsertOnSubmit(dattiec);
            qltc.SubmitChanges();
            var list = qltc.ThongTinSanhs.ToList();

            return RedirectToAction("Index", "Default1", new { madattiec = dattiec.MaDacTiec});

        }


        public ActionResult Index()
        {
            return View();
        }

        bool kiemTraTiec(string buoi, string ngay)
        {
            var dt = qltc.DatTiecs.Where(d => d.Buoi == buoi && d.NgayToChuc == ngay).SingleOrDefault();
            if (dt != null)
            {
                return false;
            }
            return true;
        }



        string layMaSanh(string tensanh)
        {
            return (from a in qltc.ThongTinSanhs
                    where a.TenSanh == tensanh
                    select a.MaSanh).SingleOrDefault().ToString();
        }

        string laymathucdon(int makhachhang)
        {
            return (from a in qltc.ThucDonKHChons
                    where a.MaKhachHang == makhachhang
                    select a.MaThucDon).SingleOrDefault().ToString();
        }

        string laymagoidichvu(int makhachhang)
        {
            return (from a in qltc.GoiDichVuKHChons
                    where a.MaKhachHang == makhachhang
                    select a.MaGoiDichVuKHChon).SingleOrDefault().ToString();
        }

    }
}
