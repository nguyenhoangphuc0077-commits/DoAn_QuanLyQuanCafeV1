using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyQuanCafe.Forms
{
    public partial class frmSoDoBan : Form
    {
        private List<Ban> _dsBan = new List<Ban>();
        private string _filePath = Path.Combine(Application.StartupPath, "Data", "ban.txt");
        private Ban _banDangChon; // Lưu bàn đang click chuột phải
        public frmSoDoBan()
        {
            InitializeComponent();
        }

        private void frmSoDoBan_Load(object sender, EventArgs e)
        {
            DocFileBan();
            LoadComboBox();
            VeSoDoBan(null);
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

            cboKhuVuc.SelectedIndexChanged += (s, e) => {
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

                // THÊM DÒNG NÀY ĐỂ BẮT SỰ KIỆN CLICK:
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
                cmsBan.Show(btn, e.Location); // Hiện menu tại vị trí chuột
            }
        }
        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Ban ban = (Ban)btn.Tag;

            lvChiTiet.Items.Clear(); // Xóa dữ liệu cũ

            if (ban.TrangThai == "Trống") return; // Bàn trống thì không có món

            // Gọi Repository để lấy dữ liệu thật từ file txt
            Repositories.HoaDonRepository repo = new Repositories.HoaDonRepository();
            var dsMon = repo.GetChiTietByMaBan(ban.Ma);

            // Đổ dữ liệu ra ListView
            foreach (var mon in dsMon)
            {
                ListViewItem item = new ListViewItem(mon.MaMon); // Tạm hiện Mã món
                item.SubItems.Add(mon.Size);
                item.SubItems.Add(mon.SoLuong.ToString());
                item.SubItems.Add(mon.ThanhTien.ToString("N0"));
                lvChiTiet.Items.Add(item);
            }
        }

        // --- LOGIC CHUYỂN BÀN ---
        private void miChuyenBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể chuyển bàn đang có khách!", "Thông báo");
                return;
            }

            // Lọc ra danh sách các bàn đang TRỐNG
            var dsBanTrong = _dsBan.FindAll(b => b.TrangThai == "Trống");
            if (dsBanTrong.Count == 0)
            {
                MessageBox.Show("Không có bàn trống nào để chuyển!", "Thông báo");
                return;
            }

            // Mở Form chọn bàn
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

        // --- LOGIC GỘP BÀN ---
        private void miGopBan_Click(object sender, EventArgs e)
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể gộp bàn đang có khách!", "Thông báo");
                return;
            }

            // Lọc ra danh sách các bàn đang CÓ KHÁCH (trừ bàn hiện tại)
            var dsBanKhach = _dsBan.FindAll(b => b.TrangThai == "Có khách" && b.Ma != _banDangChon.Ma);
            if (dsBanKhach.Count == 0)
            {
                MessageBox.Show("Cần ít nhất 2 bàn có khách để gộp!", "Thông báo");
                return;
            }

            // Mở Form chọn bàn
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
                        // Chuyển hóa đơn bàn nguồn sang bàn đích
                        repoHD.DoiMaBanHoaDon(hdNguon.SoHD, banDich.Ma);

                        // Bàn nguồn thành trống
                        var repoBan = new Repositories.BanRepository();
                        repoBan.CapNhatTrangThai(_banDangChon.Ma, "Trống");

                        MessageBox.Show($"Đã gộp {_banDangChon.Ten} vào {banDich.Ten}", "Thành công");
                        frmSoDoBan_Load(sender, e);
                    }
                    else // THÊM ĐOẠN ELSE NÀY ĐỂ BÁO LỖI
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của một trong hai bàn!", "Lỗi");
                    }
                }
            }
        }

      
    }
}
