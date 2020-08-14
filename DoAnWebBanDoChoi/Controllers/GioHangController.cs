using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWebBanDoChoi.Models;

namespace DoAnWebBanDoChoi.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DataClasses1DataContext data = new DataClasses1DataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<GioHang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult ThemGioHang(int iMaDC, string strURL)
        {
            List<GioHang> lstGiohang = LayGioHang();
            GioHang sanpham = lstGiohang.Find(n => n.iMaDC == iMaDC);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaDC);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoLuong);

            }
            return iTongSoLuong;
        }

        private double tinhTongTien()
        {
            double iTongTien = 0;
            List<GioHang> lstGiohang = Session["Giohang"] as List<GioHang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dThanhTien);

            }
            return iTongTien;
        }

        public ActionResult GioHang()
        {
            List<GioHang> lstGiohang = LayGioHang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "DoChoi");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = tinhTongTien();
            return View(lstGiohang);
        }

        public ActionResult GioHangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = tinhTongTien();
            return PartialView();
        }

        public ActionResult XoaGiohang(int iMaSp)
        {
            List<GioHang> lstGiohang = LayGioHang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMaDC == iMaSp);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMaDC == iMaSp);
                return RedirectToAction("GioHang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "DoChoi");

            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapnhatGiohang(int iMaSP, FormCollection f)
        {
            List<GioHang> lstGiohang = LayGioHang();
            GioHang sanpham = lstGiohang.SingleOrDefault(n => n.iMaDC == iMaSP);

            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatcaGiohang()
        {
            List<GioHang> lstGiohang = LayGioHang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "DoChoi");
        }

        [HttpGet]
        public ActionResult Dathang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "DoChoi");
            }

            List<GioHang> lstGiohang = LayGioHang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = tinhTongTien();

            return View(lstGiohang);
        }

        public ActionResult Dathang(FormCollection collection)
        {
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            if(String.IsNullOrEmpty(ngaygiao))
            {
                ViewData["Loi1"] = "Phải chọn ngày giao hàng";
            }
            else
            {

                DonHang dh = new DonHang();
                KhachHang kh = (KhachHang)Session["Taikhoan"];
                List<GioHang> lstGiohang = LayGioHang();
                dh.MaKH = kh.MaKH;
                dh.NgayDat = DateTime.Now; dh.NgayGiao = DateTime.Parse(ngaygiao);
                dh.TinhTrangGiao = null;
                dh.DaThanhToan = null;
                data.DonHangs.InsertOnSubmit(dh);
                data.SubmitChanges();

                foreach (var item in lstGiohang)
                {
                    ChiTietDonHang ctdh = new ChiTietDonHang();
                    ctdh.MaDH = dh.MaDH;
                    ctdh.MaDC = item.iMaDC;
                    ctdh.SoLuong = item.iSoLuong;
                    ctdh.DonGia = (decimal)item.dDonGia;
                    data.ChiTietDonHangs.InsertOnSubmit(ctdh);
                }
                data.SubmitChanges();
                Session["Giohang"] = null;
                return RedirectToAction("Xacnhandonhang", "GioHang");
            }
            return this.Dathang();
        }

        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}