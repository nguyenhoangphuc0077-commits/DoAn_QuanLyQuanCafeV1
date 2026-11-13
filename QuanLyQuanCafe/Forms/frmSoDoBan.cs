using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmSoDoBan : Form
    {
        private List<Ban> _dsBan = new List<Ban>();
        private Ban? _banDangChon;
        private readonly System.Windows.Forms.Timer tmrCode = new System.Windows.Forms.Timer();
        private readonly BanRepository _repoBan = new BanRepository();
        private readonly HoaDonRepository _repoHD = new HoaDonRepository();

        public frmSoDoBan()
        {
            InitializeComponent();
        }

        private void frmSoDoBan_Load(object? sender, EventArgs e)
        {
            DocFileBan();
            LoadComboBox();
            VeSoDoBan(null);

            tmrCode.Interval = 1000;
            tmrCode.Tick -= tmrCode_Tick;
            tmrCode.Tick += tmrCode_Tick;
            tmrCode.Start();
        }

        private void DocFileBan()
        {
            _dsBan = _repoBan.LoadAll();
        }

        private void LoadComboBox()
        {
            cboKhuVuc.Items.Clear();
            cboKhuVuc.Items.Add("Tất cả");
            var khuVucs = new HashSet<string>();
            foreach (var b in _dsBan)
            {
                if (!string.IsNullOrWhiteSpace(b.KhuVuc))
                    khuVucs.Add(b.KhuVuc);
            }
            foreach (var kv in khuVucs) cboKhuVuc.Items.Add(kv);
            cboKhuVuc.SelectedIndex = 0;

            cboKhuVuc.SelectedIndexChanged -= CboKhuVuc_SelectedIndexChanged;
            cboKhuVuc.SelectedIndexChanged += CboKhuVuc_SelectedIndexChanged;
        }

        private void CboKhuVuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? filter = cboKhuVuc.SelectedItem?.ToString();
            VeSoDoBan(filter == "Tất cả" ? null : filter);
        }

        private void VeSoDoBan(string? khuVucFilter)
        {
            pnlSoDo.Controls.Clear();
            int x = 10, y = 10;

            foreach (var ban in _dsBan)
            {
                if (khuVucFilter != null && ban.KhuVuc != khuVucFilter) continue;

                Button btn = new Button
                {
                    Text = $"{ban.Ten}\n{ban.TrangThai}",
                    Width = 110,
                    Height = 75,
                    Left = x,
                    Top = y,
                    Tag = ban,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    BackColor = ban.TrangThai == "Trống" ? Color.LightGreen : Color.LightCoral
                };

                btn.Click += BtnBan_Click;
                btn.MouseDown += BtnBan_MouseDown;
                pnlSoDo.Controls.Add(btn);

                x += 120;
                if (x > pnlSoDo.Width - 110)
                {
                    x = 10;
                    y += 85;
                }
            }
        }

        private void BtnBan_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is Button btn && btn.Tag is Ban ban)
            {
                _banDangChon = ban;
                cmsBan.Show(btn, e.Location);
            }
        }

        private void BtnBan_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not Ban ban) return;
            _banDangChon = ban;

            lvChiTiet.Items.Clear();
            if (ban.TrangThai == "Trống") return;

            var dsMon = _repoHD.GetChiTietByMaBan(ban.Ma);
            foreach (var mon in dsMon)
            {
                ListViewItem item = new ListViewItem(mon.MaMon);
                item.SubItems.Add(mon.Size);
                item.SubItems.Add(mon.SoLuong.ToString());
                item.SubItems.Add(mon.ThanhTien.ToString("N0"));
                lvChiTiet.Items.Add(item);
            }
        }

        private void miChuyenBan_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể chuyển bàn đang có khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dsBanTrong = _dsBan.FindAll(b => b.TrangThai == "Trống");
            if (dsBanTrong.Count == 0)
            {
                MessageBox.Show("Không có bàn trống nào để chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new frmChonBan(dsBanTrong, "Chọn bàn trống để chuyển tới");
            if (frm.ShowDialog(this) == DialogResult.OK && frm.BanDuocChon != null)
            {
                Ban banDich = frm.BanDuocChon;
                var hd = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);

                if (hd != null)
                {
                    _repoHD.DoiMaBanHoaDon(hd.SoHD, banDich.Ma);
                    _repoBan.CapNhatTrangThai(_banDangChon.Ma, "Trống");
                    _repoBan.CapNhatTrangThai(banDich.Ma, "Có khách");

                    MessageBox.Show($"Đã chuyển {_banDangChon.Ten} sang {banDich.Ten}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DocFileBan();
                    string? curFilter = cboKhuVuc.SelectedItem?.ToString();
                    VeSoDoBan(curFilter == "Tất cả" ? null : curFilter);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void miGopBan_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể gộp bàn đang có khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dsBanKhach = _dsBan.FindAll(b => b.TrangThai == "Có khách" && b.Ma != _banDangChon.Ma);
            if (dsBanKhach.Count == 0)
            {
                MessageBox.Show("Cần ít nhất 2 bàn có khách để gộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new frmChonBan(dsBanKhach, "Chọn bàn để gộp vào");
            if (frm.ShowDialog(this) == DialogResult.OK && frm.BanDuocChon != null)
            {
                Ban banDich = frm.BanDuocChon;
                var hdNguon = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
                var hdDich = _repoHD.GetHoaDonChuaThanhToan(banDich.Ma);

                if (hdNguon != null && hdDich != null)
                {
                    _repoHD.DoiMaBanHoaDon(hdNguon.SoHD, banDich.Ma);
                    _repoBan.CapNhatTrangThai(_banDangChon.Ma, "Trống");

                    MessageBox.Show($"Đã gộp {_banDangChon.Ten} vào {banDich.Ten}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DocFileBan();
                    string? curFilter = cboKhuVuc.SelectedItem?.ToString();
                    VeSoDoBan(curFilter == "Tất cả" ? null : curFilter);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của một trong hai bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void miGoiMon_Click(object? sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMon = "CF01";
            string size = "M";
            int soLuong = 1;
            decimal donGia = 29000;

            var hd = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
            if (hd == null)
            {
                string newSoHD = "HD" + DateTime.Now.ToString("ddHHmmss");
                _repoHD.TaoHoaDonMoi(newSoHD, _banDangChon.Ma);
                _repoBan.CapNhatTrangThai(_banDangChon.Ma, "Có khách");
                hd = new HoaDon { SoHD = newSoHD, MaBan = _banDangChon.Ma, GioVao = DateTime.Now };
            }

            _repoHD.ThemChiTietHoaDon(hd.SoHD, maMon, size, soLuong, donGia);

            MessageBox.Show($"Đã gọi món {maMon} cho {_banDangChon.Ten}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DocFileBan();
            string? curFilter = cboKhuVuc.SelectedItem?.ToString();
            VeSoDoBan(curFilter == "Tất cả" ? null : curFilter);
        }

        private void tmrCode_Tick(object? sender, EventArgs e)
        {
            this.Text = "Sơ đồ bàn - Quản lý Quán Cà Phê - " + DateTime.Now.ToString("HH:mm:ss");

            var hoaDonDict = _repoHD.GetTatCaHoaDonChuaThanhToan();

            foreach (Control c in pnlSoDo.Controls)
            {
                if (c is Button btn && btn.Tag is Ban ban)
                {
                    if (ban.TrangThai == "Có khách")
                    {
                        if (hoaDonDict.TryGetValue(ban.Ma, out var hd) && hd != null)
                        {
                            TimeSpan thoiGianDaNgoi = DateTime.Now - hd.GioVao;
                            if (thoiGianDaNgoi.TotalSeconds < 0) thoiGianDaNgoi = TimeSpan.Zero;

                            btn.Text = $"{ban.Ten}\n{ban.TrangThai}\n{(int)thoiGianDaNgoi.TotalHours:00}:{thoiGianDaNgoi.Minutes:00}:{thoiGianDaNgoi.Seconds:00}";
                        }
                        else
                        {
                            btn.Text = $"{ban.Ten}\n{ban.TrangThai}";
                        }
                    }
                    else
                    {
                        btn.Text = $"{ban.Ten}\n{ban.TrangThai}";
                    }
                }
            }
        }
    }
}
