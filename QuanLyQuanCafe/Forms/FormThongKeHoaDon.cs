using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Repositories;
using QuanLyQuanCafe.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class FormThongKeHoaDon : Form
    {
        private readonly HoaDonRepository _repoHD = new HoaDonRepository();
        private List<HoaDon> _dsHoaDonHienThi = new List<HoaDon>();
        private List<ChiTietHoaDon> _tatCaChiTiet = new List<ChiTietHoaDon>();

        public FormThongKeHoaDon()
        {
            InitializeComponent();
        }

        private void FormThongKeHoaDon_Load(object? sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;

            DataService.Instance.KhoiTaoDuLieu();
            NapDuLieuVaThongKe();
        }

        private void btnLoc_Click(object? sender, EventArgs e)
        {
            NapDuLieuVaThongKe();
        }

        private void btnHomNay_Click(object? sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            NapDuLieuVaThongKe();
        }

        private void btnThangNay_Click(object? sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;
            cboTrangThai.SelectedIndex = 0;
            NapDuLieuVaThongKe();
        }

        private void btnTatCa_Click(object? sender, EventArgs e)
        {
            dtpTuNgay.Value = new DateTime(2025, 1, 1);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);
            cboTrangThai.SelectedIndex = 0;
            txtTimKiem.Clear();
            NapDuLieuVaThongKe();
        }

        private void NapDuLieuVaThongKe()
        {
            var dsAllHD = _repoHD.LoadAllHoaDon();
            _tatCaChiTiet = _repoHD.LoadAllChiTiet();

            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string trangThaiLoc = cboTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            string timKiem = txtTimKiem.Text.Trim();

            _dsHoaDonHienThi = dsAllHD.Where(hd =>
            {
                if (hd.GioVao < tuNgay || hd.GioVao > denNgay) return false;

                if (trangThaiLoc != "Tất cả" && !string.Equals(hd.TrangThai, trangThaiLoc, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (!string.IsNullOrWhiteSpace(timKiem))
                {
                    bool matchSoHD = hd.SoHD.IndexOf(timKiem, StringComparison.OrdinalIgnoreCase) >= 0;
                    bool matchBan = hd.MaBan.IndexOf(timKiem, StringComparison.OrdinalIgnoreCase) >= 0;
                    if (!matchSoHD && !matchBan) return false;
                }

                return true;
            }).OrderByDescending(hd => hd.GioVao).ToList();

            HienThiDanhSachHoaDon();
            HienThiThongKeVaMonBanChay();
        }

        private void HienThiDanhSachHoaDon()
        {
            lvwHoaDon.BeginUpdate();
            lvwHoaDon.Items.Clear();

            foreach (var hd in _dsHoaDonHienThi)
            {
                var lvi = new ListViewItem(hd.SoHD);
                lvi.SubItems.Add(hd.MaBan);
                lvi.SubItems.Add(hd.GioVao.ToString("dd/MM/yyyy HH:mm"));
                lvi.SubItems.Add(hd.GioRa.HasValue ? hd.GioRa.Value.ToString("dd/MM/yyyy HH:mm") : "---");
                lvi.SubItems.Add(hd.GiamGia > 0 ? $"{hd.GiamGia}%" : "0%");
                lvi.SubItems.Add(hd.TongTien.ToString("N0") + " đ");
                lvi.SubItems.Add(hd.TrangThai);
                lvi.Tag = hd;

                if (hd.TrangThai == "Đã thanh toán")
                {
                    lvi.ForeColor = Color.FromArgb(46, 125, 50); // Xanh lá
                }
                else
                {
                    lvi.ForeColor = Color.FromArgb(198, 40, 40); // Đỏ
                    lvi.Font = new Font(lvwHoaDon.Font, FontStyle.Bold);
                }

                lvwHoaDon.Items.Add(lvi);
            }

            lvwHoaDon.EndUpdate();
            lvwChiTiet.Items.Clear();

            if (lvwHoaDon.Items.Count > 0)
            {
                lvwHoaDon.Items[0].Selected = true;
            }
        }

        private void lvwHoaDon_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lvwHoaDon.SelectedItems.Count == 0)
            {
                lvwChiTiet.Items.Clear();
                return;
            }

            var hd = lvwHoaDon.SelectedItems[0].Tag as HoaDon;
            if (hd == null) return;

            grpChiTietHD.Text = $"Chi tiết món: {hd.SoHD} (Bàn {hd.MaBan})";

            var dsCT = _tatCaChiTiet.Where(c => string.Equals(c.SoHD, hd.SoHD, StringComparison.OrdinalIgnoreCase)).ToList();

            lvwChiTiet.BeginUpdate();
            lvwChiTiet.Items.Clear();

            foreach (var ct in dsCT)
            {
                string tenMon = DataService.Instance.DanhSachMon
                    .FirstOrDefault(m => string.Equals(m.Ma, ct.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? ct.MaMon;

                var lvi = new ListViewItem(tenMon);
                lvi.SubItems.Add(ct.Size);
                lvi.SubItems.Add(ct.SoLuong.ToString());
                lvi.SubItems.Add(ct.DonGia.ToString("N0") + " đ");
                lvi.SubItems.Add(ct.ThanhTien.ToString("N0") + " đ");
                lvwChiTiet.Items.Add(lvi);
            }

            lvwChiTiet.EndUpdate();

            bool chuaThanhToan = hd.TrangThai != "Đã thanh toán";
            btnThanhToan.Enabled = chuaThanhToan;
            btnTachHD.Enabled = chuaThanhToan && dsCT.Count > 0;
        }

        private void HienThiThongKeVaMonBanChay()
        {
            var dsDaThanhToan = _dsHoaDonHienThi.Where(hd => hd.TrangThai == "Đã thanh toán").ToList();

            decimal tongDoanhThu = dsDaThanhToan.Sum(hd => hd.TongTien);
            int soHD = dsDaThanhToan.Count;
            decimal trungBinh = soHD > 0 ? tongDoanhThu / soHD : 0;

            // Lấy danh sách chi tiết các hóa đơn đang lọc
            var tapHopSoHD = new HashSet<string>(_dsHoaDonHienThi.Select(h => h.SoHD), StringComparer.OrdinalIgnoreCase);
            var chiTietDangLoc = _tatCaChiTiet.Where(c => tapHopSoHD.Contains(c.SoHD)).ToList();

            int tongLyMon = chiTietDangLoc.Sum(c => c.SoLuong);

            lblTongDoanhThuVal.Text = $"{tongDoanhThu:N0} VNĐ";
            lblTongSoHDVal.Text = $"{soHD} hóa đơn";
            lblTrungBinhVal.Text = $"{trungBinh:N0} VNĐ";
            lblTongLyVal.Text = $"{tongLyMon} ly/món";

            // Bảng xếp hạng món bán chạy
            var nhomMon = chiTietDangLoc
                .GroupBy(c => new { c.MaMon, c.Size })
                .Select(g =>
                {
                    string ma = g.Key.MaMon;
                    string size = g.Key.Size;
                    int slBan = g.Sum(x => x.SoLuong);
                    decimal doanhThu = g.Sum(x => x.ThanhTien);
                    string ten = DataService.Instance.DanhSachMon
                        .FirstOrDefault(m => string.Equals(m.Ma, ma, StringComparison.OrdinalIgnoreCase))?.Ten ?? ma;
                    return new
                    {
                        MaMon = ma,
                        TenMon = ten,
                        Size = size,
                        SoLuong = slBan,
                        DoanhThu = doanhThu
                    };
                })
                .OrderByDescending(x => x.SoLuong)
                .ThenByDescending(x => x.DoanhThu)
                .ToList();

            decimal tongTienChiTiet = chiTietDangLoc.Sum(c => c.ThanhTien);

            lvwMonBanChay.BeginUpdate();
            lvwMonBanChay.Items.Clear();

            int hang = 1;
            foreach (var m in nhomMon)
            {
                double tyLe = tongTienChiTiet > 0 ? (double)(m.DoanhThu / tongTienChiTiet * 100) : 0;

                var lvi = new ListViewItem(hang.ToString());
                lvi.SubItems.Add(m.MaMon);
                lvi.SubItems.Add(m.TenMon);
                lvi.SubItems.Add(m.Size);
                lvi.SubItems.Add(m.SoLuong.ToString());
                lvi.SubItems.Add(m.DoanhThu.ToString("N0") + " đ");
                lvi.SubItems.Add($"{tyLe:F1}%");

                if (hang == 1)
                {
                    lvi.BackColor = Color.FromArgb(255, 243, 224); // Top 1 highlight
                    lvi.Font = new Font(lvwMonBanChay.Font, FontStyle.Bold);
                }
                else if (hang <= 3)
                {
                    lvi.BackColor = Color.FromArgb(245, 245, 245);
                }

                lvwMonBanChay.Items.Add(lvi);
                hang++;
            }

            lvwMonBanChay.EndUpdate();
        }

        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if (lvwHoaDon.SelectedItems.Count == 0) return;
            var hd = lvwHoaDon.SelectedItems[0].Tag as HoaDon;
            if (hd == null || hd.TrangThai == "Đã thanh toán") return;

            using var frm = new frmThanhToan(hd.SoHD, hd.MaBan);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                NapDuLieuVaThongKe();
            }
        }

        private void btnTachHD_Click(object? sender, EventArgs e)
        {
            if (lvwHoaDon.SelectedItems.Count == 0) return;
            var hd = lvwHoaDon.SelectedItems[0].Tag as HoaDon;
            if (hd == null || hd.TrangThai == "Đã thanh toán") return;

            using var frm = new frmTachHoaDon(hd.SoHD, hd.MaBan);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                NapDuLieuVaThongKe();

                if (frm.MoThanhToanNgay && !string.IsNullOrEmpty(frm.SoHDMoi))
                {
                    using var frmTT = new frmThanhToan(frm.SoHDMoi, frm.MaBanDich);
                    frmTT.ShowDialog(this);
                    NapDuLieuVaThongKe();
                }
            }
        }

        private void btnInHD_Click(object? sender, EventArgs e)
        {
            if (lvwHoaDon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn cần in lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hd = lvwHoaDon.SelectedItems[0].Tag as HoaDon;
            if (hd == null) return;

            var dsCT = _tatCaChiTiet.Where(c => string.Equals(c.SoHD, hd.SoHD, StringComparison.OrdinalIgnoreCase)).ToList();

            var sfd = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                FileName = $"HoaDon_InLai_{hd.SoHD}.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                sw.WriteLine("========================================");
                sw.WriteLine("            QUÁN CÀ PHÊ                 ");
                sw.WriteLine("         HÓA ĐƠN THANH TOÁN             ");
                sw.WriteLine("========================================");
                sw.WriteLine($"Số HĐ    : {hd.SoHD}");
                sw.WriteLine($"Bàn      : {hd.MaBan}");
                sw.WriteLine($"Giờ vào  : {hd.GioVao:dd/MM/yyyy HH:mm:ss}");
                sw.WriteLine($"Giờ ra   : {(hd.GioRa.HasValue ? hd.GioRa.Value.ToString("dd/MM/yyyy HH:mm:ss") : "Chưa thanh toán")}");
                sw.WriteLine($"Trạng thái: {hd.TrangThai}");
                sw.WriteLine("----------------------------------------");
                sw.WriteLine(string.Format("{0,-16} {1,5} {2,5} {3,12}", "Tên món", "Size", "SL", "Thành tiền"));
                sw.WriteLine("----------------------------------------");
                decimal tongGoc = 0;
                foreach (var ct in dsCT)
                {
                    string tenMon = DataService.Instance.DanhSachMon
                        .FirstOrDefault(m => string.Equals(m.Ma, ct.MaMon, StringComparison.OrdinalIgnoreCase))?.Ten ?? ct.MaMon;
                    sw.WriteLine(string.Format("{0,-16} {1,5} {2,5} {3,12:N0}", tenMon, ct.Size, ct.SoLuong, ct.ThanhTien));
                    tongGoc += ct.ThanhTien;
                }
                sw.WriteLine("----------------------------------------");
                sw.WriteLine($"Tổng tiền gốc  : {tongGoc:N0} VNĐ");
                sw.WriteLine($"Giảm giá       : {hd.GiamGia}%");
                sw.WriteLine($"Tổng thanh toán: {hd.TongTien:N0} VNĐ");
                sw.WriteLine("========================================");
                sw.WriteLine("     CẢM ƠN QUÝ KHÁCH, HẸN GẶP LẠI!     ");
                sw.WriteLine("========================================");

                MessageBox.Show($"Đã xuất hóa đơn {hd.SoHD} ra file thành công!\nĐường dẫn: {sfd.FileName}", "In hóa đơn thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatCsvHD_Click(object? sender, EventArgs e)
        {
            if (_dsHoaDonHienThi.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn nào trong danh sách đang lọc để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv",
                FileName = $"BaoCao_HoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                    // Ghi dòng tiêu đề
                    sw.WriteLine("SoHD;MaBan;GioVao;GioRa;GiamGia;TongTien;TrangThai");
                    foreach (var hd in _dsHoaDonHienThi)
                    {
                        string gioRaStr = hd.GioRa.HasValue ? hd.GioRa.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";
                        sw.WriteLine($"{hd.SoHD};{hd.MaBan};{hd.GioVao:dd/MM/yyyy HH:mm:ss};{gioRaStr};{hd.GiamGia};{hd.TongTien};{hd.TrangThai}");
                    }

                    MessageBox.Show($"Đã xuất thành công {_dsHoaDonHienThi.Count} hóa đơn ra file CSV!\nĐường dẫn: {sfd.FileName}", "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatCsvMonBanChay_Click(object? sender, EventArgs e)
        {
            if (lvwMonBanChay.Items.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu món bán chạy để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sfd = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv",
                FileName = $"BaoCao_MonBanChay_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8);
                    sw.WriteLine("Hang;MaMon;TenMon;Size;SoLuongBan;DoanhThu;TyLePhanTram");
                    foreach (ListViewItem item in lvwMonBanChay.Items)
                    {
                        string hang = item.SubItems[0].Text;
                        string maMon = item.SubItems[1].Text;
                        string tenMon = item.SubItems[2].Text;
                        string size = item.SubItems[3].Text;
                        string soLuong = item.SubItems[4].Text;
                        string doanhThu = item.SubItems[5].Text.Replace(" đ", "").Replace(",", "").Trim();
                        string tyLe = item.SubItems[6].Text;

                        sw.WriteLine($"{hang};{maMon};{tenMon};{size};{soLuong};{doanhThu};{tyLe}");
                    }

                    MessageBox.Show($"Đã xuất bảng xếp hạng món bán chạy ra file CSV thành công!\nĐường dẫn: {sfd.FileName}", "Xuất CSV thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
