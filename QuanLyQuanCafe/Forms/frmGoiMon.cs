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
    public partial class frmGoiMon : Form
    {
        private readonly string _tenBan;
        private List<Mon> _dsMonHienThi = new List<Mon>();

        public Mon? MonDuocChon { get; private set; }
        public string SizeDuocChon { get; private set; } = "M";
        public int SoLuongDuocChon { get; private set; } = 1;
        public decimal DonGiaDuocChon { get; private set; }
        public decimal ThanhTienDuocChon => SoLuongDuocChon * DonGiaDuocChon;
        public string GhiChuDuocChon { get; private set; } = string.Empty;

        public frmGoiMon(string tenBan)
        {
            InitializeComponent();
            _tenBan = string.IsNullOrWhiteSpace(tenBan) ? "Bàn" : tenBan;
        }

        public frmGoiMon() : this("Bàn")
        {
        }

        private void frmGoiMon_Load(object? sender, EventArgs e)
        {
            lblTieuDe.Text = $"GỌI MÓN CHO: {_tenBan.ToUpper()}";

            NapDanhSachDanhMuc();
            LocDanhSachMonTheoDanhMuc();
        }

        private void NapDanhSachDanhMuc()
        {
            cboDanhMuc.Items.Clear();
            cboDanhMuc.Items.Add(new DanhMuc("ALL", "--- Tất cả danh mục ---"));

            foreach (var dm in DataService.Instance.DanhSachDanhMuc)
            {
                cboDanhMuc.Items.Add(dm);
            }

            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.SelectedIndex = 0;
        }

        private void LocDanhSachMonTheoDanhMuc()
        {
            string maDM = "ALL";
            if (cboDanhMuc.SelectedItem is DanhMuc dm)
            {
                maDM = dm.MaDM;
            }

            if (maDM == "ALL")
            {
                _dsMonHienThi = DataService.Instance.DanhSachMon.Where(m => m.ConBan).ToList();
            }
            else
            {
                _dsMonHienThi = DataService.Instance.DanhSachMon
                    .Where(m => m.ConBan && string.Equals(m.MaDanhMuc, maDM, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            cboMon.DataSource = null;
            cboMon.DataSource = _dsMonHienThi;
            cboMon.DisplayMember = "Ten";

            if (_dsMonHienThi.Count > 0)
            {
                cboMon.SelectedIndex = 0;
            }
            else
            {
                picMon.Image?.Dispose();
                picMon.Image = null;
                lblDonGia.Text = "0 VNĐ";
                lblThanhTien.Text = "0 VNĐ";
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LocDanhSachMonTheoDanhMuc();
        }

        private void cboMon_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CapNhatThongTinMonDuocChon();
        }

        private void CapNhatThongTinMonDuocChon()
        {
            if (cboMon.SelectedItem is not Mon mon)
            {
                picMon.Image?.Dispose();
                picMon.Image = null;
                lblDonGia.Text = "0 VNĐ";
                lblThanhTien.Text = "0 VNĐ";
                return;
            }

            // Hien thi anh mon
            try
            {
                picMon.Image?.Dispose();
                picMon.Image = null;

                if (!string.IsNullOrWhiteSpace(mon.Anh))
                {
                    string imgPath = Path.Combine(Application.StartupPath, "Data", "Images", mon.Anh);
                    if (File.Exists(imgPath))
                    {
                        byte[] imgBytes = File.ReadAllBytes(imgPath);
                        using var ms = new MemoryStream(imgBytes);
                        picMon.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                picMon.Image = null;
            }

            // Cap nhat nhan size theo chieu doc ro rang, khong de bi che khuat
            rdoSizeS.Text = $"Size S ({mon.GiaS:N0} đ)";
            rdoSizeM.Text = $"Size M ({mon.GiaM:N0} đ)";
            rdoSizeL.Text = $"Size L ({mon.GiaL:N0} đ)";

            TinhTienHienThi();
        }

        private void rdoSize_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is RadioButton rdo && rdo.Checked)
            {
                TinhTienHienThi();
            }
        }

        private void nudSoLuong_ValueChanged(object? sender, EventArgs e)
        {
            TinhTienHienThi();
        }

        private void TinhTienHienThi()
        {
            if (cboMon.SelectedItem is not Mon mon) return;

            string size = "M";
            if (rdoSizeS.Checked) size = "S";
            else if (rdoSizeL.Checked) size = "L";

            decimal donGia = mon.LayGiaTheoSize(size);
            int soLuong = (int)nudSoLuong.Value;
            decimal thanhTien = soLuong * donGia;

            lblDonGia.Text = donGia.ToString("N0") + " VNĐ";
            lblThanhTien.Text = thanhTien.ToString("N0") + " VNĐ";
        }

        private void btnXacNhan_Click(object? sender, EventArgs e)
        {
            if (cboMon.SelectedItem is not Mon mon)
            {
                MessageBox.Show("Vui lòng chọn một món ăn hoặc đồ uống từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MonDuocChon = mon;
            SizeDuocChon = rdoSizeS.Checked ? "S" : (rdoSizeL.Checked ? "L" : "M");
            SoLuongDuocChon = (int)nudSoLuong.Value;
            DonGiaDuocChon = mon.LayGiaTheoSize(SizeDuocChon);
            GhiChuDuocChon = txtGhiChu.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
