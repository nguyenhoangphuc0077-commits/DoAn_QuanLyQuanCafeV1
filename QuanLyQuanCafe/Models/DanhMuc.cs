using System;

namespace QuanLyQuanCafe.Models
{
    public class DanhMuc
    {
        public string MaDM { get; set; } = string.Empty;
        public string TenDM { get; set; } = string.Empty;

        public DanhMuc() { }

        public DanhMuc(string maDM, string tenDM)
        {
            MaDM = maDM;
            TenDM = tenDM;
        }

        public override string ToString()
        {
            return TenDM;
        }

        public string ToCsvLine()
        {
            return $"{MaDM};{TenDM}";
        }

        public static DanhMuc? FromCsvLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            var parts = line.Split(';');
            if (parts.Length < 2) return null;

            return new DanhMuc
            {
                MaDM = parts[0].Trim(),
                TenDM = parts[1].Trim()
            };
        }
    }
}
