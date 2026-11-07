using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Services;

namespace QuanLyQuanCafe.Forms
{
    public partial class FormThucDon : Form
    {
        private bool _isEditing = false;
        private string _currentImageFileName = string.Empty;

        public FormThucDon()
        {
            InitializeComponent();
        }

        private void FormThucDon_Load(object sender, EventArgs e)
        {
            NapDanhSachDanhMucVaoCombobox();
            HienThiDanhSachMon();
            LamMoiForm();
        }

        public void NapDanhSachDanhMucVaoCombobox()
        {
            cboDanhMuc.Items.Clear();
            foreach (var dm in DataService.Instance.DanhSachDanhMuc)
            {
                cboDanhMuc.Items.Add(dm);
            }
            if (cboDanhMuc.Items.Count > 0)
                cboDanhMuc.SelectedIndex = 0;

            string currentFilter = cboLocDanhMuc.SelectedItem?.ToString() ?? string.Empty;
            cboLocDanhMuc.Items.Clear();
            cboLocDanhMuc.Items.Add("-- Tất cả danh mục --");
            foreach (var dm in DataService.Instance.DanhSachDanhMuc)
            {
                cboLocDanhMuc.Items.Add(dm.TenDM);
            }

            int foundIdx = cboLocDanhMuc.FindStringExact(currentFilter);
            cboLocDanhMuc.SelectedIndex = foundIdx >= 0 ? foundIdx : 0;
        }

        private void HienThiDanhSachMon()
        {
            lvwThucDon.Items.Clear();

            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            string filterDM = cboLocDanhMuc.SelectedIndex > 0 ? cboLocDanhMuc.SelectedItem?.ToString() ?? "" : "";

            var danhSach = DataService.Instance.DanhSachMon;

            int soDangBan = 0;
            int soTamHet = 0;

            foreach (var m in danhSach)
            {
                string tenDM = DataService.Instance.LayTenDanhMuc(m.MaDanhMuc);

                if (!string.IsNullOrEmpty(filterDM) && !string.Equals(tenDM, filterDM, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(tuKhoa) &&
                    !m.Ma.ToLower().Contains(tuKhoa) &&
                    !m.Ten.ToLower().Contains(tuKhoa))
                {
                    continue;
                }

                var lvi = new ListViewItem(m.Ma);
                lvi.SubItems.Add(m.Ten);
                lvi.SubItems.Add(tenDM);
                lvi.SubItems.Add(m.GiaS.ToString("N0") + " đ");
                lvi.SubItems.Add(m.GiaM.ToString("N0") + " đ");
                lvi.SubItems.Add(m.GiaL.ToString("N0") + " đ");

                if (m.ConBan)
                {
                    lvi.SubItems.Add("Còn bán");
                    lvi.ForeColor = Color.Black;
                    soDangBan++;
                }
                else
                {
                    lvi.SubItems.Add("TẠM HẾT");
                    lvi.ForeColor = Color.Crimson;
                    lvi.BackColor = Color.FromArgb(255, 235, 238);
                    soTamHet++;
                }

                lvi.SubItems.Add(string.IsNullOrEmpty(m.Anh) ? "(Không)" : m.Anh);
                lvi.Tag = m;

                lvwThucDon.Items.Add(lvi);
            }

            lblTongSoMon.Text = $"Tổng số món: {danhSach.Count} (Hiển thị: {lvwThucDon.Items.Count})";
            lblDangBan.Text = $"| Còn bán: {soDangBan}";
            lblTamHet.Text = $"| Tạm hết: {soTamHet}";
        }

        private void LamMoiForm()
        {
            _isEditing = false;
            txtMaMon.Text = string.Empty;
            txtTenMon.Text = string.Empty;
            txtMaMon.Enabled = true;

            if (cboDanhMuc.Items.Count > 0)
                cboDanhMuc.SelectedIndex = 0;

            txtGiaS.Text = "25000";
            txtGiaM.Text = "30000";
            txtGiaL.Text = "35000";
            radSizeM.Checked = true;

            chkConBan.Checked = true;
            chkConBan.Text = "Đang kinh doanh (Còn bán)";
            chkConBan.ForeColor = Color.DarkGreen;

            _currentImageFileName = string.Empty;
            lblTenFileAnh.Text = "File ảnh: Chưa chọn";
            HienThiAnhMon(string.Empty, string.Empty);

            lvwThucDon.SelectedItems.Clear();
            txtMaMon.Focus();
        }

        private void lvwThucDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwThucDon.SelectedItems.Count > 0)
            {
                var lvi = lvwThucDon.SelectedItems[0];
                if (lvi.Tag is Mon m)
                {
                    _isEditing = true;
                    txtMaMon.Text = m.Ma;
                    txtTenMon.Text = m.Ten;
                    txtMaMon.Enabled = false;

                    for (int i = 0; i < cboDanhMuc.Items.Count; i++)
                    {
                        if (cboDanhMuc.Items[i] is DanhMuc dm && string.Equals(dm.MaDM, m.MaDanhMuc, StringComparison.OrdinalIgnoreCase))
                        {
                            cboDanhMuc.SelectedIndex = i;
                            break;
                        }
                    }

                    txtGiaS.Text = m.GiaS.ToString("F0");
                    txtGiaM.Text = m.GiaM.ToString("F0");
                    txtGiaL.Text = m.GiaL.ToString("F0");

                    chkConBan.Checked = m.ConBan;
                    _currentImageFileName = m.Anh;
                    lblTenFileAnh.Text = string.IsNullOrEmpty(m.Anh) ? "File ảnh: (Không có)" : $"File ảnh: {m.Anh}";

                    HienThiAnhMon(m.Anh, m.Ten);
                    CapNhatXemNhanhGia(this, EventArgs.Empty);
                }
            }
        }

