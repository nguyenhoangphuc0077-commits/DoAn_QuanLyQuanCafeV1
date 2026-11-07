using System;

namespace QuanLyQuanCafe.Models
{
    /// <summary>
    /// Thực thể Đơn hàng pha chế dành cho quầy Barista
    /// Phục vụ chức năng nâng cao T2.5 [Màn hình pha chế dùng Timer]
    /// </summary>
    public class DonPhaChe
    {
        public string MaOrder { get; set; } = string.Empty;
        public string MaBan { get; set; } = string.Empty;
        public string TenBan { get; set; } = string.Empty;
        public string MaMon { get; set; } = string.Empty;
        public string TenMon { get; set; } = string.Empty;
        public string Size { get; set; } = "M";
        public int SoLuong { get; set; } = 1;
        public DateTime ThoiGianGoi { get; set; } = DateTime.Now;
        public string GhiChu { get; set; } = string.Empty;
        public string TrangThai { get; set; } = "Chờ pha chế"; // "Chờ pha chế", "Đang pha chế", "Hoàn thành"

        public DonPhaChe() { }

        public DonPhaChe(string maOrder, string maBan, string tenBan, string maMon, string tenMon, string size, int soLuong, string ghiChu = "")
        {
            MaOrder = maOrder;
            MaBan = maBan;
            TenBan = tenBan;
            MaMon = maMon;
            TenMon = tenMon;
            Size = size;
            SoLuong = soLuong;
            ThoiGianGoi = DateTime.Now;
            GhiChu = ghiChu;
            TrangThai = "Chờ pha chế";
        }

        public override string ToString()
        {
            return $"{TenBan} - {TenMon} (Size {Size}) x{SoLuong} [{TrangThai}]";
        }

        public string ToCsvLine()
        {
            return $"{MaOrder};{MaBan};{TenBan};{MaMon};{TenMon};{Size};{SoLuong};{ThoiGianGoi:yyyy-MM-dd HH:mm:ss};{GhiChu};{TrangThai}";
        }

        public static DonPhaChe? FromCsvLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            var parts = line.Split(';');
            if (parts.Length < 9) return null;

            if (!int.TryParse(parts[6].Trim(), out int soLuong)) soLuong = 1;
            if (!DateTime.TryParse(parts[7].Trim(), out DateTime tg)) tg = DateTime.Now;

            string trangThai = parts.Length > 9 ? parts[9].Trim() : "Chờ pha chế";

            return new DonPhaChe
            {
                MaOrder = parts[0].Trim(),
                MaBan = parts[1].Trim(),
                TenBan = parts[2].Trim(),
                MaMon = parts[3].Trim(),
                TenMon = parts[4].Trim(),
                Size = parts[5].Trim(),
                SoLuong = soLuong,
                ThoiGianGoi = tg,
                GhiChu = parts[8].Trim(),
                TrangThai = trangThai
            };
        }
    }
}
