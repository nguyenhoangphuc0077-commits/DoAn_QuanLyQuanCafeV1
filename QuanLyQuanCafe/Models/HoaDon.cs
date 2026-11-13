using System;

namespace QuanLyQuanCafe.Models
{
    public class HoaDon
    {
        public string SoHD { get; set; } = string.Empty;
        public string MaBan { get; set; } = string.Empty;
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } = string.Empty;

        public HoaDon() { }

        public HoaDon(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length >= 7)
            {
                SoHD = parts[0].Trim();
                MaBan = parts[1].Trim();
                
                string[] formats = new string[] { "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm" };
                if (DateTime.TryParseExact(parts[2].Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var gv))
                {
                    GioVao = gv;
                }
                else if (DateTime.TryParse(parts[2].Trim(), out gv))
                {
                    GioVao = gv;
                }

                if (!string.IsNullOrWhiteSpace(parts[3]))
                {
                    if (DateTime.TryParseExact(parts[3].Trim(), formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var gr))
                    {
                        GioRa = gr;
                    }
                    else if (DateTime.TryParse(parts[3].Trim(), out gr))
                    {
                        GioRa = gr;
                    }
                }

                decimal.TryParse(parts[4].Trim(), out var gg);
                GiamGia = gg;

                decimal.TryParse(parts[5].Trim(), out var tt);
                TongTien = tt;

                TrangThai = parts[6].Trim();
            }
        }

        public string ToLine()
        {
            string gioRaStr = GioRa.HasValue ? GioRa.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";
            return $"{SoHD};{MaBan};{GioVao:dd/MM/yyyy HH:mm:ss};{gioRaStr};{GiamGia};{TongTien};{TrangThai}";
        }
    }
}
