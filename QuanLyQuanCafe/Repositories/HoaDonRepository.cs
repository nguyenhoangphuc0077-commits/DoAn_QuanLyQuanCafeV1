using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Repositories
{
    public class HoaDonRepository
    {
        private readonly string _pathHD = Path.Combine(Application.StartupPath, "Data", "hoadon.txt");
        private readonly string _pathCT = Path.Combine(Application.StartupPath, "Data", "chitiethoadon.txt");
        private static readonly string[] DateFormats = new string[]
        {
            "dd/MM/yyyy HH:mm:ss",
            "dd/MM/yyyy HH:mm",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm"
        };

        private static DateTime ParseDate(string? str)
        {
            if (string.IsNullOrWhiteSpace(str)) return DateTime.Now;
            str = str.Trim();
            if (DateTime.TryParseExact(str, DateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out var d))
                return d;
            if (DateTime.TryParse(str, CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                return d;
            if (DateTime.TryParse(str, out d))
                return d;
            return DateTime.Now;
        }

        public List<ChiTietHoaDon> GetChiTietByMaBan(string maBan)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            if (!File.Exists(_pathHD) || !File.Exists(_pathCT)) return list;

            string? soHD = null;
            using (var sr = new StreamReader(_pathHD, Encoding.UTF8))
            {
                string? line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isHeader && line.StartsWith("SoHD;")) { isHeader = false; continue; }
                    isHeader = false;

                    var parts = line.Split(';');
                    if (parts.Length >= 7 && parts[1].Trim() == maBan && parts[6].Trim() == "Chưa thanh toán")
                    {
                        soHD = parts[0].Trim();
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(soHD)) return list;

            using (var sr = new StreamReader(_pathCT, Encoding.UTF8))
            {
                string? line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isHeader && line.StartsWith("SoHD;")) { isHeader = false; continue; }
                    isHeader = false;

                    var parts = line.Split(';');
                    if (parts.Length >= 6 && parts[0].Trim() == soHD)
                    {
                        int.TryParse(parts[3].Trim(), out var sl);
                        decimal.TryParse(parts[4].Trim(), out var dg);
                        decimal.TryParse(parts[5].Trim(), out var tt);
                        list.Add(new ChiTietHoaDon
                        {
                            SoHD = parts[0].Trim(),
                            MaMon = parts[1].Trim(),
                            Size = parts[2].Trim(),
                            SoLuong = sl,
                            DonGia = dg,
                            ThanhTien = tt != 0 ? tt : (sl * dg)
                        });
                    }
                }
            }
            return list;
        }

        public HoaDon? GetHoaDonChuaThanhToan(string maBan)
        {
            if (!File.Exists(_pathHD)) return null;
            using (var sr = new StreamReader(_pathHD, Encoding.UTF8))
            {
                string? line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isHeader && line.StartsWith("SoHD;")) { isHeader = false; continue; }
                    isHeader = false;

                    var parts = line.Split(';');
                    if (parts.Length >= 7 && parts[1].Trim() == maBan && parts[6].Trim() == "Chưa thanh toán")
                    {
                        decimal.TryParse(parts[4].Trim(), out var gg);
                        decimal.TryParse(parts[5].Trim(), out var tt);
                        return new HoaDon
                        {
                            SoHD = parts[0].Trim(),
                            MaBan = parts[1].Trim(),
                            GioVao = ParseDate(parts[2]),
                            GiamGia = gg,
                            TongTien = tt,
                            TrangThai = parts[6].Trim()
                        };
                    }
                }
            }
            return null;
        }

        public Dictionary<string, HoaDon> GetTatCaHoaDonChuaThanhToan()
        {
            var dict = new Dictionary<string, HoaDon>(StringComparer.OrdinalIgnoreCase);
            if (!File.Exists(_pathHD)) return dict;

            try
            {
                using var sr = new StreamReader(_pathHD, Encoding.UTF8);
                string? line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isHeader && line.StartsWith("SoHD;")) { isHeader = false; continue; }
                    isHeader = false;

                    var parts = line.Split(';');
                    if (parts.Length >= 7 && parts[6].Trim() == "Chưa thanh toán")
                    {
                        string maBan = parts[1].Trim();
                        if (!dict.ContainsKey(maBan))
                        {
                            decimal.TryParse(parts[4].Trim(), out var gg);
                            decimal.TryParse(parts[5].Trim(), out var tt);
                            dict[maBan] = new HoaDon
                            {
                                SoHD = parts[0].Trim(),
                                MaBan = maBan,
                                GioVao = ParseDate(parts[2]),
                                GiamGia = gg,
                                TongTien = tt,
                                TrangThai = parts[6].Trim()
                            };
                        }
                    }
                }
            }
            catch
            {
            }
            return dict;
        }

        public void DoiMaBanHoaDon(string soHD, string maBanMoi)
        {
            if (!File.Exists(_pathHD)) return;
            List<string> lines = new List<string>(File.ReadAllLines(_pathHD, Encoding.UTF8));
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var parts = lines[i].Split(';');
                if (parts.Length >= 7 && parts[0].Trim() == soHD.Trim())
                {
                    parts[1] = maBanMoi;
                    lines[i] = string.Join(";", parts);
                    break;
                }
            }
            File.WriteAllLines(_pathHD, lines, Encoding.UTF8);
        }

        public void TaoHoaDonMoi(string soHD, string maBan)
        {
            if (!File.Exists(_pathHD))
            {
                File.WriteAllText(_pathHD, "SoHD;MaBan;GioVao;GioRa;GiamGia;TongTien;TrangThai\n", Encoding.UTF8);
            }

            using var sw = new StreamWriter(_pathHD, true, Encoding.UTF8);
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            sw.WriteLine($"{soHD};{maBan};{thoiGian};;0;0;Chưa thanh toán");
        }

        public void ThemChiTietHoaDon(string soHD, string maMon, string size, int soLuong, decimal donGia)
        {
            if (!File.Exists(_pathCT))
            {
                File.WriteAllText(_pathCT, "SoHD;MaMon;Size;SoLuong;DonGia;ThanhTien\n", Encoding.UTF8);
            }

            using var sw = new StreamWriter(_pathCT, true, Encoding.UTF8);
            decimal thanhTien = soLuong * donGia;
            sw.WriteLine($"{soHD};{maMon};{size};{soLuong};{donGia};{thanhTien}");
        }

        public List<HoaDon> LoadAllHoaDon()
        {
            var list = new List<HoaDon>();
            if (!File.Exists(_pathHD)) return list;
            using var sr = new StreamReader(_pathHD, Encoding.UTF8);
            string? line;
            bool isHeader = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (isHeader && line.TrimStart('\uFEFF', ' ').StartsWith("SoHD;", StringComparison.OrdinalIgnoreCase))
                {
                    isHeader = false;
                    continue;
                }
                isHeader = false;
                try
                {
                    list.Add(new HoaDon(line));
                }
                catch { }
            }
            return list;
        }

        public List<ChiTietHoaDon> LoadAllChiTiet()
        {
            var list = new List<ChiTietHoaDon>();
            if (!File.Exists(_pathCT)) return list;
            using var sr = new StreamReader(_pathCT, Encoding.UTF8);
            string? line;
            bool isHeader = true;
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (isHeader && line.TrimStart('\uFEFF', ' ').StartsWith("SoHD;", StringComparison.OrdinalIgnoreCase))
                {
                    isHeader = false;
                    continue;
                }
                isHeader = false;
                try
                {
                    list.Add(new ChiTietHoaDon(line));
                }
                catch { }
            }
            return list;
        }

        public List<ChiTietHoaDon> GetChiTietBySoHD(string soHD)
        {
            return LoadAllChiTiet().FindAll(c => string.Equals(c.SoHD, soHD, StringComparison.OrdinalIgnoreCase));
        }

        public void SaveAllHoaDon(List<HoaDon> list)
        {
            using var sw = new StreamWriter(_pathHD, false, Encoding.UTF8);
            sw.WriteLine("SoHD;MaBan;GioVao;GioRa;GiamGia;TongTien;TrangThai");
            foreach (var hd in list)
            {
                sw.WriteLine(hd.ToLine());
            }
        }

        public void SaveAllChiTiet(List<ChiTietHoaDon> list)
        {
            using var sw = new StreamWriter(_pathCT, false, Encoding.UTF8);
            sw.WriteLine("SoHD;MaMon;Size;SoLuong;DonGia;ThanhTien");
            foreach (var ct in list)
            {
                sw.WriteLine(ct.ToLine());
            }
        }

        public bool TachHoaDon(string soHDCu, string soHDMoi, string maBanDich, List<ChiTietHoaDon> dsMonTach)
        {
            if (dsMonTach == null || dsMonTach.Count == 0) return false;

            var dsHD = LoadAllHoaDon();
            var dsCT = LoadAllChiTiet();

            var hdCu = dsHD.Find(h => string.Equals(h.SoHD, soHDCu, StringComparison.OrdinalIgnoreCase));
            if (hdCu == null) return false;

            var hdMoi = new HoaDon
            {
                SoHD = soHDMoi,
                MaBan = maBanDich,
                GioVao = DateTime.Now,
                GiamGia = 0,
                TongTien = 0,
                TrangThai = "Chưa thanh toán"
            };
            dsHD.Add(hdMoi);

            foreach (var monTach in dsMonTach)
            {
                var dongGoc = dsCT.Find(c => string.Equals(c.SoHD, soHDCu, StringComparison.OrdinalIgnoreCase)
                                           && string.Equals(c.MaMon, monTach.MaMon, StringComparison.OrdinalIgnoreCase)
                                           && string.Equals(c.Size, monTach.Size, StringComparison.OrdinalIgnoreCase));

                if (dongGoc != null)
                {
                    if (dongGoc.SoLuong > monTach.SoLuong)
                    {
                        dongGoc.SoLuong -= monTach.SoLuong;
                        dongGoc.ThanhTien = dongGoc.SoLuong * dongGoc.DonGia;

                        dsCT.Add(new ChiTietHoaDon
                        {
                            SoHD = soHDMoi,
                            MaMon = monTach.MaMon,
                            Size = monTach.Size,
                            SoLuong = monTach.SoLuong,
                            DonGia = monTach.DonGia,
                            ThanhTien = monTach.SoLuong * monTach.DonGia
                        });
                    }
                    else
                    {
                        dongGoc.SoHD = soHDMoi;
                    }
                }
            }

            decimal tongCu = 0;
            foreach (var c in dsCT.FindAll(c => string.Equals(c.SoHD, soHDCu, StringComparison.OrdinalIgnoreCase)))
            {
                tongCu += c.ThanhTien;
            }
            hdCu.TongTien = tongCu * (1 - hdCu.GiamGia / 100);

            decimal tongMoi = 0;
            foreach (var c in dsCT.FindAll(c => string.Equals(c.SoHD, soHDMoi, StringComparison.OrdinalIgnoreCase)))
            {
                tongMoi += c.ThanhTien;
            }
            hdMoi.TongTien = tongMoi;

            SaveAllHoaDon(dsHD);
            SaveAllChiTiet(dsCT);

            return true;
        }
    }
}
