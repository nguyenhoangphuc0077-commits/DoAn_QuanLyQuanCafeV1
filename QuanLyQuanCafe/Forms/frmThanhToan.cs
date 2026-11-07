using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using QuanLyQuanCafe.Models;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmThanhToan : Form
    {
        private string soHDCurrent;
        private string maBanCurrent;
        private string dataDir = Path.Combine(Application.StartupPath, "Data");

        public frmThanhToan(string soHD, string maBan)
        {
            InitializeComponent();
            soHDCurrent = soHD;
            maBanCurrent = maBan;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
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
            lvwChiTiet.Columns.Add("Mã Món", 90);
            lvwChiTiet.Columns.Add("Size", 50);
            lvwChiTiet.Columns.Add("Số lượng", 70);
            lvwChiTiet.Columns.Add("Đơn giá", 90);
            lvwChiTiet.Columns.Add("Thành tiền", 100);

            lvwChiTiet.Items.Clear();
            string pathCT = Path.Combine(dataDir, "chitiethoadon.txt");
            if (File.Exists(pathCT))
            {
                var lines = File.ReadAllLines(pathCT);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var ct = new ChiTietHoaDon(line);
                    if (ct.SoHD == soHDCurrent)
                    {
                        ListViewItem item = new ListViewItem(ct.MaMon);
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
            decimal tongGoc = 0;
            foreach (ListViewItem item in lvwChiTiet.Items)
            {
                if (decimal.TryParse(item.SubItems[4].Text.Replace(",", ""), out decimal tt))
                {
                    tongGoc += tt;
                }
            }

            decimal giamGia = 0;
            decimal.TryParse(txtGiamGia.Text, out giamGia);

            decimal tongThanhToan = tongGoc * (1 - giamGia / 100);
            lblTongTien.Text = tongThanhToan.ToString("N0") + " VNĐ";

            TinhTienThoi();
        }

        private void TinhTienThoi()
        {
            if (decimal.TryParse(txtTienKhachDua.Text.Trim(), out decimal khachDua))
            {
                string cleanTien = lblTongTien.Text.Replace(" VNĐ", "").Replace(",", "").Trim();
                if (decimal.TryParse(cleanTien, out decimal tongTien))
                {
                    decimal thoi = khachDua - tongTien;
                    lblTienThoi.Text = thoi >= 0 ? thoi.ToString("N0") + " VNĐ" : "Chưa đủ tiền!";
                }
            }
            else
            {
                lblTienThoi.Text = "0 VNĐ";
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e) => TinhTien();
        private void txtTienKhachDua_TextChanged(object sender, EventArgs e) => TinhTienThoi();

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string pathHD = Path.Combine(dataDir, "hoadon.txt");
                var lines = File.ReadAllLines(pathHD);
                List<string> newLines = new List<string>();
                decimal tongTienVal = decimal.Parse(lblTongTien.Text.Replace(" VNĐ", "").Replace(",", ""));
                decimal.TryParse(txtGiamGia.Text, out decimal giamGiaVal);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var hd = new HoaDon(line);
                    if (hd.SoHD == soHDCurrent)
                    {
                        hd.GioRa = DateTime.Now;
                        hd.GiamGia = giamGiaVal;
                        hd.TongTien = tongTienVal;
                        hd.TrangThai = "Đã thanh toán";
                        newLines.Add(hd.ToLine());
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }
                File.WriteAllLines(pathHD, newLines);

                string pathBan = Path.Combine(dataDir, "ban.txt");
                if (File.Exists(pathBan))
                {
                    var banLines = File.ReadAllLines(pathBan);
                    List<string> newBanLines = new List<string>();
                    foreach (string bline in banLines)
                    {
                        string[] parts = bline.Split(';');
                        if (parts.Length >= 4 && parts[0] == maBanCurrent)
                        {
                            newBanLines.Add($"{parts[0]};{parts[1]};{parts[2]};Trống");
                        }
                        else
                        {
                            newBanLines.Add(bline);
                        }
                    }
                    File.WriteAllLines(pathBan, newBanLines);
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text file (*.txt)|*.txt";
                sfd.FileName = "HoaDon_" + soHDCurrent + ".txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine("          QUÁN CÀ PHÊ       ");
                        sw.WriteLine($"Số hóa đơn: {soHDCurrent} | Bàn: {maBanCurrent}");
                        sw.WriteLine($"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        foreach (ListViewItem item in lvwChiTiet.Items)
                        {
                            sw.WriteLine($"{item.Text,-15} SL: {item.SubItems[2].Text}  {item.SubItems[4].Text} VNĐ");
                        }
                        sw.WriteLine($"Giảm giá: {giamGiaVal}%");
                        sw.WriteLine($"Tổng thanh toán: {lblTongTien.Text}");
                        sw.WriteLine("         CẢM ƠN QUÝ KHÁCH, HẸP GẶP LẠI!  ");
                    }
                }

                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) => this.Close();
    }
}
