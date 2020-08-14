using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebBanDoChoi.Models;
using PagedList;
using PagedList.Mvc;

namespace DoAnWebBanDoChoi.Controllers
{
    public class DoChoiController : Controller
    {
        // GET: DoChoi
        DataClasses1DataContext data = new DataClasses1DataContext();
        private List<DoChoi> LaydochoiMoi(int count)
        {
            return data.DoChois.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }

        public ActionResult Index(int ? page)
        {
            int pageSize = 6;

            int pageNum = (page ?? 1);
            
            var dochoi = LaydochoiMoi(15);
            return View(dochoi.ToPagedList(pageNum, pageSize));
        }
        //[HttpPost]
        public ActionResult Search(int? page, string searchString)
        {
            int pageSize = 6;

            int pageNum = (page ?? 1);

            var dochoi = from s in data.DoChois select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Ten = "'" + searchString + "'";
                dochoi = dochoi.Where(s => s.TenDC.Contains(searchString));
                return View(dochoi.ToPagedList(pageNum, pageSize));
            }
            else
            {
                ViewBag.Ten = " MỚI";
                var dochoi2 = LaydochoiMoi(15);
                return View(dochoi2.ToPagedList(pageNum, pageSize));
            }
        }

        public ActionResult Loai(int? page)
        {
            var loai = from l in data.Loais select l;
            return PartialView(loai);
        }

        public ActionResult Details(int id)
        {
            var Details_Dochoi = data.DoChois.Where(m => m.MaDC == id).First();
            var Loai = data.Loais.Where(l => l.MaLoai == Details_Dochoi.MaLoai).First();
            ViewBag.tenloai = Loai.TenLoai;
            var ThuongHieu = data.ThuongHieus.Where(th => th.MaTH == Details_Dochoi.MaTH).First();
            ViewBag.tenth = ThuongHieu.TenTH;
            var XuatXu = data.XuatXus.Where(xx => xx.MaXX == Details_Dochoi.MaXX).First();
            ViewBag.tenxx = XuatXu.TenXX;
            var ChatLieu = data.ChatLieus.Where(cl => cl.MaCL == Details_Dochoi.MaCL).First();
            ViewBag.tencl = ChatLieu.TenCL;

            return View(Details_Dochoi);
        }

        public ActionResult SPTheoLoai(int id, int? page)
        {
            int pageSize = 6;

            int pageNum = (page ?? 1);
            var SP = data.DoChois.Where(l => l.MaLoai == id).ToList();
            var Loai = data.Loais.Where(n => n.MaLoai == id).First();
            ViewBag.Ma = Loai.TenLoai;
            return View(SP.ToPagedList(pageNum, pageSize));
        }
    }
}