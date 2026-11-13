using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Models.QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmSoDoBan : Form
    {
        private List<Ban> _dsBan = new List<Ban>();
        private string _filePath = Path.Combine(Application.StartupPath, "Data", "ban.txt");
        private Ban _banDangChon;
        private System.Windows.Forms.Timer tmrCode = new System.Windows.Forms.Timer();

        public frmSoDoBan()
        {
            InitializeComponent();
        }

        private void frmSoDoBan_Load(object sender, EventArgs e)
        {
            DocFileBan();
            LoadComboBox();
            VeSoDoBan(null);
            tmrCode.Interval = 1000; // 1 giây chạy 1 lần
            tmrCode.Tick -= tmrCode_Tick; // Xóa sự kiện cũ (nếu có) để tránh bị trùng
            tmrCode.Tick += tmrCode_Tick;  // Gắn sự kiện mới
            tmrCode.Start(); // Bật
        }

        private void DocFileBan()
        {
            Repositories.BanRepository repo = new Repositories.BanRepository();
            _dsBan = repo.LoadAll();
        }

        private void LoadComboBox()
        {
            cboKhuVuc.Items.Add("Tất cả");
            var khuVucs = new HashSet<string>();
            foreach (var b in _dsBan) khuVucs.Add(b.KhuVuc);
            foreach (var kv in khuVucs) cboKhuVuc.Items.Add(kv);
            cboKhuVuc.SelectedIndex = 0;

            cboKhuVuc.SelectedIndexChanged += (s, ev) => {
                string filter = cboKhuVuc.SelectedItem.ToString();
                VeSoDoBan(filter == "Tất cả" ? null : filter);
            };
        }

        private void VeSoDoBan(string khuVucFilter)
        {
            pnlSoDo.Controls.Clear();
            int x = 10, y = 10;

            foreach (var ban in _dsBan)
            {
                if (khuVucFilter != null && ban.KhuVuc != khuVucFilter) continue;

                Button btn = new Button();
                btn.Text = $"{ban.Ten}\n{ban.TrangThai}";
                btn.Width = 100; btn.Height = 70;
                btn.Left = x; btn.Top = y;
                btn.Tag = ban;
                btn.BackColor = ban.TrangThai == "Trống" ? Color.LightGreen : Color.LightCoral;

                btn.Click += BtnBan_Click;
                btn.MouseDown += BtnBan_MouseDown;
                pnlSoDo.Controls.Add(btn);

                x += 110;
                if (x > pnlSoDo.Width - 100) { x = 10; y += 80; }
            }
        }

        private void BtnBan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;
                _banDangChon = (Ban)btn.Tag;
                cmsBan.Show(btn, e.Location);
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Ban ban = (Ban)btn.Tag;

            lvChiTiet.Items.Clear();

            if (ban.TrangThai == "Trống") return;

            Repositories.HoaDonRepository repo = new Repositories.HoaDonRepository();
            var dsMon = repo.GetChiTietByMaBan(ban.Ma);

            foreach (var mon in dsMon)
            {
                ListViewItem item = new ListViewItem(mon.MaMon);
                item.SubItems.Add(mon.Size);
                item.SubItems.Add(mon.SoLuong.ToString());
                item.SubItems.Add(mon.ThanhTien.ToString("N0"));
                lvChiTiet.Items.Add(item);
            }
        }

        private void miChuyenBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể chuyển bàn đang có khách!", "Thông báo");
                return;
            }

            var dsBanTrong = _dsBan.FindAll(b => b.TrangThai == "Trống");
            if (dsBanTrong.Count == 0)
            {
                MessageBox.Show("Không có bàn trống nào để chuyển!", "Thông báo");
                return;
            }

            using (var frm = new frmChonBan(dsBanTrong, "Chọn bàn trống để chuyển tới"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Ban banDich = frm.BanDuocChon;
                    var repoHD = new Repositories.HoaDonRepository();
                    var hd = repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);

                    if (hd != null)
                    {
                        repoHD.DoiMaBanHoaDon(hd.SoHD, banDich.Ma);
                        var repoBan = new Repositories.BanRepository();
                        repoBan.CapNhatTrangThai(_banDangChon.Ma, "Trống");
                        repoBan.CapNhatTrangThai(banDich.Ma, "Có khách");

                        MessageBox.Show($"Đã chuyển {_banDangChon.Ten} sang {banDich.Ten}", "Thành công");
                        frmSoDoBan_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của bàn này!", "Lỗi");
                    }
                }
            }
        }

        private void miGopBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể gộp bàn đang có khách!", "Thông báo");
                return;
            }

            var dsBanKhach = _dsBan.FindAll(b => b.TrangThai == "Có khách" && b.Ma != _banDangChon.Ma);
            if (dsBanKhach.Count == 0)
            {
                MessageBox.Show("Cần ít nhất 2 bàn có khách để gộp!", "Thông báo");
                return;
            }

            using (var frm = new frmChonBan(dsBanKhach, "Chọn bàn để gộp vào"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Ban banDich = frm.BanDuocChon;
                    var repoHD = new Repositories.HoaDonRepository();
                    var hdNguon = repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
                    var hdDich = repoHD.GetHoaDonChuaThanhToan(banDich.Ma);

                    if (hdNguon != null && hdDich != null)
                    {
                        repoHD.DoiMaBanHoaDon(hdNguon.SoHD, banDich.Ma);
                        var repoBan = new Repositories.BanRepository();
                        repoBan.CapNhatTrangThai(_banDangChon.Ma, "Trống");

                        MessageBox.Show($"Đã gộp {_banDangChon.Ten} vào {banDich.Ten}", "Thành công");
                        frmSoDoBan_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của một trong hai bàn!", "Lỗi");
                    }
                }
            }
        }

        private void miGoiMon_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn trước!", "Thông báo");
                return;
            }

            string maMon = "M01";
            string size = "M";
            int soLuong = 1;
            decimal donGia = 35000;

            var repoHD = new Repositories.HoaDonRepository();
            var hd = repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);

            if (hd == null)
            {
                string newSoHD = "HD" + DateTime.Now.ToString("ddHHmmss");
                repoHD.TaoHoaDonMoi(newSoHD, _banDangChon.Ma);

                var repoBan = new Repositories.BanRepository();
                repoBan.CapNhatTrangThai(_banDangChon.Ma, "Có khách");

                hd = new HoaDon { SoHD = newSoHD, MaBan = _banDangChon.Ma };
            }

            repoHD.ThemChiTietHoaDon(hd.SoHD, maMon, size, soLuong, donGia);

            MessageBox.Show($"Đã gọi món {maMon} cho {_banDangChon.Ten}!", "Thành công");
            frmSoDoBan_Load(sender, e);
        }
        private void tmrCode_Tick(object sender, EventArgs e)
        {
            // Cập nhật tiêu đề để test
            this.Text = "Hệ thống Quản lý Quán Cà Phê - " + DateTime.Now.ToString("HH:mm:ss");

            foreach (Control c in pnlSoDo.Controls)
            {
                if (c is Button btn && btn.Tag is Ban ban)
                {
                    if (ban.TrangThai == "Có khách")
                    {
                        var repoHD = new Repositories.HoaDonRepository();
                        var hd = repoHD.GetHoaDonChuaThanhToan(ban.Ma);

                        if (hd != null)
                        {
                            TimeSpan thoiGianDaNgoi = DateTime.Now - hd.GioVao;
                            // Nếu thời gian âm (do lỗi file txt) thì đưa về 0
                            if (thoiGianDaNgoi.TotalSeconds < 0) thoiGianDaNgoi = TimeSpan.Zero;

                            btn.Text = $"{ban.Ten}\n{ban.TrangThai}\n{(int)thoiGianDaNgoi.TotalHours:00}:{thoiGianDaNgoi.Minutes:00}:{thoiGianDaNgoi.Seconds:00}";
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