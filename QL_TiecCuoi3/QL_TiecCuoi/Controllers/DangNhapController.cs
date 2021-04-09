using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Code;
using Modelss.Framework;

namespace QL_TiecCuoi.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /DangNhap/
        QLTCdbContext qltc = new QLTCdbContext();


        public ActionResult Index()
        {
   
            return View();
        }
        public ActionResult DangXuat()
        {
            Session[Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION] = null;
            Session[Modelss.Common.CommonConstans.MaTaiKhoan_SESSTION] = null;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Index(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                
                var kq = xuLiDangNhap(model.tendangnhap, model.matkhau);
                if (kq == 1)
                {
                    var user = laytaikhoantheoid(model.tendangnhap);
                    var usersession = new Modelss.Common.UserLogin();
                    usersession.tendangnhap = user.TenDangNhap;
                    usersession.id = user.MaTaiKhoan;
                    
                    Session.Add(Modelss.Common.CommonConstans.TENDANGNHAP_SESSTION, usersession);

                    Modelss.Common.CommonConstans.TenTaiKhoan = model.tendangnhap;
                 
                    return RedirectToAction("Index", "TrangChu");

                }
                else
                {
                    ModelState.AddModelError("","Tài khoản không tồn tại!");
                }
                

            }
            else
            {
 
            }

            return View(model);
        }
        public int xuLiDangNhap(string tendangnhap, string matkhau)
        {
            var result = qltc.KhachHangs.Count(d => d.TenDangNhap == tendangnhap && d.MatKhau == matkhau);
            return result;

        }
        public Modelss.Framework.KhachHang laytaikhoantheoid(string tendangnhap)
        {
            var result = (from a in qltc.KhachHangs
                          where a.TenDangNhap == tendangnhap
                          select a).FirstOrDefault();
            return result;

        }
       

    }
}
