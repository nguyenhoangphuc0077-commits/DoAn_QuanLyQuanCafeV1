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
            DataService.Instance.KhoiTaoDuLieu();
            DocFileBan();
            LoadComboBox();
            CapNhatThongKe();
            VeSoDoBan(null);

            // Mặc định chọn bàn đầu tiên nếu có
            if (_dsBan.Count > 0)
            {
                ChonBan(_dsBan[0]);
            }

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
            cboKhuVuc.SelectedIndexChanged -= CboKhuVuc_SelectedIndexChanged;
            cboKhuVuc.Items.Clear();
            cboKhuVuc.Items.Add("Tất cả khu vực");

            var khuVucs = _dsBan
                .Where(b => !string.IsNullOrWhiteSpace(b.KhuVuc))
                .Select(b => b.KhuVuc)
                .Distinct()
                .ToList();

            foreach (var kv in khuVucs)
            {
                int count = _dsBan.Count(b => b.KhuVuc == kv);
                cboKhuVuc.Items.Add($"{kv} ({count} bàn)");
            }

            cboKhuVuc.SelectedIndex = 0;
            cboKhuVuc.SelectedIndexChanged += CboKhuVuc_SelectedIndexChanged;
        }

        private string? LayKhuVucFilterTuComboBox()
        {
            if (cboKhuVuc.SelectedIndex <= 0) return null;
            string sel = cboKhuVuc.SelectedItem?.ToString() ?? "";
            int idx = sel.IndexOf(" (");
            return idx > 0 ? sel.Substring(0, idx).Trim() : sel.Trim();
        }

        private void CboKhuVuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? filter = LayKhuVucFilterTuComboBox();
            VeSoDoBan(filter);
        }

        private void CapNhatThongKe()
        {
            int tong = _dsBan.Count;
            int coKhach = _dsBan.Count(b => b.TrangThai == "Có khách");
            int trong = tong - coKhach;
            lblThongKe.Text = $"Tổng số: {tong} bàn  |  🟢 Trống: {trong} bàn  |  🔴 Có khách: {coKhach} bàn";
        }

        private void btnLamMoi_Click(object? sender, EventArgs e)
        {
            DocFileBan();
            CapNhatThongKe();
            string? filter = LayKhuVucFilterTuComboBox();
            VeSoDoBan(filter);
            if (_banDangChon != null)
            {
                var capNhat = _dsBan.FirstOrDefault(b => b.Ma == _banDangChon.Ma);
                if (capNhat != null) ChonBan(capNhat);
            }
        }

        private void VeSoDoBan(string? khuVucFilter)
        {
            pnlSoDo.SuspendLayout();
            pnlSoDo.Controls.Clear();

            var nhomKhuVuc = _dsBan
                .Where(b => khuVucFilter == null || b.KhuVuc == khuVucFilter)
                .GroupBy(b => b.KhuVuc)
                .ToList();

            int startY = 12;
            int btnWidth = 115;
            int btnHeight = 85;
            int gapX = 14;
            int gapY = 12;

            var hoaDonDict = _repoHD.GetTatCaHoaDonChuaThanhToan();

            foreach (var group in nhomKhuVuc)
            {
                string tenKhuVuc = group.Key;
                var dsBanTrongKhuVuc = group.ToList();

                // Tạo tiêu đề phân chia khu vực trực quan
                Label lblHeaderKhuVuc = new Label
                {
                    Text = $"🏢 KHU VỰC: {tenKhuVuc.ToUpper()} ({dsBanTrongKhuVuc.Count} BÀN)",
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(93, 64, 55),
                    BackColor = Color.FromArgb(238, 238, 238),
                    Location = new Point(14, startY),
                    Size = new Size(Math.Max(500, pnlSoDo.Width - 35), 28),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(8, 0, 0, 0)
                };
                pnlSoDo.Controls.Add(lblHeaderKhuVuc);

                startY += 36;
                int currentX = 14;
                int rowY = startY;

                foreach (var ban in dsBanTrongKhuVuc)
                {
                    bool isSelected = _banDangChon != null && _banDangChon.Ma == ban.Ma;
                    bool coKhach = ban.TrangThai == "Có khách";

                    string timerText = "";
                    if (coKhach && hoaDonDict.TryGetValue(ban.Ma, out var hd) && hd != null)
                    {
                        TimeSpan thoiGianDaNgoi = DateTime.Now - hd.GioVao;
                        if (thoiGianDaNgoi.TotalSeconds < 0) thoiGianDaNgoi = TimeSpan.Zero;
                        timerText = $"\n⏱ {(int)thoiGianDaNgoi.TotalHours:00}:{thoiGianDaNgoi.Minutes:00}:{thoiGianDaNgoi.Seconds:00}";
                    }

                    Button btn = new Button
                    {
                        Text = coKhach ? $"{ban.Ten}\n{ban.TrangThai}{timerText}" : $"{ban.Ten}\n{ban.TrangThai}",
                        Width = btnWidth,
                        Height = btnHeight,
                        Left = currentX,
                        Top = rowY,
                        Tag = ban,
                        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand
                    };

                    btn.FlatAppearance.BorderSize = isSelected ? 3 : 1;
                    btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(25, 118, 210) : (coKhach ? Color.FromArgb(229, 115, 115) : Color.FromArgb(129, 199, 132));
                    btn.BackColor = coKhach ? Color.FromArgb(255, 235, 238) : Color.FromArgb(232, 245, 233);
                    btn.ForeColor = coKhach ? Color.FromArgb(183, 28, 28) : Color.FromArgb(27, 94, 32);

                    btn.Click += BtnBan_Click;
                    btn.DoubleClick += BtnBan_DoubleClick;
                    btn.MouseDown += BtnBan_MouseDown;

                    pnlSoDo.Controls.Add(btn);

                    currentX += btnWidth + gapX;
                    if (currentX + btnWidth > pnlSoDo.Width - 20)
                    {
                        currentX = 14;
                        rowY += btnHeight + gapY;
                    }
                }

                startY = rowY + btnHeight + 20;
            }

            pnlSoDo.ResumeLayout();
        }

        private void ChonBan(Ban ban)
        {
            _banDangChon = ban;
            lblTieuDeBan.Text = $"CHI TIẾT: {ban.Ten.ToUpper()} [{ban.KhuVuc.ToUpper()}] - {ban.TrangThai.ToUpper()}";

            // Cập nhật viền chọn trên các nút bàn
            foreach (Control c in pnlSoDo.Controls)
            {
                if (c is Button btn && btn.Tag is Ban b)
                {
                    bool isSelected = b.Ma == ban.Ma;
                    bool coKhach = b.TrangThai == "Có khách";
                    btn.FlatAppearance.BorderSize = isSelected ? 3 : 1;
                    btn.FlatAppearance.BorderColor = isSelected ? Color.FromArgb(25, 118, 210) : (coKhach ? Color.FromArgb(229, 115, 115) : Color.FromArgb(129, 199, 132));
                }
            }

            HienThiChiTietMon(ban.Ma);
        }

        private void BtnBan_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && sender is Button btn && btn.Tag is Ban ban)
            {
                ChonBan(ban);
                cmsBan.Show(btn, e.Location);
            }
        }

        private void BtnBan_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not Ban ban) return;
            ChonBan(ban);
        }

        private void BtnBan_DoubleClick(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not Ban ban) return;
            ChonBan(ban);
            ThucHienGoiMon();
        }

        private void HienThiChiTietMon(string maBan)
        {
            lvChiTiet.Items.Clear();
            var ban = _dsBan.FirstOrDefault(b => b.Ma == maBan);
            if (ban == null || ban.TrangThai == "Trống") return;

            var dsMon = _repoHD.GetChiTietByMaBan(maBan);

            // Nạp trạng thái từ Màn hình Pha chế (KDS)
            DataService.Instance.NapDanhSachDonPhaChe();
            var dsPhaCheCuaBan = DataService.Instance.DanhSachDonPhaChe
                .Where(d => d.MaBan == maBan)
                .ToList();

            foreach (var mon in dsMon)
            {
                string tenHienThi = DataService.Instance.DanhSachMon
                    .FirstOrDefault(m => string.Equals(m.Ma, mon.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? mon.MaMon;

                // Tìm trạng thái pha chế tương ứng từ KDS
                string trangThaiPhaChe = "Hoàn thành";
                var donPC = dsPhaCheCuaBan.FirstOrDefault(d => d.MaMon == mon.MaMon && d.Size == mon.Size);
                if (donPC != null)
                {
                    trangThaiPhaChe = donPC.TrangThai;
                }

                ListViewItem item = new ListViewItem(tenHienThi);
                item.SubItems.Add(mon.Size);
                item.SubItems.Add(mon.SoLuong.ToString());
                item.SubItems.Add(mon.ThanhTien.ToString("N0") + " đ");
                item.SubItems.Add(trangThaiPhaChe);

                // Màu sắc trực quan theo trạng thái pha chế
                if (trangThaiPhaChe == "Chờ pha chế")
                {
                    item.ForeColor = Color.FromArgb(230, 81, 0); // Cam đậm
                }
                else if (trangThaiPhaChe == "Đang pha chế")
                {
                    item.ForeColor = Color.FromArgb(21, 101, 192); // Xanh dương
                    item.Font = new Font(lvChiTiet.Font, FontStyle.Bold);
                }
                else if (trangThaiPhaChe == "Hoàn thành")
                {
                    item.ForeColor = Color.FromArgb(46, 125, 50); // Xanh lá
                }

                lvChiTiet.Items.Add(item);
            }
        }

        private void btnGoiMon_Click(object? sender, EventArgs e)
        {
            ThucHienGoiMon();
        }

        private void miGoiMon_Click(object? sender, EventArgs e)
        {
            ThucHienGoiMon();
        }

        private void ThucHienGoiMon()
        {
            if (_banDangChon == null)
            {
                MessageBox.Show("Vui lòng click chọn một bàn trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var frm = new frmGoiMon(_banDangChon.Ten);
            if (frm.ShowDialog(this) == DialogResult.OK && frm.MonDuocChon != null)
            {
                string maMon = frm.MonDuocChon.Ma;
                string size = frm.SizeDuocChon;
                int soLuong = frm.SoLuongDuocChon;
                decimal donGia = frm.DonGiaDuocChon;
                string ghiChu = frm.GhiChuDuocChon;

                var hd = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
                if (hd == null)
                {
                    string newSoHD = "HD" + DateTime.Now.ToString("ddHHmmss");
                    _repoHD.TaoHoaDonMoi(newSoHD, _banDangChon.Ma);
                    _repoBan.CapNhatTrangThai(_banDangChon.Ma, "Có khách");
                    hd = new HoaDon { SoHD = newSoHD, MaBan = _banDangChon.Ma, GioVao = DateTime.Now };
                }

                _repoHD.ThemChiTietHoaDon(hd.SoHD, maMon, size, soLuong, donGia);

                // === ĐỒNG BỘ TỰ ĐỘNG SANG MÀN HÌNH PHA CHẾ (KDS) ===
                DongBoDonPhaCheMoi(_banDangChon.Ma, _banDangChon.Ten, maMon, frm.MonDuocChon.Ten, size, soLuong, ghiChu);

                MessageBox.Show($"Đã gọi món {frm.MonDuocChon.Ten} (Size {size}, SL: {soLuong}) cho {_banDangChon.Ten}!\n\nĐơn đã được tự động đồng bộ sang Màn hình Quầy Pha Chế (KDS).", 
                    "Gọi món thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DocFileBan();
                CapNhatThongKe();
                string? curFilter = LayKhuVucFilterTuComboBox();
                VeSoDoBan(curFilter);

                var banMoi = _dsBan.FirstOrDefault(b => b.Ma == _banDangChon.Ma);
                if (banMoi != null) ChonBan(banMoi);
            }
        }

        private void DongBoDonPhaCheMoi(string maBan, string tenBan, string maMon, string tenMon, string size, int soLuong, string ghiChu)
        {
            try
            {
                DataService.Instance.NapDanhSachDonPhaChe();
                string maOrder = "ORD" + DateTime.Now.ToString("yyMMddHHmmssfff");
                var donMoi = new DonPhaChe(maOrder, maBan, tenBan, maMon, tenMon, size, soLuong, ghiChu)
                {
                    ThoiGianGoi = DateTime.Now,
                    TrangThai = "Chờ pha chế"
                };

                DataService.Instance.DanhSachDonPhaChe.Insert(0, donMoi);
                DataService.Instance.LuuDanhSachDonPhaChe();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi đồng bộ KDS: " + ex.Message);
            }
        }

        private void btnChuyenBan_Click(object? sender, EventArgs e)
        {
            ThucHienChuyenBan();
        }

        private void miChuyenBan_Click(object? sender, EventArgs e)
        {
            ThucHienChuyenBan();
        }

        private void ThucHienChuyenBan()
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

                    // Đồng bộ chuyển cả đơn pha chế chưa xong sang bàn đích
                    CapNhatDonPhaCheSangBanMoi(_banDangChon.Ma, banDich.Ma, banDich.Ten);

                    MessageBox.Show($"Đã chuyển {_banDangChon.Ten} sang {banDich.Ten}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    DocFileBan();
                    CapNhatThongKe();
                    string? curFilter = LayKhuVucFilterTuComboBox();
                    VeSoDoBan(curFilter);

                    var banMoi = _dsBan.FirstOrDefault(b => b.Ma == banDich.Ma);
                    if (banMoi != null) ChonBan(banMoi);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của bàn này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGopBan_Click(object? sender, EventArgs e)
        {
            ThucHienGopBan();
        }

        private void miGopBan_Click(object? sender, EventArgs e)
        {
            ThucHienGopBan();
        }

        private void ThucHienGopBan()
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

                    // Đồng bộ chuyển đơn pha chế chưa xong sang bàn đích
                    CapNhatDonPhaCheSangBanMoi(_banDangChon.Ma, banDich.Ma, banDich.Ten);

                    MessageBox.Show($"Đã gộp {_banDangChon.Ten} vào {banDich.Ten}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    DocFileBan();
                    CapNhatThongKe();
                    string? curFilter = LayKhuVucFilterTuComboBox();
                    VeSoDoBan(curFilter);

                    var banMoi = _dsBan.FirstOrDefault(b => b.Ma == banDich.Ma);
                    if (banMoi != null) ChonBan(banMoi);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của một trong hai bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CapNhatDonPhaCheSangBanMoi(string maBanCu, string maBanMoi, string tenBanMoi)
        {
            try
            {
                DataService.Instance.NapDanhSachDonPhaChe();
                bool coThayDoi = false;
                foreach (var don in DataService.Instance.DanhSachDonPhaChe)
                {
                    if (don.MaBan == maBanCu && don.TrangThai != "Hoàn thành")
                    {
                        don.MaBan = maBanMoi;
                        don.TenBan = tenBanMoi;
                        coThayDoi = true;
                    }
                }
                if (coThayDoi)
                {
                    DataService.Instance.LuuDanhSachDonPhaChe();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi cập nhật KDS chuyển bàn: " + ex.Message);
            }
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            ThucHienThanhToan();
        }

        private void miThanhToan_Click(object? sender, EventArgs e)
        {
            ThucHienThanhToan();
        }

        private void ThucHienThanhToan()
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể thanh toán cho bàn đang có khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hd = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán cho bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new frmThanhToan(hd.SoHD, _banDangChon.Ma);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                // Khi thanh toán xong, các đơn pha chế còn lại của bàn này đánh dấu hoàn tất
                try
                {
                    DataService.Instance.NapDanhSachDonPhaChe();
                    foreach (var don in DataService.Instance.DanhSachDonPhaChe)
                    {
                        if (don.MaBan == _banDangChon.Ma && don.TrangThai != "Hoàn thành")
                        {
                            don.TrangThai = "Hoàn thành";
                        }
                    }
                    DataService.Instance.LuuDanhSachDonPhaChe();
                }
                catch { }

                DocFileBan();
                CapNhatThongKe();
                string? curFilter = LayKhuVucFilterTuComboBox();
                VeSoDoBan(curFilter);

                var banCapNhat = _dsBan.FirstOrDefault(b => b.Ma == _banDangChon.Ma);
                if (banCapNhat != null) ChonBan(banCapNhat);
            }
        }

        private void btnTachHD_Click(object? sender, EventArgs e)
        {
            ThucHienTachHoaDon();
        }

        private void miTachHD_Click(object? sender, EventArgs e)
        {
            ThucHienTachHoaDon();
        }

        private void ThucHienTachHoaDon()
        {
            if (_banDangChon == null || _banDangChon.TrangThai == "Trống")
            {
                MessageBox.Show("Chỉ có thể tách hóa đơn cho bàn đang có khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hd = _repoHD.GetHoaDonChuaThanhToan(_banDangChon.Ma);
            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn chưa thanh toán của bàn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var frm = new frmTachHoaDon(hd.SoHD, _banDangChon.Ma);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                DocFileBan();
                CapNhatThongKe();
                string? curFilter = LayKhuVucFilterTuComboBox();
                VeSoDoBan(curFilter);

                var banCapNhat = _dsBan.FirstOrDefault(b => b.Ma == _banDangChon.Ma);
                if (banCapNhat != null) ChonBan(banCapNhat);

                if (frm.MoThanhToanNgay && !string.IsNullOrEmpty(frm.SoHDMoi))
                {
                    using var frmTT = new frmThanhToan(frm.SoHDMoi, frm.MaBanDich);
                    if (frmTT.ShowDialog(this) == DialogResult.OK)
                    {
                        DocFileBan();
                        CapNhatThongKe();
                        VeSoDoBan(curFilter);
                        if (banCapNhat != null) ChonBan(banCapNhat);
                    }
                }
            }
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

                            btn.Text = $"{ban.Ten}\n{ban.TrangThai}\n⏱ {(int)thoiGianDaNgoi.TotalHours:00}:{thoiGianDaNgoi.Minutes:00}:{thoiGianDaNgoi.Seconds:00}";
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
