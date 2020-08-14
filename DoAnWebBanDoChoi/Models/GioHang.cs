using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnWebBanDoChoi.Models;

namespace DoAnWebBanDoChoi.Models
{
    public class GioHang
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public int iMaDC { get; set; }

        public string sTenDC { get; set; }

        public string sAnhBia { get; set; }

        public double dDonGia { get; set; }

        public int iSoLuong { get; set; }

        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(int maDC)
        {
            iMaDC = maDC;
            DoChoi dochoi = data.DoChois.Single(m => m.MaDC == maDC);
            sTenDC = dochoi.TenDC;
            sAnhBia = dochoi.AnhBia;
            dDonGia = double.Parse(dochoi.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}