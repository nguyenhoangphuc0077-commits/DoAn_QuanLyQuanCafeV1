using System;

namespace QuanLyQuanCafe.Models
{
    /// <summary>
    /// Thực thể Danh mục món ăn / thức uống
    /// Phụ trách: Nguyễn Hoàng Phúc (SV1)
    /// </summary>
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

        /// <summary>
        /// Bắt buộc có ToString() theo yêu cầu chuẩn CLO1
        /// </summary>
        public override string ToString()
        {
            return TenDM;
        }

        /// <summary>
        /// Chuyển đối tượng thành dòng văn bản phân tách bằng dấu chấm phẩy
        /// </summary>
        public string ToCsvLine()
        {
            return $"{MaDM};{TenDM}";
        }

        /// <summary>
        /// Phân tích một dòng văn bản thành đối tượng DanhMuc
        /// </summary>
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
