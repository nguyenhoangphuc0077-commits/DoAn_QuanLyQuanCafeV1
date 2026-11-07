using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Services
{
    /// <summary>
    /// Lớp hỗ trợ kiểm tra tính hợp lệ của dữ liệu nhập trên giao diện
    /// Đảm nhiệm bởi: Nguyễn Hoàng Phúc (Phần chung Giai đoạn 1)
    /// Đáp ứng yêu cầu: Bắt lỗi không rỗng, đúng kiểu số bằng TryParse, không trùng mã,
    /// hiển thị thông báo lỗi và tự động đưa con trỏ Focus() về ô bị sai.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Kiểm tra ô TextBox không được để trống
        /// </summary>
        public static bool KiemTraRong(TextBox txt, string tenTruong)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                MessageBox.Show($"Trường '{tenTruong}' không được để trống!", "Cảnh báo nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                txt.SelectAll();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra ComboBox đã được chọn phần tử hợp lệ hay chưa
        /// </summary>
        public static bool KiemTraChon(ComboBox cbo, string tenTruong)
        {
            if (cbo.SelectedIndex < 0 || cbo.SelectedItem == null || string.IsNullOrWhiteSpace(cbo.Text))
            {
                MessageBox.Show($"Vui lòng chọn '{tenTruong}'!", "Cảnh báo nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra ô nhập số tiền / số thực bằng TryParse và giá trị phải >= 0
        /// </summary>
        public static bool KiemTraSoThucDuong(TextBox txt, string tenTruong, out decimal ketQua, bool choPhepBangKhong = true)
        {
            ketQua = 0;
            string text = txt.Text.Trim().Replace(",", "").Replace(".", ""); // Chuẩn hóa bỏ dấu chấm phẩy nếu người dùng nhập có format

            if (!decimal.TryParse(txt.Text.Trim(), out ketQua) && !decimal.TryParse(text, out ketQua))
            {
                MessageBox.Show($"Trường '{tenTruong}' phải là số hợp lệ!", "Lỗi định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt.Focus();
                txt.SelectAll();
                return false;
            }

            if (choPhepBangKhong ? ketQua < 0 : ketQua <= 0)
            {
                string yeuCau = choPhepBangKhong ? "lớn hơn hoặc bằng 0" : "lớn hơn 0";
                MessageBox.Show($"Trường '{tenTruong}' phải {yeuCau}!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                txt.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Kiểm tra mã không được trùng với các mã đã có trong danh sách
        /// </summary>
        public static bool KiemTraTrungMa(TextBox txt, IEnumerable<string> danhSachMaHienTai, string tenTruong)
        {
            string maNhap = txt.Text.Trim();
            bool daTonTai = danhSachMaHienTai.Any(m => string.Equals(m, maNhap, StringComparison.OrdinalIgnoreCase));

            if (daTonTai)
            {
                MessageBox.Show($"Mã '{maNhap}' cho {tenTruong} đã tồn tại trong hệ thống. Vui lòng chọn mã khác!", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                txt.SelectAll();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Hộp thoại xác nhận hành động nguy hiểm (Xóa, Thoát, Hủy)
        /// Theo yêu cầu CLO2: Hộp thoại chuẩn MessageBox hỏi xác nhận khi xóa/thoát
        /// </summary>
        public static bool XacNhan(string thongDiep, string tieuDe = "Xác nhận")
        {
            DialogResult dr = MessageBox.Show(thongDiep, tieuDe, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes;
        }
    }
}