        private void HienThiAnhMon(string fileName, string tenMon)
        {
            try
            {
                if (picMonAn.Image != null)
                {
                    var oldImg = picMonAn.Image;
                    picMonAn.Image = null;
                    oldImg.Dispose();
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(FileHelper.ImagesDirectory, fileName);
                    if (File.Exists(fullPath))
                    {
                        using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                        picMonAn.Image = Image.FromStream(fs);
                        return;
                    }
                }

                picMonAn.Image = TaoAnhPlaceholder(tenMon);
            }
            catch (Exception ex)
            {
                FileHelper.GhiLog("Lỗi hiển thị ảnh trên PictureBox", ex);
                picMonAn.Image = TaoAnhPlaceholder(tenMon);
            }
        }

        private Image TaoAnhPlaceholder(string tenMon)
        {
            var bmp = new Bitmap(180, 155);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(240, 235, 230));
                using var brush = new SolidBrush(Color.FromArgb(120, 80, 60));
                using var fontIcon = new Font("Segoe UI", 28, FontStyle.Bold);
                using var fontText = new Font("Segoe UI", 9, FontStyle.Regular);
                using var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

                g.DrawString("☕", fontIcon, brush, new RectangleF(0, 20, 180, 50), format);
                string text = string.IsNullOrEmpty(tenMon) ? "Chưa có ảnh" : tenMon;
                g.DrawString(text, fontText, brush, new RectangleF(10, 80, 160, 60), format);
            }
            return bmp;
        }

        private void radSize_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatXemNhanhGia(this, EventArgs.Empty);
        }

        private void CapNhatXemNhanhGia(object? sender, EventArgs e)
        {
            string size = radSizeS.Checked ? "S" : (radSizeL.Checked ? "L" : "M");
            string giaStr = radSizeS.Checked ? txtGiaS.Text : (radSizeL.Checked ? txtGiaL.Text : txtGiaM.Text);

            if (decimal.TryParse(giaStr.Trim(), out decimal gia))
            {
                lblXemNhanhGia.Text = $"Đang chọn: Size {size} - {gia:N0} đ";
            }
            else
            {
                lblXemNhanhGia.Text = $"Đang chọn: Size {size} - (Giá chưa hợp lệ)";
            }
        }

        private void chkConBan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConBan.Checked)
            {
                chkConBan.Text = "Đang kinh doanh (Còn bán)";
                chkConBan.ForeColor = Color.DarkGreen;
            }
            else
            {
                chkConBan.Text = "Món tạm hết (Ngừng phục vụ)";
                chkConBan.ForeColor = Color.Crimson;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh minh họa cho món ăn",
                Filter = "Tập tin hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Tất cả tập tin (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ma = string.IsNullOrWhiteSpace(txtMaMon.Text) ? "mon" : txtMaMon.Text.Trim();
                    string ext = Path.GetExtension(ofd.FileName);
                    string newFileName = $"{ma}_{DateTime.Now:yyyyMMddHHmmss}{ext}";
                    string destPath = Path.Combine(FileHelper.ImagesDirectory, newFileName);

                    File.Copy(ofd.FileName, destPath, overwrite: true);
                    _currentImageFileName = newFileName;
                    lblTenFileAnh.Text = $"File ảnh: {newFileName}";

                    HienThiAnhMon(newFileName, txtTenMon.Text.Trim());
                    MessageBox.Show("Tải ảnh món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    FileHelper.GhiLog("Lỗi sao chép ảnh vào thư mục Images", ex);
                    MessageBox.Show($"Không thể tải ảnh: {ex.Message}", "Lỗi tải ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaAnh_Click(object sender, EventArgs e)
        {
            _currentImageFileName = string.Empty;
            lblTenFileAnh.Text = "File ảnh: (Đã xóa)";
            HienThiAnhMon(string.Empty, txtTenMon.Text.Trim());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.KiemTraRong(txtMaMon, "Mã món")) return;
            if (!ValidationHelper.KiemTraRong(txtTenMon, "Tên món")) return;
            if (!ValidationHelper.KiemTraChon(cboDanhMuc, "Danh mục")) return;

            if (!ValidationHelper.KiemTraSoThucDuong(txtGiaS, "Giá Size S", out decimal giaS)) return;
            if (!ValidationHelper.KiemTraSoThucDuong(txtGiaM, "Giá Size M", out decimal giaM, choPhepBangKhong: false)) return;
            if (!ValidationHelper.KiemTraSoThucDuong(txtGiaL, "Giá Size L", out decimal giaL)) return;

            string ma = txtMaMon.Text.Trim();
            string ten = txtTenMon.Text.Trim();
            var dmChon = (DanhMuc)cboDanhMuc.SelectedItem!;
            bool conBan = chkConBan.Checked;

            if (!_isEditing)
            {
                var danhSachMa = DataService.Instance.DanhSachMon.Select(m => m.Ma);
                if (!ValidationHelper.KiemTraTrungMa(txtMaMon, danhSachMa, "Món")) return;

                var monMoi = new Mon(ma, ten, dmChon.MaDM, giaS, giaM, giaL, conBan, _currentImageFileName);
                DataService.Instance.DanhSachMon.Add(monMoi);
            }
            else
            {
                var mon = DataService.Instance.DanhSachMon.FirstOrDefault(m => string.Equals(m.Ma, ma, StringComparison.OrdinalIgnoreCase));
                if (mon != null)
                {
                    mon.Ten = ten;
                    mon.MaDanhMuc = dmChon.MaDM;
                    mon.GiaS = giaS;
                    mon.GiaM = giaM;
                    mon.GiaL = giaL;
                    mon.ConBan = conBan;
                    mon.Anh = _currentImageFileName;
                }
            }

            DataService.Instance.LuuDanhSachMon();
            HienThiDanhSachMon();

            MessageBox.Show("Lưu thông tin món thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LamMoiForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvwThucDon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lvi = lvwThucDon.SelectedItems[0];
            if (lvi.Tag is not Mon mon) return;

            if (ValidationHelper.XacNhan($"Bạn có chắc chắn muốn xóa món '{mon.Ten}' (Mã: {mon.Ma}) khỏi thực đơn?", "Xác nhận xóa món"))
            {
                DataService.Instance.DanhSachMon.Remove(mon);
                DataService.Instance.LuuDanhSachMon();
                HienThiDanhSachMon();
                LamMoiForm();

                MessageBox.Show("Đã xóa món thành công khỏi thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            using var frmDM = new FormQuanLyDanhMuc();
            frmDM.DanhMucUpdated += (s, args) =>
            {
                NapDanhSachDanhMucVaoCombobox();
                HienThiDanhSachMon();
            };
            frmDM.ShowDialog(this);
        }

        private void cboLocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSachMon();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachMon();
        }

        private void btnXuatCsv_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Title = "Xuất danh sách thực đơn ra tập tin CSV",
                Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin văn bản (*.txt)|*.txt",
                FileName = $"ThucDon_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string header = "Mã món;Tên món;Mã danh mục;Giá Size S;Giá Size M;Giá Size L;Còn bán;Hình ảnh";
                bool thanhCong = FileHelper.XuatCsv(sfd.FileName, header, DataService.Instance.DanhSachMon, m => m.ToCsvLine());

                if (thanhCong)
                {
                    MessageBox.Show($"Xuất danh sách thực đơn thành công!\nĐường dẫn: {sfd.FileName}",
                        "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xuất file CSV. Vui lòng kiểm tra file log.txt!",
                        "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNhapCsv_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn file CSV thực đơn để nhập dữ liệu",
                Filter = "Tập tin CSV (*.csv)|*.csv|Tập tin văn bản (*.txt)|*.txt|Tất cả tập tin (*.*)|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var dsMoi = FileHelper.NhapCsv(ofd.FileName, Mon.FromCsvLine, boQuaTieuDe: true, out int soThanhCong, out int soLoi);

                if (dsMoi.Count > 0)
                {
                    int themMoi = 0;
                    int capNhat = 0;

                    foreach (var monMoi in dsMoi)
                    {
                        var exist = DataService.Instance.DanhSachMon.FirstOrDefault(m => string.Equals(m.Ma, monMoi.Ma, StringComparison.OrdinalIgnoreCase));
                        if (exist != null)
                        {
                            exist.Ten = monMoi.Ten;
                            exist.MaDanhMuc = monMoi.MaDanhMuc;
                            exist.GiaS = monMoi.GiaS;
                            exist.GiaM = monMoi.GiaM;
                            exist.GiaL = monMoi.GiaL;
                            exist.ConBan = monMoi.ConBan;
                            exist.Anh = monMoi.Anh;
                            capNhat++;
                        }
                        else
                        {
                            DataService.Instance.DanhSachMon.Add(monMoi);
                            themMoi++;
                        }
                    }

                    DataService.Instance.LuuDanhSachMon();
                    HienThiDanhSachMon();

                    string thongBao = $"Nhập dữ liệu thành công:\n- Thêm mới: {themMoi} món\n- Cập nhật: {capNhat} món";
                    if (soLoi > 0)
                    {
                        thongBao += $"\n- Có {soLoi} dòng lỗi định dạng (đã ghi chi tiết vào log.txt)";
                    }

                    MessageBox.Show(thongBao, "Kết quả nhập CSV", MessageBoxButtons.OK,
                        soLoi > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hợp lệ nào được nhập từ file CSV!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnMoPhaChe_Click(object sender, EventArgs e)
        {
            var frm = new FormPhaChe();
            frm.Show();
        }
    }
}
