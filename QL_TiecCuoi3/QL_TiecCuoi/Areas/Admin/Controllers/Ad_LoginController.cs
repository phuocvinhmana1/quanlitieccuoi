using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelss.Common;
using Modelss.Code;
using QL_TiecCuoi.Areas.Admin.Models;

namespace QL_TiecCuoi.Areas.Admin.Controllers
{
    public class Ad_LoginController : Controller
    {
        //
        // GET: /Admin/Ad_Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DangNhap();
                var result = dao.Login(model.tenDangNhap, model.matKhau);
                if (result)
                {
                    var user = dao.getTaiKhoan(model.tenDangNhap);
                    var usersesstion = new UserLogin();
                    usersesstion.tendangnhap = user.TenDangNhap;
                    usersesstion.id = user.MaTaiKhoan;

                    Session.Add(CommonConstans.TENDANGNHAP_SESSTION, usersesstion);
                    return RedirectToAction("Index", "Ad_Home");
                }
                else
                {
                    ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng!");
                }
            }

            return View("Index");
        }

    }
}
