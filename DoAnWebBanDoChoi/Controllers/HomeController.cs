using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWebBanDoChoi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Thông tin về shop chúng tôi";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Thông tin liên hệ";

            return View();
        }
    }
}