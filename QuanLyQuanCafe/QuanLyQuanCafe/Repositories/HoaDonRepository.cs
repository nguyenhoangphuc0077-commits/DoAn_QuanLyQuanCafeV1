using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Models.QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Repositories
{
    public class HoaDonRepository
    {
        private string _pathHD = Path.Combine(Application.StartupPath, "Data", "hoadon.txt");
        private string _pathCT = Path.Combine(Application.StartupPath, "Data", "chitiethoadon.txt");

        public List<ChiTietHoaDon> GetChiTietByMaBan(string maBan)
        {
            List<ChiTietHoaDon> list = new List<ChiTietHoaDon>();
            if (!File.Exists(_pathHD) || !File.Exists(_pathCT)) return list;

            // 1. Tìm hóa đơn chưa thanh toán của bàn
            string soHD = null;
            using (StreamReader sr = new StreamReader(_pathHD, Encoding.UTF8))
            {
                string line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isHeader) { isHeader = false; continue; }
                    var parts = line.Split(';');
                    if (parts.Length >= 7 && parts[1] == maBan && parts[6] == "Chưa thanh toán")
                    {
                        soHD = parts[0];
                        break;
                    }
                }
            }

            if (soHD == null) return list;

            // 2. Lấy các món của hóa đơn đó
            using (StreamReader sr = new StreamReader(_pathCT, Encoding.UTF8))
            {
                string line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isHeader) { isHeader = false; continue; }
                    var parts = line.Split(';');
                    if (parts.Length >= 6 && parts[0] == soHD)
                    {
                        list.Add(new ChiTietHoaDon
                        {
                            SoHD = parts[0],
                            MaMon = parts[1],
                            Size = parts[2],
                            SoLuong = int.Parse(parts[3]),
                            DonGia = decimal.Parse(parts[4])
                        });
                    }
                }
            }
            return list;
        }
            // Lấy hóa đơn chưa thanh toán của bàn
        public HoaDon GetHoaDonChuaThanhToan(string maBan)
        {
            if (!File.Exists(_pathHD)) return null;
            using (StreamReader sr = new StreamReader(_pathHD, Encoding.UTF8))
            {
                string line;
                bool isHeader = true;
                while ((line = sr.ReadLine()) != null)
                {
                    if (isHeader) { isHeader = false; continue; }
                    var parts = line.Split(';');
                    if (parts.Length >= 7 && parts[1] == maBan && parts[6] == "Chưa thanh toán")
                    {
                        return new HoaDon
                        {
                            SoHD = parts[0],
                            MaBan = parts[1],
                            GioVao = DateTime.Parse(parts[2]),
                            GiamGia = decimal.Parse(parts[4]),
                            TongTien = decimal.Parse(parts[5]),
                            TrangThai = parts[6]
                        };
                    }
                }
            }
            return null;
        }
        // Đổi mã bàn của hóa đơn (Dùng cho Chuyển bàn / Gộp bàn)
        public void DoiMaBanHoaDon(string soHD, string maBanMoi)
        {
            if (!File.Exists(_pathHD)) return;
            List<string> lines = new List<string>(File.ReadAllLines(_pathHD, Encoding.UTF8));
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                var parts = lines[i].Split(';');
                if (parts.Length >= 7 && parts[0] == soHD)
                {
                    parts[1] = maBanMoi; // Cập nhật mã bàn mới
                    lines[i] = string.Join(";", parts);
                    break;
                }
            }
            File.WriteAllLines(_pathHD, lines, Encoding.UTF8);
        }
        // Hàm tạo hóa đơn mới
        public void TaoHoaDonMoi(string soHD, string maBan)
        {
            if (!File.Exists(_pathHD)) return;
            using (StreamWriter sw = new StreamWriter(_pathHD, true, Encoding.UTF8))
            {
                // Ghi thêm dòng mới: SoHD;MaBan;GioVao;GioRa;GiamGia;TongTien;TrangThai
                sw.WriteLine($"{soHD};{maBan};{DateTime.Now:dd/MM/yyyy HH:mm};;0;0;Chưa thanh toán");
            }
        }

        // Hàm thêm món vào chi tiết hóa đơn
        public void ThemChiTietHoaDon(string soHD, string maMon, string size, int soLuong, decimal donGia)
        {
            if (!File.Exists(_pathCT)) return;
            using (StreamWriter sw = new StreamWriter(_pathCT, true, Encoding.UTF8))
            {
                decimal thanhTien = soLuong * donGia;
                // Ghi thêm dòng mới: SoHD;MaMon;Size;SoLuong;DonGia;ThanhTien
                sw.WriteLine($"{soHD};{maMon};{size};{soLuong};{donGia};{thanhTien}");
            }
        }  
    }
}

