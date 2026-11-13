using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Models
{
    internal class HoaDon
    {
        public string SoHD { get; set; } = string.Empty;
        public string MaBan { get; set; } = string.Empty;
        public DateTime GioVao { get; set; }
        public DateTime GioRa { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } = string.Empty;

        public HoaDon() { }

        public HoaDon(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 7)
            {
                SoHD = parts[0];
                MaBan = parts[1];
                DateTime.TryParse(parts[2], out var gv); GioVao = gv;
                DateTime.TryParse(parts[3], out var gr); GioRa = gr;
                decimal.TryParse(parts[4], out var gg); GiamGia = gg;
                decimal.TryParse(parts[5], out var tt); TongTien = tt;
                TrangThai = parts[6];
            }
        }

        public string ToLine()
        {
            return $"{SoHD};{MaBan};{GioVao:dd/MM/yyyy HH:mm:ss};{GioRa:dd/MM/yyyy HH:mm:ss};{GiamGia};{TongTien};{TrangThai}";
        }
    }
}
