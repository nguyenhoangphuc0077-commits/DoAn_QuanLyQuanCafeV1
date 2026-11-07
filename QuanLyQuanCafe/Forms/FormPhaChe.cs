using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Services;

namespace QuanLyQuanCafe.Forms
{
    public partial class FormPhaChe : Form
    {
        private int _lastCount = 0;

        public FormPhaChe()
        {
            InitializeComponent();
        }

        private void FormPhaChe_Load(object sender, EventArgs e)
        {
            cboLocTrangThai.SelectedIndex = 0;
            lblDongHo.Text = DateTime.Now.ToString("HH:mm:ss");
            timerClock.Start();
            timerAutoRefresh.Start();

            HienThiDanhSachPhaChe();
        }

        private void FormPhaChe_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerClock.Stop();
            timerAutoRefresh.Stop();
        }

        /// <summary>
        /// Timer đồng hồ thực hiện mỗi 1 giây (Chương 3)
        /// Cập nhật đồng hồ và tính lại thời gian chờ của khách theo phút
        /// </summary>
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString("HH:mm:ss");

            // Cập nhật lại cột thời gian chờ trên ListView mà không cần reload toàn bộ
            foreach (ListViewItem item in lvwPhaChe.Items)
            {
                if (item.Tag is DonPhaChe don)
                {
                    var phut = (int)(DateTime.Now - don.ThoiGianGoi).TotalMinutes;
                    item.SubItems[6].Text = $"{phut} phút";

                    // Cảnh báo đỏ nếu khách chờ quá 10 phút chưa có món
                    if (don.TrangThai == "Chờ pha chế" && phut >= 10)
                    {
                        item.BackColor = Color.FromArgb(255, 205, 210); // Đỏ nhạt cảnh báo
                    }
                }
            }
        }

        /// <summary>
        /// Timer tự động quét kiểm tra món mới từ quầy gọi món (Task T2.5)
        /// Chu kỳ 3000ms (3 giây)
        /// </summary>
        private void timerAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (!chkAutoRefresh.Checked) return;

            // Đọc lại file đơn pha chế
            DataService.Instance.NapDanhSachDonPhaChe();
            int currentCount = DataService.Instance.DanhSachDonPhaChe.Count(d => d.TrangThai != "Hoàn thành");

            if (currentCount > _lastCount)
            {
                // Có order mới xuất hiện: phát âm thanh thông báo
                try { SystemSounds.Asterisk.Play(); } catch { }
            }
            _lastCount = currentCount;

            HienThiDanhSachPhaChe(giuViTriChon: true);
        }

        /// <summary>
        /// Hiển thị danh sách món cần pha chế lên ListView
        /// </summary>
        private void HienThiDanhSachPhaChe(bool giuViTriChon = false)
        {
            string? selectedOrderId = null;
            if (giuViTriChon && lvwPhaChe.SelectedItems.Count > 0)
            {
                if (lvwPhaChe.SelectedItems[0].Tag is DonPhaChe don)
                {
                    selectedOrderId = don.MaOrder;
                }
            }

            lvwPhaChe.BeginUpdate();
            lvwPhaChe.Items.Clear();

            string filterStatus = cboLocTrangThai.SelectedIndex > 0 ? cboLocTrangThai.SelectedItem?.ToString() ?? "" : "";
            var danhSach = DataService.Instance.DanhSachDonPhaChe;

            int choPha = 0;
            int dangPha = 0;
            int daXong = 0;

            foreach (var don in danhSach)
            {
                if (don.TrangThai == "Chờ pha chế") choPha++;
                else if (don.TrangThai == "Đang pha chế") dangPha++;
                else if (don.TrangThai == "Hoàn thành") daXong++;

                if (!string.IsNullOrEmpty(filterStatus) && !string.Equals(don.TrangThai, filterStatus, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                int phutCho = (int)(DateTime.Now - don.ThoiGianGoi).TotalMinutes;

                var lvi = new ListViewItem(don.MaOrder);
                lvi.SubItems.Add(don.TenBan);
                lvi.SubItems.Add(don.TenMon);
                lvi.SubItems.Add(don.Size);
                lvi.SubItems.Add(don.SoLuong.ToString());
                lvi.SubItems.Add(don.ThoiGianGoi.ToString("HH:mm:ss"));
                lvi.SubItems.Add($"{phutCho} phút");
                lvi.SubItems.Add(don.GhiChu);
                lvi.SubItems.Add(don.TrangThai);
                lvi.Tag = don;

                // Định dạng màu sắc trực quan cho quầy Barista
                if (don.TrangThai == "Chờ pha chế")
                {
                    lvi.ForeColor = Color.FromArgb(230, 81, 0); // Cam đậm
                    if (phutCho >= 10)
                        lvi.BackColor = Color.FromArgb(255, 205, 210); // Cảnh báo quá lâu
                    else
                        lvi.BackColor = Color.FromArgb(255, 248, 225); // Vàng nhạt
                }
                else if (don.TrangThai == "Đang pha chế")
                {
                    lvi.ForeColor = Color.FromArgb(21, 101, 192); // Xanh dương
                    lvi.BackColor = Color.FromArgb(227, 242, 253);
                    lvi.Font = new Font(lvwPhaChe.Font, FontStyle.Bold);
                }
                else if (don.TrangThai == "Hoàn thành")
                {
                    lvi.ForeColor = Color.FromArgb(46, 125, 50); // Xanh lá
                    lvi.BackColor = Color.FromArgb(232, 245, 233);
                }

                lvwPhaChe.Items.Add(lvi);

                if (selectedOrderId != null && don.MaOrder == selectedOrderId)
                {
                    lvi.Selected = true;
                }
            }

            lvwPhaChe.EndUpdate();

            // Cập nhật thanh trạng thái
            lblTongCho.Text = $"Chờ pha chế: {choPha} món";
            lblDangPha.Text = $"| Đang pha chế: {dangPha} món";
            lblDaXong.Text = $"| Hoàn thành: {daXong} món";
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            timerAutoRefresh.Enabled = chkAutoRefresh.Checked;
            lblTimerInfo.Text = chkAutoRefresh.Checked
                ? "| Timer tự động cập nhật: ĐANG HOẠT ĐỘNG (3s)"
                : "| Timer tự động cập nhật: ĐÃ TẮT";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DataService.Instance.NapDanhSachDonPhaChe();
            HienThiDanhSachPhaChe();
        }

        private void cboLocTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiDanhSachPhaChe();
        }

        private void btnBatDauPha_Click(object sender, EventArgs e)
        {
            if (lvwPhaChe.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món cần pha chế từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lvi = lvwPhaChe.SelectedItems[0];
            if (lvi.Tag is DonPhaChe don)
            {
                don.TrangThai = "Đang pha chế";
                DataService.Instance.LuuDanhSachDonPhaChe();
                HienThiDanhSachPhaChe(giuViTriChon: true);
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if (lvwPhaChe.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món đã hoàn thành từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lvi = lvwPhaChe.SelectedItems[0];
            if (lvi.Tag is DonPhaChe don)
            {
                don.TrangThai = "Hoàn thành";
                DataService.Instance.LuuDanhSachDonPhaChe();
                HienThiDanhSachPhaChe(giuViTriChon: true);
                MessageBox.Show($"Đã hoàn thành món '{don.TenMon}' cho {don.TenBan}!", "Hoàn tất món", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (lvwPhaChe.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món muốn hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var lvi = lvwPhaChe.SelectedItems[0];
            if (lvi.Tag is not DonPhaChe don) return;

            if (ValidationHelper.XacNhan($"Bạn có chắc chắn muốn hủy món '{don.TenMon}' của {don.TenBan}?", "Xác nhận hủy món"))
            {
                DataService.Instance.DanhSachDonPhaChe.Remove(don);
                DataService.Instance.LuuDanhSachDonPhaChe();
                HienThiDanhSachPhaChe();
            }
        }

        /// <summary>
        /// Chức năng sinh dữ liệu ngẫu nhiên hỗ trợ việc thuyết trình/demo trực tiếp (Chương 4 / Điểm cộng)
        /// Giúp giáo viên thấy ngay order mới xuất hiện và Timer đếm giờ tự động
        /// </summary>
        private void btnGiaLapDon_Click(object sender, EventArgs e)
        {
            var dsMonConBan = DataService.Instance.DanhSachMon.Where(m => m.ConBan).ToList();
            if (dsMonConBan.Count == 0)
            {
                MessageBox.Show("Không có món nào đang còn bán để tạo order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var rnd = new Random();
            var monChon = dsMonConBan[rnd.Next(dsMonConBan.Count)];
            string[] banList = { "Bàn 1", "Bàn 2", "Bàn 3", "Bàn 4", "Bàn 5", "Bàn VIP 1", "Sân Vườn 2" };
            string[] sizes = { "S", "M", "L" };
            string[] ghiChuList = { "Ít đường, nhiều đá", "Không đường, nóng", "Nhiều sữa đặc", "Để riêng đá", "Giao gấp mang về", "" };

            string maOrder = $"ORD{DateTime.Now:fff}{rnd.Next(10, 99)}";
            string tenBan = banList[rnd.Next(banList.Length)];
            string maBan = "B" + rnd.Next(1, 10).ToString("D2");
            string size = sizes[rnd.Next(sizes.Length)];
            int soLuong = rnd.Next(1, 3);
            string ghiChu = ghiChuList[rnd.Next(ghiChuList.Length)];

            var donMoi = new DonPhaChe(maOrder, maBan, tenBan, monChon.Ma, monChon.Ten, size, soLuong, ghiChu);
            DataService.Instance.DanhSachDonPhaChe.Insert(0, donMoi);
            DataService.Instance.LuuDanhSachDonPhaChe();

            try { SystemSounds.Beep.Play(); } catch { }

            HienThiDanhSachPhaChe();
            MessageBox.Show($"Đã tạo giả lập Order mới:\n- {tenBan}: {monChon.Ten} (Size {size}) x{soLuong}\nTimer sẽ tự động đếm thời gian chờ của món này!",
                "Giả lập đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
