using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmThanhToan : Form
    {
        private readonly string soHDCurrent;
        private readonly string maBanCurrent;
        private readonly string dataDir = Path.Combine(Application.StartupPath, "Data");
        private decimal _tongGoc;
        private decimal _tongThanhToan;

        public frmThanhToan(string soHD, string maBan)
        {
            InitializeComponent();
            soHDCurrent = soHD;
            maBanCurrent = maBan;
        }

        public frmThanhToan()
        {
            InitializeComponent();
            soHDCurrent = "HD01";
            maBanCurrent = "B03";
        }

        private void frmThanhToan_Load(object? sender, EventArgs e)
        {
            lblSoHD.Text = "Số HĐ: " + soHDCurrent;
            lblMaBan.Text = "Bàn: " + maBanCurrent;
            LoadChiTietMon();
            TinhTien();
        }

        private void LoadChiTietMon()
        {
            lvwChiTiet.View = View.Details;
            lvwChiTiet.FullRowSelect = true;
            lvwChiTiet.GridLines = true;
            lvwChiTiet.Columns.Clear();
            lvwChiTiet.Columns.Add("Tên Món", 130);
            lvwChiTiet.Columns.Add("Size", 50);
            lvwChiTiet.Columns.Add("Số lượng", 70);
            lvwChiTiet.Columns.Add("Đơn giá", 90);
            lvwChiTiet.Columns.Add("Thành tiền", 100);

            lvwChiTiet.Items.Clear();
            string pathCT = Path.Combine(dataDir, "chitiethoadon.txt");
            if (File.Exists(pathCT))
            {
                var lines = File.ReadAllLines(pathCT, Encoding.UTF8);
                bool isHeader = true;
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (isHeader && line.StartsWith("SoHD;")) { isHeader = false; continue; }
                    isHeader = false;

                    var ct = new ChiTietHoaDon(line);
                    if (string.Equals(ct.SoHD, soHDCurrent, StringComparison.OrdinalIgnoreCase))
                    {
                        string tenMon = Services.DataService.Instance.DanhSachMon
                            .FirstOrDefault(m => string.Equals(m.Ma, ct.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? ct.MaMon;

                        var item = new ListViewItem(tenMon)
                        {
                            Tag = ct
                        };
                        item.SubItems.Add(ct.Size);
                        item.SubItems.Add(ct.SoLuong.ToString());
                        item.SubItems.Add(ct.DonGia.ToString("N0"));
                        item.SubItems.Add(ct.ThanhTien.ToString("N0"));
                        lvwChiTiet.Items.Add(item);
                    }
                }
            }
        }

        private void TinhTien()
        {
            _tongGoc = 0;
            foreach (ListViewItem item in lvwChiTiet.Items)
            {
                if (item.Tag is ChiTietHoaDon ct)
                {
                    _tongGoc += ct.ThanhTien;
                }
            }

            decimal.TryParse(txtGiamGia.Text.Trim(), out decimal giamGia);
            if (giamGia < 0) giamGia = 0;
            if (giamGia > 100) giamGia = 100;

            _tongThanhToan = _tongGoc * (1 - giamGia / 100);
            lblTongTien.Text = _tongThanhToan.ToString("N0") + " VNĐ";

            TinhTienThoi();
        }

        private void TinhTienThoi()
        {
            string rawKhach = txtTienKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawKhach, out decimal khachDua))
            {
                decimal thoi = khachDua - _tongThanhToan;
                lblTienThoi.Text = thoi >= 0 ? thoi.ToString("N0") + " VNĐ" : "Chưa đủ tiền!";
                lblTienThoi.ForeColor = thoi >= 0 ? System.Drawing.Color.DarkGreen : System.Drawing.Color.Red;
            }
            else
            {
                lblTienThoi.Text = "0 VNĐ";
                lblTienThoi.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtGiamGia_TextChanged(object? sender, EventArgs e) => TinhTien();
        private void txtTienKhachDua_TextChanged(object? sender, EventArgs e) => TinhTienThoi();

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            try
            {
                string rawKhach = txtTienKhachDua.Text.Replace(",", "").Replace(".", "").Trim();
                if (!decimal.TryParse(rawKhach, out decimal khachDua) || khachDua < _tongThanhToan)
                {
                    MessageBox.Show("Tiền khách đưa chưa đủ để hoàn tất thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienKhachDua.Focus();
                    return;
                }

                string pathHD = Path.Combine(dataDir, "hoadon.txt");
                if (File.Exists(pathHD))
                {
                    var lines = File.ReadAllLines(pathHD, Encoding.UTF8);
                    var newLines = new List<string>();
                    decimal.TryParse(txtGiamGia.Text.Trim(), out decimal giamGiaVal);

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        if (line.TrimStart('\uFEFF', ' ').StartsWith("SoHD;", StringComparison.OrdinalIgnoreCase))
                        {
                            newLines.Add(line);
                            continue;
                        }

                        var hd = new HoaDon(line);
                        if (string.Equals(hd.SoHD, soHDCurrent, StringComparison.OrdinalIgnoreCase))
                        {
                            hd.GioRa = DateTime.Now;
                            hd.GiamGia = giamGiaVal;
                            hd.TongTien = _tongThanhToan;
                            hd.TrangThai = "Đã thanh toán";
                            newLines.Add(hd.ToLine());
                        }
                        else
                        {
                            newLines.Add(line);
                        }
                    }
                    File.WriteAllLines(pathHD, newLines, Encoding.UTF8);
                }

                string pathBan = Path.Combine(dataDir, "ban.txt");
                if (File.Exists(pathBan))
                {
                    var banLines = File.ReadAllLines(pathBan, Encoding.UTF8);
                    var newBanLines = new List<string>();
                    foreach (string bline in banLines)
                    {
                        if (string.IsNullOrWhiteSpace(bline)) continue;
                        string clean = bline.TrimStart('\uFEFF', ' ').Trim();
                        if (clean.StartsWith("Ma;", StringComparison.OrdinalIgnoreCase))
                        {
                            newBanLines.Add(bline);
                            continue;
                        }

                        string[] parts = bline.Split(';');
                        if (parts.Length >= 4 && string.Equals(parts[0].Trim(), maBanCurrent, StringComparison.OrdinalIgnoreCase))
                        {
                            newBanLines.Add($"{parts[0]};{parts[1]};{parts[2]};Trống");
                        }
                        else
                        {
                            newBanLines.Add(bline);
                        }
                    }
                    File.WriteAllLines(pathBan, newBanLines, Encoding.UTF8);
                }

                decimal.TryParse(txtGiamGia.Text.Trim(), out decimal ggInVal);
                var sfd = new SaveFileDialog
                {
                    Filter = "Text file (*.txt)|*.txt",
                    FileName = $"HoaDon_{soHDCurrent}.txt"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                    sw.WriteLine("========================================");
                    sw.WriteLine("            QUÁN CÀ PHÊ                 ");
                    sw.WriteLine("         HÓA ĐƠN THANH TOÁN             ");
                    sw.WriteLine("========================================");
                    sw.WriteLine($"Số HĐ    : {soHDCurrent}");
                    sw.WriteLine($"Bàn      : {maBanCurrent}");
                    sw.WriteLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sw.WriteLine("----------------------------------------");
                    sw.WriteLine(string.Format("{0,-15} {1,5} {2,6} {3,12}", "Món", "Size", "SL", "Thành tiền"));
                    sw.WriteLine("----------------------------------------");
                    foreach (ListViewItem item in lvwChiTiet.Items)
                    {
                        if (item.Tag is ChiTietHoaDon ct)
                        {
                            sw.WriteLine(string.Format("{0,-15} {1,5} {2,6} {3,12:N0}", item.Text, ct.Size, ct.SoLuong, ct.ThanhTien));
                        }
                    }
                    sw.WriteLine("----------------------------------------");
                    sw.WriteLine($"Tổng tiền gốc  : {_tongGoc:N0} VNĐ");
                    sw.WriteLine($"Giảm giá       : {ggInVal}%");
                    sw.WriteLine($"Tổng thanh toán: {_tongThanhToan:N0} VNĐ");
                    sw.WriteLine($"Tiền khách đưa : {khachDua:N0} VNĐ");
                    sw.WriteLine($"Tiền thối lại  : {(khachDua - _tongThanhToan):N0} VNĐ");
                    sw.WriteLine("========================================");
                    sw.WriteLine("     CẢM ƠN QUÝ KHÁCH, HẸN GẶP LẠI!     ");
                    sw.WriteLine("========================================");
                }

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTachHD_Click(object? sender, EventArgs e)
        {
            using var frm = new frmTachHoaDon(soHDCurrent, maBanCurrent);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Tải lại chi tiết món sau khi tách
                LoadChiTietMon();
                TinhTien();

                if (frm.MoThanhToanNgay && !string.IsNullOrEmpty(frm.SoHDMoi))
                {
                    using var frmTT = new frmThanhToan(frm.SoHDMoi, frm.MaBanDich);
                    frmTT.ShowDialog(this);
                }
            }
        }

        private void btnHuy_Click(object? sender, EventArgs e) => this.Close();
    }
}
