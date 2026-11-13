using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Repositories;
using QuanLyQuanCafe.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmTachHoaDon : Form
    {
        private readonly string _soHDGoc;
        private readonly string _maBanGoc;
        private readonly HoaDonRepository _repoHD = new HoaDonRepository();
        private readonly BanRepository _repoBan = new BanRepository();

        private List<ChiTietHoaDon> _dsNguon = new List<ChiTietHoaDon>();
        private List<ChiTietHoaDon> _dsDich = new List<ChiTietHoaDon>();

        public string SoHDMoi { get; private set; } = string.Empty;
        public string MaBanDich { get; private set; } = string.Empty;
        public bool MoThanhToanNgay { get; private set; } = false;

        public frmTachHoaDon(string soHD, string maBan)
        {
            InitializeComponent();
            _soHDGoc = soHD;
            _maBanGoc = maBan;
        }

        private void frmTachHoaDon_Load(object? sender, EventArgs e)
        {
            lblTieuDe.Text = $"TÁCH HÓA ĐƠN [{_soHDGoc}] - BÀN {_maBanGoc}";
            grpNguon.Text = $"Hóa đơn gốc: {_soHDGoc} (Bàn {_maBanGoc})";

            NapDuLieuBanDau();
            NapDanhSachBanTrong();
            HienThiDanhSach();
        }

        private void NapDuLieuBanDau()
        {
            var items = _repoHD.GetChiTietBySoHD(_soHDGoc);
            if (items.Count == 0)
            {
                items = _repoHD.GetChiTietByMaBan(_maBanGoc);
            }

            _dsNguon.Clear();
            _dsDich.Clear();

            foreach (var item in items)
            {
                _dsNguon.Add(new ChiTietHoaDon
                {
                    SoHD = item.SoHD,
                    MaMon = item.MaMon,
                    Size = item.Size,
                    SoLuong = item.SoLuong,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien
                });
            }
        }

        private void NapDanhSachBanTrong()
        {
            var dsBan = _repoBan.LoadAll();
            cboBanTrong.Items.Clear();
            foreach (var b in dsBan.Where(b => b.TrangThai == "Trống" && b.Ma != _maBanGoc))
            {
                cboBanTrong.Items.Add(b.Ten + " (" + b.Ma + ")");
            }

            if (cboBanTrong.Items.Count > 0)
            {
                cboBanTrong.SelectedIndex = 0;
            }
        }

        private void rdoGiuBan_CheckedChanged(object? sender, EventArgs e)
        {
            cboBanTrong.Enabled = rdoSangBanMoi.Checked;
        }

        private void rdoSangBanMoi_CheckedChanged(object? sender, EventArgs e)
        {
            cboBanTrong.Enabled = rdoSangBanMoi.Checked;
        }

        private void HienThiDanhSach()
        {
            lvwNguon.Items.Clear();
            foreach (var ct in _dsNguon)
            {
                string tenMon = DataService.Instance.DanhSachMon
                    .FirstOrDefault(m => string.Equals(m.Ma, ct.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? ct.MaMon;

                var lvi = new ListViewItem(tenMon) { Tag = ct };
                lvi.SubItems.Add(ct.Size);
                lvi.SubItems.Add(ct.SoLuong.ToString());
                lvi.SubItems.Add(ct.DonGia.ToString("N0"));
                lvi.SubItems.Add(ct.ThanhTien.ToString("N0"));
                lvwNguon.Items.Add(lvi);
            }

            lvwDich.Items.Clear();
            decimal tongTach = 0;
            foreach (var ct in _dsDich)
            {
                string tenMon = DataService.Instance.DanhSachMon
                    .FirstOrDefault(m => string.Equals(m.Ma, ct.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? ct.MaMon;

                var lvi = new ListViewItem(tenMon) { Tag = ct };
                lvi.SubItems.Add(ct.Size);
                lvi.SubItems.Add(ct.SoLuong.ToString());
                lvi.SubItems.Add(ct.DonGia.ToString("N0"));
                lvi.SubItems.Add(ct.ThanhTien.ToString("N0"));
                lvwDich.Items.Add(lvi);

                tongTach += ct.ThanhTien;
            }

            lblTongTienTach.Text = $"Tách: {tongTach:N0} đ";
        }

        private void btnChuyen1_Click(object? sender, EventArgs e)
        {
            if (lvwNguon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món cần tách từ danh sách bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ct = lvwNguon.SelectedItems[0].Tag as ChiTietHoaDon;
            if (ct == null) return;

            ChuyenMon(ct, 1);
            HienThiDanhSach();
        }

        private void btnChuyenHet_Click(object? sender, EventArgs e)
        {
            if (lvwNguon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món cần tách từ danh sách bên trái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ct = lvwNguon.SelectedItems[0].Tag as ChiTietHoaDon;
            if (ct == null) return;

            ChuyenMon(ct, ct.SoLuong);
            HienThiDanhSach();
        }

        private void ChuyenMon(ChiTietHoaDon ct, int soLuongChuyen)
        {
            if (soLuongChuyen <= 0) return;

            // Tìm xem bên đích đã có món này chưa
            var dich = _dsDich.FirstOrDefault(c => c.MaMon == ct.MaMon && c.Size == ct.Size);
            if (dich != null)
            {
                dich.SoLuong += soLuongChuyen;
                dich.ThanhTien = dich.SoLuong * dich.DonGia;
            }
            else
            {
                _dsDich.Add(new ChiTietHoaDon
                {
                    SoHD = "",
                    MaMon = ct.MaMon,
                    Size = ct.Size,
                    SoLuong = soLuongChuyen,
                    DonGia = ct.DonGia,
                    ThanhTien = soLuongChuyen * ct.DonGia
                });
            }

            ct.SoLuong -= soLuongChuyen;
            ct.ThanhTien = ct.SoLuong * ct.DonGia;

            if (ct.SoLuong <= 0)
            {
                _dsNguon.Remove(ct);
            }
        }

        private void btnTraLai1_Click(object? sender, EventArgs e)
        {
            if (lvwDich.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần trả lại từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ct = lvwDich.SelectedItems[0].Tag as ChiTietHoaDon;
            if (ct == null) return;

            TraLaiMon(ct, 1);
            HienThiDanhSach();
        }

        private void btnTraLaiHet_Click(object? sender, EventArgs e)
        {
            if (lvwDich.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần trả lại từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var ct = lvwDich.SelectedItems[0].Tag as ChiTietHoaDon;
            if (ct == null) return;

            TraLaiMon(ct, ct.SoLuong);
            HienThiDanhSach();
        }

        private void TraLaiMon(ChiTietHoaDon ct, int soLuongTra)
        {
            if (soLuongTra <= 0) return;

            var nguon = _dsNguon.FirstOrDefault(c => c.MaMon == ct.MaMon && c.Size == ct.Size);
            if (nguon != null)
            {
                nguon.SoLuong += soLuongTra;
                nguon.ThanhTien = nguon.SoLuong * nguon.DonGia;
            }
            else
            {
                _dsNguon.Add(new ChiTietHoaDon
                {
                    SoHD = _soHDGoc,
                    MaMon = ct.MaMon,
                    Size = ct.Size,
                    SoLuong = soLuongTra,
                    DonGia = ct.DonGia,
                    ThanhTien = soLuongTra * ct.DonGia
                });
            }

            ct.SoLuong -= soLuongTra;
            ct.ThanhTien = ct.SoLuong * ct.DonGia;

            if (ct.SoLuong <= 0)
            {
                _dsDich.Remove(ct);
            }
        }

        private void btnXacNhan_Click(object? sender, EventArgs e)
        {
            if (_dsDich.Count == 0)
            {
                MessageBox.Show("Chưa có món nào được chọn để tách sang hóa đơn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maBanMoi = _maBanGoc;
            if (rdoSangBanMoi.Checked)
            {
                if (cboBanTrong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn trống đích để chuyển món sang!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sel = cboBanTrong.SelectedItem.ToString() ?? "";
                int open = sel.LastIndexOf('(');
                int close = sel.LastIndexOf(')');
                if (open >= 0 && close > open)
                {
                    maBanMoi = sel.Substring(open + 1, close - open - 1).Trim();
                }
            }

            string newSoHD = "HD" + DateTime.Now.ToString("ddHHmmss");
            bool success = _repoHD.TachHoaDon(_soHDGoc, newSoHD, maBanMoi, _dsDich);

            if (success)
            {
                if (rdoSangBanMoi.Checked && maBanMoi != _maBanGoc)
                {
                    _repoBan.CapNhatTrangThai(maBanMoi, "Có khách");
                }

                SoHDMoi = newSoHD;
                MaBanDich = maBanMoi;

                var dr = MessageBox.Show(
                    $"Tách hóa đơn thành công!\n- Hóa đơn mới: {newSoHD}\n- Bàn: {maBanMoi}\n- Tổng tiền: {lblTongTienTach.Text}\n\nBạn có muốn mở ngay Form Thanh toán cho hóa đơn vừa tách không?",
                    "Tách hóa đơn hoàn tất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                MoThanhToanNgay = (dr == DialogResult.Yes);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể thực hiện tách hóa đơn. Vui lòng kiểm tra lại dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
