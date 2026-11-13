using System;

namespace QuanLyQuanCafe.Models
{
    public class ChiTietHoaDon
    {
        public string SoHD { get; set; } = string.Empty;
        public string MaMon { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietHoaDon() { }

        public ChiTietHoaDon(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 6)
            {
                SoHD = parts[0].Trim();
                MaMon = parts[1].Trim();
                Size = parts[2].Trim();
                int.TryParse(parts[3].Trim(), out var sl);
                SoLuong = sl;
                decimal.TryParse(parts[4].Trim(), out var dg);
                DonGia = dg;
                decimal.TryParse(parts[5].Trim(), out var tt);
                ThanhTien = tt != 0 ? tt : (SoLuong * DonGia);
            }
        }

        public string ToLine()
        {
            decimal tt = ThanhTien != 0 ? ThanhTien : (SoLuong * DonGia);
            return $"{SoHD};{MaMon};{Size};{SoLuong};{DonGia};{tt}";
        }
    }
}
