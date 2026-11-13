using System;
using System.IO;
using System.Windows.Forms;
using QuanLyQuanCafe.Services;

namespace QuanLyQuanCafe.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            DataService.Instance.KhoiTaoDuLieu();
            MoFormCon<FormThucDon>();
        }

        private void timerClockMain_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private T MoFormCon<T>() where T : Form, new()
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is T formDaMo)
                {
                    formDaMo.Activate();
                    if (formDaMo.WindowState == FormWindowState.Minimized)
                        formDaMo.WindowState = FormWindowState.Normal;
                    return formDaMo;
                }
            }

            var frmMoi = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frmMoi.Show();
            return frmMoi;
        }

        private void mnuQuanLyThucDon_Click(object sender, EventArgs e)
        {
            MoFormCon<FormThucDon>();
        }

        private void mnuQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            using var frmDM = new FormQuanLyDanhMuc();
            frmDM.DanhMucUpdated += (s, args) =>
            {
                foreach (var child in this.MdiChildren)
                {
                    if (child is FormThucDon frmTD)
                    {
                        frmTD.NapDanhSachDanhMucVaoCombobox();
                    }
                }
            };
            frmDM.ShowDialog(this);
        }

        private void mnuManHinhPhaChe_Click(object sender, EventArgs e)
        {
            MoFormCon<FormPhaChe>();
        }

        private void mnuSoDoBan_Click(object sender, EventArgs e)
        {
            MoFormCon<frmSoDoBan>();
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog
            {
                Description = "Chọn thư mục lưu trữ bản sao lưu dữ liệu (Data Backup)"
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string targetDir = Path.Combine(fbd.SelectedPath, $"Backup_Data_{DateTime.Now:yyyyMMdd_HHmmss}");
                bool ok = FileHelper.SaoLuuThuMucData(targetDir, out string msg);

                if (ok)
                {
                    MessageBox.Show(msg, "Sao lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "Lỗi sao lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ValidationHelper.XacNhan("Bạn có chắc chắn muốn thoát khỏi hệ thống quản lý quán cà phê không?", "Xác nhận thoát"))
            {
                e.Cancel = true;
            }
        }

        private void mnuThongTinSV_Click(object sender, EventArgs e)
        {
            string info = "========================================================\n" +
                          "ĐỒ ÁN LẬP TRÌNH WINDOWS - QUẢN LÝ QUÁN CÀ PHÊ (ĐỀ 3)\n" +
                          "========================================================\n\n" +
                          "HỌ VÀ TÊN SINH VIÊN: NGUYỄN HOÀNG PHÚC (SV1)\n" +
                          "PHÂN HỆ PHỤ TRÁCH: PHÂN HỆ THỰC ĐƠN (MENU & SẢN PHẨM)\n\n" +
                          "NỘI DUNG ĐÃ THỰC HIỆN TRONG GIAI ĐOẠN 1 & 2:\n" +
                          "- T1.3: Viết Class Base đọc/ghi file chung UTF-8 (.txt/.csv), xử lý Exception & try-catch toàn diện, ghi log.txt, ValidationHelper.\n" +
                          "- T2.1: Xây dựng Class DanhMuc và Mon (bắt buộc có ToString(), hỗ trợ List<T> theo chuẩn OOP).\n" +
                          "- T2.2: Form Thêm/Sửa/Xóa thực đơn và danh mục, kiểm tra điều kiện dữ liệu nhập (TryParse, không trùng mã, đưa con trỏ về ô sai).\n" +
                          "- T2.3: Quản lý giá linh hoạt theo Size (S, M, L) bằng RadioButton, chọn ảnh qua OpenFileDialog hiển thị PictureBox, CheckBox đánh dấu món tạm hết.\n" +
                          "- T2.4: Chức năng Nhập/Xuất thực đơn ra file CSV chuẩn UTF-8 có BOM.\n" +
                          "- T2.5 [ĐIỂM CỘNG NÂNG CAO]: Màn hình quầy Pha chế (Barista KDS Display) tự động cập nhật thời gian thực bằng Timer.\n\n" +
                          "Cảm ơn Thầy Cô đã theo dõi!";

            MessageBox.Show(info, "Thông tin Sinh viên & Đề tài", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
