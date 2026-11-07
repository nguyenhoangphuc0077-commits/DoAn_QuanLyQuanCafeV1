using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Services;

namespace QuanLyQuanCafe.Forms
{
    public partial class FormQuanLyDanhMuc : Form
    {
        private bool _isEditing = false;
        public event EventHandler? DanhMucUpdated;

        public FormQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void FormQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
            LamMoiForm();
        }

        private void HienThiDanhSach()
        {
            lvwDanhMuc.Items.Clear();
            var listDM = DataService.Instance.DanhSachDanhMuc;
            var listMon = DataService.Instance.DanhSachMon;

            foreach (var dm in listDM)
            {
                int soLuongMon = listMon.Count(m => string.Equals(m.MaDanhMuc, dm.MaDM, StringComparison.OrdinalIgnoreCase));
                var lvi = new ListViewItem(dm.MaDM);
                lvi.SubItems.Add(dm.TenDM);
                lvi.SubItems.Add(soLuongMon.ToString());
                lvi.Tag = dm;
                lvwDanhMuc.Items.Add(lvi);
            }
        }

        private void LamMoiForm()
        {
            _isEditing = false;
            txtMaDM.Text = string.Empty;
            txtTenDM.Text = string.Empty;
            txtMaDM.Enabled = true;
            lvwDanhMuc.SelectedItems.Clear();
            txtMaDM.Focus();
        }

        private void lvwDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDanhMuc.SelectedItems.Count > 0)
            {
                var lvi = lvwDanhMuc.SelectedItems[0];
                if (lvi.Tag is DanhMuc dm)
                {
                    _isEditing = true;
                    txtMaDM.Text = dm.MaDM;
                    txtTenDM.Text = dm.TenDM;
                    txtMaDM.Enabled = false; // Khi sửa thì không cho đổi khóa chính
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra tính hợp lệ qua ValidationHelper
            if (!ValidationHelper.KiemTraRong(txtMaDM, "Mã danh mục")) return;
            if (!ValidationHelper.KiemTraRong(txtTenDM, "Tên danh mục")) return;

            string ma = txtMaDM.Text.Trim();
            string ten = txtTenDM.Text.Trim();

            if (!_isEditing)
            {
                // Kiểm tra trùng mã
                var danhSachMa = DataService.Instance.DanhSachDanhMuc.Select(d => d.MaDM);
                if (!ValidationHelper.KiemTraTrungMa(txtMaDM, danhSachMa, "Danh mục")) return;

                var dm = new DanhMuc(ma, ten);
                DataService.Instance.DanhSachDanhMuc.Add(dm);
            }
            else
            {
                var dm = DataService.Instance.DanhSachDanhMuc.FirstOrDefault(d => string.Equals(d.MaDM, ma, StringComparison.OrdinalIgnoreCase));
                if (dm != null)
                {
                    dm.TenDM = ten;
                }
            }

            DataService.Instance.LuuDanhSachDanhMuc();
            HienThiDanhSach();
            DanhMucUpdated?.Invoke(this, EventArgs.Empty);

            MessageBox.Show("Lưu thông tin danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwDanhMuc.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lvi = lvwDanhMuc.SelectedItems[0];
            if (lvi.Tag is not DanhMuc dm) return;

            // Kiểm tra xem danh mục có đang chứa món ăn nào không
            if (DataService.Instance.DanhMucDangCoMon(dm.MaDM))
            {
                int count = DataService.Instance.DanhSachMon.Count(m => string.Equals(m.MaDanhMuc, dm.MaDM, StringComparison.OrdinalIgnoreCase));
                MessageBox.Show($"Không thể xóa danh mục '{dm.TenDM}' vì đang có {count} món ăn thuộc danh mục này!\nVui lòng xóa hoặc chuyển các món này sang danh mục khác trước.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (ValidationHelper.XacNhan($"Bạn có chắc chắn muốn xóa danh mục '{dm.TenDM}' (Mã: {dm.MaDM}) không?", "Xác nhận xóa"))
            {
                DataService.Instance.DanhSachDanhMuc.Remove(dm);
                DataService.Instance.LuuDanhSachDanhMuc();
                HienThiDanhSach();
                DanhMucUpdated?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Đã xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoiForm();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

