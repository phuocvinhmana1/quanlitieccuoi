using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class HoSoKHController : Controller
    {
        //
        // GET: /HoSoKH/
        QLTCdbContext qltc = new QLTCdbContext();



        [ChildActionOnly]

        public ActionResult laychitietthucdonkhchon(int makhachhang)
        {

            string magoidichvu = laymagoidichvu(makhachhang);

            List<Modelss.Framework.DichVu> list = laylistdichvu(int.Parse(magoidichvu));



            return PartialView("DanhSachDichVu", list);

        }
        [ChildActionOnly]

        public ActionResult chonsanhtiec()
        {
            var list = (from a in qltc.ThongTinSanhs
                        select a).ToList();

            return PartialView("ChonSanhTiec", list);

        }



        //int tinhtien()
        //{
        //    //string magoidichvu = laymagoidichvu(2);

        //    //List<Modelss.Framework.DichVu> list = laylistdichvu(int.Parse(magoidichvu));

        //    //int tong = 0;

        //    //for (int i = 0; i < list.Count; i++)
        //    //{
        //    //    string gia = list[i].GiaTien;
        //    //    tong = tong + int.Parse(gia);

        //    //}
        //    //return tong;
        //}


        public ActionResult themdv(int madichvu)
        {


            if (themdichvu(madichvu) == true)
            {
                return RedirectToAction("Index", "HoSoKH");
            }

            return View("HienThiLoi");
        }

        public bool themdichvu(int madichvu)
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string magoidichvu = (from a in ql.GoiDichVuKHChons
                                  from b in ql.KhachHangs
                                  where a.MaKhachHang == session.id && a.MaKhachHang == b.MaTaiKhoan
                                  select a.MaGoiDichVuKHChon).FirstOrDefault().ToString();

            var listdichvu = ql.ChiTietGoiDichVuKHChons.Where(d => d.MaGoiDichVuKHChon == int.Parse(magoidichvu)).ToList();

            for (int i = 0; i < listdichvu.Count; i++)
            {
                if (listdichvu[i].MaDichVu == madichvu)
                {
                    return false;
                }
            }

            var chitiet = new Modelss.Framework.ChiTietGoiDichVuKHChon();
            chitiet.MaGoiDichVuKHChon = int.Parse(magoidichvu);
            chitiet.MaDichVu = madichvu;
            qltc.ChiTietGoiDichVuKHChons.Add(chitiet);
            qltc.SaveChanges();
            return true;

        }



        public ActionResult them(int mamonan)
        {


            if (themmonan(mamonan) == true)
            {
                return RedirectToAction("Index", "HoSoKH");
            }

            return View("HienThiLoi");
        }

        public bool themmonan(int mamonan)
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string mathucdon = (from a in ql.ThucDonKHChons
                                from b in ql.KhachHangs
                                where a.MaKhachHang == session.id && a.MaKhachHang == b.MaTaiKhoan
                                select a.MaThucDon).FirstOrDefault().ToString();

            var listmonan = ql.ChiTietThucDonKHChons.Where(d => d.MaThucDon == int.Parse(mathucdon)).ToList();

            for (int i = 0; i < listmonan.Count; i++)
            {
                if (listmonan[i].MaMonAn == mamonan)
                {
                    return false;
                }
            }

            var chitiet = new Modelss.Framework.ChiTietThucDonKHChon();
            chitiet.MaThucDon = int.Parse(mathucdon);
            chitiet.MaMonAn = mamonan;
            qltc.ChiTietThucDonKHChons.Add(chitiet);
            qltc.SaveChanges();
            return true;

        }

        public ActionResult delete(int mamonan)
        {
            xoamonan(mamonan);


            return RedirectToAction("Index", "HoSoKH");

        }
        public ActionResult deletedichvu(int madichvu)
        {
            xoadichvu(madichvu);


            return RedirectToAction("Index", "HoSoKH");

        }
        public bool xoamonan(int mamonan)
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();


            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string mathucdon = (from a in ql.ThucDonKHChons
                                from b in ql.KhachHangs
                                where a.MaKhachHang == session.id && a.MaKhachHang == b.MaTaiKhoan
                                select a.MaThucDon).FirstOrDefault().ToString();


            int machitiet = (from a in ql.ChiTietThucDonKHChons
                             where a.MaThucDon == int.Parse(mathucdon) && a.MaMonAn == mamonan
                             select a.MaChiTietThucDonKhChon).SingleOrDefault();




            var xoamonan = ql.ChiTietThucDonKHChons.Where(d => d.MaChiTietThucDonKhChon == machitiet).FirstOrDefault();
            ql.ChiTietThucDonKHChons.DeleteOnSubmit(xoamonan);
            ql.SubmitChanges();
            return true;

        }


        public bool xoadichvu(int madichvu)
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();


            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string magoidichvu = (from a in ql.GoiDichVuKHChons
                                from b in ql.KhachHangs
                                where a.MaKhachHang == session.id && a.MaKhachHang == b.MaTaiKhoan
                                select a.MaGoiDichVuKHChon).FirstOrDefault().ToString();


            int machitiet = (from a in ql.ChiTietGoiDichVuKHChons
                             where a.MaGoiDichVuKHChon == int.Parse(magoidichvu) && a.MaDichVu == madichvu
                             select a.MaChiTiet).SingleOrDefault();




            var xoadichvu = ql.ChiTietGoiDichVuKHChons.Where(d => d.MaChiTiet == machitiet).FirstOrDefault();
            ql.ChiTietGoiDichVuKHChons.DeleteOnSubmit(xoadichvu);
            ql.SubmitChanges();
            return true;

        }



        public ActionResult Index()
        {
            setViewBag();
            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];
            int makhachhang = session.id;

            var mtd = (from a in qltc.ThucDonKHChons
                       where a.MaKhachHang == makhachhang
                       select a.MaThucDon).FirstOrDefault();
            var mgdv = (from a in qltc.GoiDichVuKHChons
                        where a.MaKhachHang == makhachhang
                        select a.MaGoiDichVuKHChon).FirstOrDefault();

            var listmonan = (from a in qltc.ChiTietThucDonKHChons
                             from b in qltc.Mon_An
                             where a.MaMonAn == b.MaMonAn && a.MaThucDon == mtd
                             select b.GiaTien).ToList();
            var listdichvu = (from a in qltc.ChiTietGoiDichVuKHChons
                              from b in qltc.DichVus
                              where a.MaDichVu == b.MaDichVu && a.MaGoiDichVuKHChon == mgdv
                              select b.GiaTien).ToList();
            int tongtientd = 0;
            int tongtiendv = 0;
            for (int i = 0; i < listmonan.Count; i++)
            {
                tongtientd = tongtientd + int.Parse(listmonan[i]);

            }

            for (int i = 0; i < listdichvu.Count; i++)
            {
                tongtiendv = tongtiendv + int.Parse(listdichvu[i]);

            }

            var mathucdon = (from a in qltc.ThucDonKHChons
                             where a.MaKhachHang == makhachhang
                             select a.MaThucDon).FirstOrDefault().ToString();


            ViewBag.tinhtienthucdon = tongtientd.ToString();
            ViewBag.tinhtiendichvu = tongtiendv.ToString();
            Modelss.Common.CommonConstans.tienthucdon = tongtientd.ToString();
            Modelss.Common.CommonConstans.tiengoidichvu = tongtiendv.ToString();


            List<Modelss.Framework.Mon_An> list = laylistmonan(int.Parse(mathucdon));


            return View(list);
        }







        public string laymathucdon(int makhachhang)
        {
            var thucdon = qltc.ThucDonKHChons.Where(d => d.MaKhachHang == makhachhang).FirstOrDefault();
            return thucdon.MaThucDon.ToString();
        }

        public string laymagoidichvu(int makhachhang)
        {
            var goidichvu = qltc.GoiDichVuKHChons.Where(d => d.MaKhachHang == makhachhang).FirstOrDefault();
            return goidichvu.MaGoiDichVuKHChon.ToString();
        }

        public List<Modelss.Framework.Mon_An> laylistmonan(int mathucdon)
        {
            return (from a in qltc.ChiTietThucDonKHChons
                    from b in qltc.Mon_An

                    where a.MaThucDon == mathucdon && a.MaMonAn == b.MaMonAn
                    select b).ToList();
        }

        public List<Modelss.Framework.DichVu> laylistdichvu(int magoidichvu)
        {

            var listdichvu = (from a in qltc.ChiTietGoiDichVuKHChons
                              from b in qltc.DichVus
                              where a.MaDichVu == b.MaDichVu && a.MaGoiDichVuKHChon == magoidichvu
                              select b.GiaTien).ToList();

            int tongtiendv = 0;


            for (int i = 0; i < listdichvu.Count; i++)
            {
                tongtiendv = tongtiendv + int.Parse(listdichvu[i]);

            }


            ViewBag.tinhtiendichvu = tongtiendv.ToString();



            return (from a in qltc.ChiTietGoiDichVuKHChons
                    from b in qltc.DichVus

                    where a.MaGoiDichVuKHChon == magoidichvu && a.MaDichVu == b.MaDichVu
                    select b).ToList();
        }

        public void setViewBag(int? selectedid = null)
        {
            var model = new Modelss.Code.ThongTinSanhModel();
            ViewBag.sanhID = new SelectList(model.ListThongTinSanh(), "MaSanh", "TenSanh", selectedid);

        }

        public ActionResult xoaHetMonAn()
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string mathucdonkh = (from a in ql.ThucDonKHChons
                                  where a.MaKhachHang == session.id
                                  select a.MaThucDon).SingleOrDefault().ToString();

            List<Modelss.Model.ChiTietThucDonKHChon> listcttd = ql.ChiTietThucDonKHChons.Where(d => d.MaThucDon == Convert.ToInt32(mathucdonkh)).ToList();

            for (int i = 0; i < listcttd.Count; i++)
            {
                ql.ChiTietThucDonKHChons.DeleteOnSubmit(listcttd[i]);
                ql.SubmitChanges();

            }




            return RedirectToAction("Index", "HoSoKH");
        }

        public ActionResult xoaHetDichVu()
        {
            Modelss.Model.QLTCDataContext ql = new Modelss.Model.QLTCDataContext();

            var session = (Modelss.Common.UserLogin)Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION];

            string magoidichvukh = (from a in ql.GoiDichVuKHChons
                                    where a.MaKhachHang == session.id
                                    select a.MaGoiDichVuKHChon).SingleOrDefault().ToString();

            List<Modelss.Model.ChiTietGoiDichVuKHChon> listcttd = ql.ChiTietGoiDichVuKHChons.Where(d => d.MaGoiDichVuKHChon == Convert.ToInt32(magoidichvukh)).ToList();

            for (int i = 0; i < listcttd.Count; i++)
            {
                ql.ChiTietGoiDichVuKHChons.DeleteOnSubmit(listcttd[i]);
                ql.SubmitChanges();

            }


            return RedirectToAction("Index", "HoSoKH");
        }




    }
}
