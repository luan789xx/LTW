using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebBanDoChoi.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace DoAnWebBanDoChoi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Login", "Admin");
            return View();
        }
        public ActionResult Out()
        {
            Session["Taikhoanadmin"] = null;
            return RedirectToAction("Index", "DoChoi");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["pass"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult DoChoi(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            var list = db.DoChois.OrderBy(a => a.MaDC).ToList();
            return View(list.ToPagedList(pageNumber,pageSize));
            //return View(db.DoChois.ToList());
        }

        [HttpGet]
        public ActionResult ThemMoiDC()
        {
            ViewBag.MaLoai = new SelectList(db.Loais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaXX = new SelectList(db.XuatXus.ToList().OrderBy(n => n.TenXX), "MaXX", "TenXX");
            ViewBag.MaTH = new SelectList(db.ThuongHieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");
            ViewBag.MaCL = new SelectList(db.ChatLieus.ToList().OrderBy(n => n.TenCL), "MaCL", "TenCL");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiDC(DoChoi dc, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLoai = new SelectList(db.Loais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai");
            ViewBag.MaXX = new SelectList(db.XuatXus.ToList().OrderBy(n => n.TenXX), "MaXX", "TenXX");
            ViewBag.MaTH = new SelectList(db.ThuongHieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH");
            ViewBag.MaCL = new SelectList(db.ChatLieus.ToList().OrderBy(n => n.TenCL), "MaCL", "TenCL");

            if(fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if(ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    dc.AnhBia = filename;

                    db.DoChois.InsertOnSubmit(dc);
                    db.SubmitChanges();
                }
                return RedirectToAction("DoChoi");
            }
        }

        public ActionResult ChiTietDC(int id)
        {
            DoChoi dochoi = db.DoChois.SingleOrDefault(n => n.MaDC == id);
            ViewBag.MaDC = dochoi.MaDC;
            if(dochoi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dochoi);
        }

        [HttpGet]
        public ActionResult XoaDC(int id)
        {
            DoChoi dochoi = db.DoChois.SingleOrDefault(n => n.MaDC == id);
            ViewBag.MaDC = dochoi.MaDC;
            if (dochoi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dochoi);
        }

        [HttpPost,ActionName("XoaDC")]
        public ActionResult Xacnhanxoa(int id)
        {
            DoChoi dochoi = db.DoChois.SingleOrDefault(n => n.MaDC == id);
            ViewBag.MaDC = dochoi.MaDC;
            if (dochoi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DoChois.DeleteOnSubmit(dochoi);
            db.SubmitChanges();
            return RedirectToAction("DoChoi");
        }

        [HttpGet]
        public ActionResult SuaDC(int id)
        {
            DoChoi dochoi = db.DoChois.SingleOrDefault(n => n.MaDC == id);
            if (dochoi == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLoai = new SelectList(db.Loais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai",dochoi.MaLoai);
            ViewBag.MaXX = new SelectList(db.XuatXus.ToList().OrderBy(n => n.TenXX), "MaXX", "TenXX", dochoi.MaXX);
            ViewBag.MaTH = new SelectList(db.ThuongHieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH", dochoi.MaTH);
            ViewBag.MaCL = new SelectList(db.ChatLieus.ToList().OrderBy(n => n.TenCL), "MaCL", "TenCL", dochoi.MaCL);

            return View(dochoi);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaDC(DoChoi dochoi, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaLoai = new SelectList(db.Loais.ToList().OrderBy(n => n.TenLoai), "MaLoai", "TenLoai", dochoi.MaLoai);
            ViewBag.MaXX = new SelectList(db.XuatXus.ToList().OrderBy(n => n.TenXX), "MaXX", "TenXX", dochoi.MaXX);
            ViewBag.MaTH = new SelectList(db.ThuongHieus.ToList().OrderBy(n => n.TenTH), "MaTH", "TenTH", dochoi.MaTH);
            ViewBag.MaCL = new SelectList(db.ChatLieus.ToList().OrderBy(n => n.TenCL), "MaCL", "TenCL", dochoi.MaCL);
            DoChoi dc = db.DoChois.SingleOrDefault(n => n.MaDC == dochoi.MaDC);

            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View(dc);
            }
            else
            {
                if(ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                    if(System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }

                    dc.TenDC = dochoi.TenDC;
                    dc.GiaBan = dochoi.GiaBan;
                    dc.MoTa = dochoi.MoTa;
                    dc.NgayCapNhat = dochoi.NgayCapNhat;
                    dc.AnhBia = fileName;
                    dc.SoLuongTon = dochoi.SoLuongTon;
                    dc.MaTH = dochoi.MaTH;
                    dc.MaXX = dochoi.MaXX;
                    dc.MaCL = dochoi.MaCL;
                    dc.MaLoai = dochoi.MaLoai;

                    UpdateModel(dc);
                    db.SubmitChanges();
                }
                return RedirectToAction("DoChoi");
            }
        }

        public ActionResult Loai(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            var list = db.Loais.OrderBy(a => a.MaLoai).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoiLoai()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiLoai(Loai loai)
        {
            db.Loais.InsertOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Loai");
        }

        public ActionResult ChiTietLoai(int id)
        {
            Loai loai = db.Loais.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.MaLoai = loai.MaLoai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(loai);
        }

        [HttpGet]
        public ActionResult XoaLoai(int id)
        {
            Loai loai = db.Loais.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.MaLoai = loai.MaLoai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(loai);
        }

        [HttpPost, ActionName("XoaLoai")]
        public ActionResult Xacnhanxoaloai(int id)
        {
            Loai loai = db.Loais.SingleOrDefault(n => n.MaLoai == id);
            ViewBag.MaLoai = loai.MaLoai;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Loais.DeleteOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("Loai");
        }

        [HttpGet]
        public ActionResult SuaLoai(int id)
        {
            Loai loai = db.Loais.SingleOrDefault(n => n.MaLoai == id);
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(loai);
        }
        [HttpPost, ActionName("SuaLoai")]
        [ValidateInput(false)]
        public ActionResult SuaLoai(Loai loai)
        {
            if (ModelState.IsValid)
            {
                Loai l = db.Loais.SingleOrDefault(n => n.MaLoai == loai.MaLoai);
                l.TenLoai = loai.TenLoai;
                UpdateModel(l);
                db.SubmitChanges();
                
                return RedirectToAction("Loai");
            }
            return View(loai);
        }

        public ActionResult ThuongHieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            var list = db.ThuongHieus.OrderBy(a => a.MaTH).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoiTH()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiTH(ThuongHieu thuonghieu)
        {
            db.ThuongHieus.InsertOnSubmit(thuonghieu);
            db.SubmitChanges();
            return RedirectToAction("ThuongHieu");
        }

        public ActionResult ChiTietTH(int id)
        {
            ThuongHieu thuonghieu = db.ThuongHieus.SingleOrDefault(n => n.MaTH == id);
            ViewBag.MaTH = thuonghieu.MaTH;
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(thuonghieu);
        }

        [HttpGet]
        public ActionResult XoaTH(int id)
        {
            ThuongHieu thuonghieu = db.ThuongHieus.SingleOrDefault(n => n.MaTH == id);
            ViewBag.MaTH = thuonghieu.MaTH;
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(thuonghieu);
        }

        [HttpPost, ActionName("XoaTH")]
        public ActionResult XacnhanxoaTH(int id)
        {
            ThuongHieu thuonghieu = db.ThuongHieus.SingleOrDefault(n => n.MaTH == id);
            ViewBag.MaTH = thuonghieu.MaTH;
            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ThuongHieus.DeleteOnSubmit(thuonghieu);
            db.SubmitChanges();
            return RedirectToAction("ThuongHieu");
        }

        [HttpGet]
        public ActionResult SuaTH(int id)
        {
            ThuongHieu thuonghieu = db.ThuongHieus.SingleOrDefault(n => n.MaTH == id);

            if (thuonghieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(thuonghieu);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaTH(ThuongHieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                ThuongHieu th = db.ThuongHieus.SingleOrDefault(n => n.MaTH == thuonghieu.MaTH);
                th.TenTH = thuonghieu.TenTH;
                UpdateModel(th);
                db.SubmitChanges();

                return RedirectToAction("ThuongHieu");
            }
            return View(thuonghieu);
        }

        public ActionResult XuatXu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            var list = db.XuatXus.OrderBy(a => a.MaXX).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoiXX()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiXX(XuatXu xuatxu)
        {
            db.XuatXus.InsertOnSubmit(xuatxu);
            db.SubmitChanges();
            return RedirectToAction("XuatXu");
        }

        public ActionResult ChiTietXX(int id)
        {
            XuatXu xuatxu = db.XuatXus.SingleOrDefault(n => n.MaXX == id);
            ViewBag.MaXX = xuatxu.MaXX;
            if (xuatxu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(xuatxu);
        }

        [HttpGet]
        public ActionResult XoaXX(int id)
        {
            XuatXu xuatxu = db.XuatXus.SingleOrDefault(n => n.MaXX == id);
            ViewBag.MaXX = xuatxu.MaXX;
            if (xuatxu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(xuatxu);
        }

        [HttpPost, ActionName("XoaXX")]
        public ActionResult XacnhanxoaXX(int id)
        {
            XuatXu xuatxu = db.XuatXus.SingleOrDefault(n => n.MaXX == id);
            ViewBag.MaXX = xuatxu.MaXX;
            if (xuatxu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.XuatXus.DeleteOnSubmit(xuatxu);
            db.SubmitChanges();
            return RedirectToAction("XuatXu");
        }

        [HttpGet]
        public ActionResult SuaXX(int id)
        {
            XuatXu xuatxu = db.XuatXus.SingleOrDefault(n => n.MaXX == id);

            if (xuatxu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(xuatxu);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaXX(XuatXu xuatxu)
        {
            if (ModelState.IsValid)
            {
                XuatXu xx = db.XuatXus.SingleOrDefault(n => n.MaXX == xuatxu.MaXX);
                xx.TenXX = xuatxu.TenXX;
                UpdateModel(xx);
                db.SubmitChanges();

                return RedirectToAction("XuatXu");
            }
            return View(xuatxu);
        }

        public ActionResult ChatLieu(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            var list = db.ChatLieus.OrderBy(a => a.MaCL).ToList();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoiCL()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoiCL(ChatLieu chatlieu)
        {
            db.ChatLieus.InsertOnSubmit(chatlieu);
            db.SubmitChanges();
            return RedirectToAction("ChatLieu");
        }

        public ActionResult ChiTietCL(int id)
        {
            ChatLieu chatlieu = db.ChatLieus.SingleOrDefault(n => n.MaCL == id);
            ViewBag.MaCL = chatlieu.MaCL;
            if (chatlieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chatlieu);
        }

        [HttpGet]
        public ActionResult XoaCL(int id)
        {
            ChatLieu chatlieu = db.ChatLieus.SingleOrDefault(n => n.MaCL == id);
            ViewBag.MaCL = chatlieu.MaCL;
            if (chatlieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chatlieu);
        }

        [HttpPost, ActionName("XoaCL")]
        public ActionResult XacnhanxoaCL(int id)
        {
            ChatLieu chatlieu = db.ChatLieus.SingleOrDefault(n => n.MaCL == id);
            ViewBag.MaCL = chatlieu.MaCL;
            if (chatlieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChatLieus.DeleteOnSubmit(chatlieu);
            db.SubmitChanges();
            return RedirectToAction("ChatLieu");
        }

        [HttpGet]
        public ActionResult SuaCL(int id)
        {
            ChatLieu chatlieu = db.ChatLieus.SingleOrDefault(n => n.MaCL == id);
            ViewBag.MaCL = chatlieu.MaCL;
            if (chatlieu == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chatlieu);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SuaCL(ChatLieu chatlieu)
        {
            if (ModelState.IsValid)
            {
                ChatLieu cl = db.ChatLieus.SingleOrDefault(n => n.MaCL == chatlieu.MaCL);
                cl.TenCL = chatlieu.TenCL;
                UpdateModel(cl);
                db.SubmitChanges();

                return RedirectToAction("ChatLieu");
            }
            return View(chatlieu);
        }


    }
}