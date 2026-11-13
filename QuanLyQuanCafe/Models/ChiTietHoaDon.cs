using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Models
{
    internal class ChiTietHoaDon
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
                SoHD = parts[0];
                MaMon = parts[1];
                Size = parts[2];
                int.TryParse(parts[3], out var sl); SoLuong = sl;
                decimal.TryParse(parts[4], out var dg); DonGia = dg;
                decimal.TryParse(parts[5], out var tt); ThanhTien = tt;
            }
        }

        public string ToLine()
        {
            return $"{SoHD};{MaMon};{Size};{SoLuong};{DonGia};{ThanhTien}";
        }
    }
}
