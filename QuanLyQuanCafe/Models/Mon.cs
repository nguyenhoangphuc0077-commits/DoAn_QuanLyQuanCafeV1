using System;

namespace QuanLyQuanCafe.Models
{
    /// <summary>
    /// Thực thể Món trong thực đơn quán cà phê
    /// Phụ trách: Nguyễn Hoàng Phúc (SV1)
    /// </summary>
    public class Mon
    {
        public string Ma { get; set; } = string.Empty;
        public string Ten { get; set; } = string.Empty;
        public string MaDanhMuc { get; set; } = string.Empty;
        public decimal GiaS { get; set; }
        public decimal GiaM { get; set; }
        public decimal GiaL { get; set; }
        public bool ConBan { get; set; } = true;
        public string Anh { get; set; } = string.Empty;

        public Mon() { }

        public Mon(string ma, string ten, string maDanhMuc, decimal giaS, decimal giaM, decimal giaL, bool conBan = true, string anh = "")
        {
            Ma = ma;
            Ten = ten;
            MaDanhMuc = maDanhMuc;
            GiaS = giaS;
            GiaM = giaM;
            GiaL = giaL;
            ConBan = conBan;
            Anh = anh;
        }

        /// <summary>
        /// Bắt buộc có ToString() theo yêu cầu chuẩn CLO1
        /// </summary>
        public override string ToString()
        {
            string trangThai = ConBan ? "Còn bán" : "Tạm hết";
            return $"{Ten} [Size M: {GiaM:N0} đ] ({trangThai})";
        }

        /// <summary>
        /// Lấy đơn giá theo kích cỡ S, M, L
        /// </summary>
        public decimal LayGiaTheoSize(string size)
        {
            return (size ?? "M").Trim().ToUpper() switch
            {
                "S" => GiaS > 0 ? GiaS : GiaM,
                "L" => GiaL > 0 ? GiaL : GiaM,
                _ => GiaM
            };
        }

        /// <summary>
        /// Định dạng dòng tập tin text phân cách bằng dấu chấm phẩy
        /// Cấu trúc: Ma;Ten;MaDanhMuc;GiaS;GiaM;GiaL;ConBan;Anh
        /// </summary>
        public string ToCsvLine()
        {
            return $"{Ma};{Ten};{MaDanhMuc};{GiaS};{GiaM};{GiaL};{ConBan};{Anh}";
        }

        /// <summary>
        /// Đọc một dòng văn bản và chuyển đổi thành đối tượng Mon
        /// Sử dụng TryParse để bỏ qua dòng lỗi theo yêu cầu kỹ thuật
        /// </summary>
        public static Mon? FromCsvLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;

            var parts = line.Split(';');
            if (parts.Length < 7) return null;

            string ma = parts[0].Trim();
            string ten = parts[1].Trim();
            string maDM = parts[2].Trim();

            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten)) return null;

            if (!decimal.TryParse(parts[3].Trim(), out decimal giaS)) return null;
            if (!decimal.TryParse(parts[4].Trim(), out decimal giaM)) return null;
            if (!decimal.TryParse(parts[5].Trim(), out decimal giaL)) return null;

            if (!bool.TryParse(parts[6].Trim(), out bool conBan))
            {
                // Hỗ trợ trường hợp ghi "1"/"0" hoặc "True"/"False"
                conBan = parts[6].Trim() == "1" || parts[6].Trim().Equals("true", StringComparison.OrdinalIgnoreCase);
            }

            string anh = parts.Length > 7 ? parts[7].Trim() : string.Empty;

            return new Mon
            {
                Ma = ma,
                Ten = ten,
                MaDanhMuc = maDM,
                GiaS = giaS,
                GiaM = giaM,
                GiaL = giaL,
                ConBan = conBan,
                Anh = anh
            };
        }
    }
}
