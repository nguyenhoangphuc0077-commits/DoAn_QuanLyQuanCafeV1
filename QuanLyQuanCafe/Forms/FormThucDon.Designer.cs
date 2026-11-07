namespace QuanLyQuanCafe.Forms
{
    partial class FormThucDon
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;

        // Left Panel: Thong tin mon
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.TextBox txtMaMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Button btnThemDanhMuc;

        // Group Gia & Size
        private System.Windows.Forms.GroupBox grpGiaTheoSize;
        private System.Windows.Forms.RadioButton radSizeS;
        private System.Windows.Forms.RadioButton radSizeM;
        private System.Windows.Forms.RadioButton radSizeL;
        private System.Windows.Forms.Label lblGiaS;
        private System.Windows.Forms.TextBox txtGiaS;
        private System.Windows.Forms.Label lblGiaM;
        private System.Windows.Forms.TextBox txtGiaM;
        private System.Windows.Forms.Label lblGiaL;
        private System.Windows.Forms.TextBox txtGiaL;
        private System.Windows.Forms.Label lblXemNhanhGia;

        // Anh & Trang thai
        private System.Windows.Forms.GroupBox grpHinhAnh;
        private System.Windows.Forms.PictureBox picMonAn;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnXoaAnh;
        private System.Windows.Forms.Label lblTenFileAnh;
        private System.Windows.Forms.CheckBox chkConBan;

        // Buttons Left
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;

        // Right Panel: Danh sach
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblLocDanhMuc;
        private System.Windows.Forms.ComboBox cboLocDanhMuc;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnXuatCsv;
        private System.Windows.Forms.Button btnNhapCsv;
        private System.Windows.Forms.Button btnMoPhaChe;

        // ListView
        private System.Windows.Forms.ListView lvwThucDon;
        private System.Windows.Forms.ColumnHeader colMa;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colDanhMuc;
        private System.Windows.Forms.ColumnHeader colGiaS;
        private System.Windows.Forms.ColumnHeader colGiaM;
        private System.Windows.Forms.ColumnHeader colGiaL;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.ColumnHeader colAnh;

        // Status bar
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSoMon;
        private System.Windows.Forms.ToolStripStatusLabel lblDangBan;
        private System.Windows.Forms.ToolStripStatusLabel lblTamHet;
        private System.Windows.Forms.ToolStripStatusLabel lblTacGia;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSub = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.grpGiaTheoSize = new System.Windows.Forms.GroupBox();
            this.radSizeS = new System.Windows.Forms.RadioButton();
            this.radSizeM = new System.Windows.Forms.RadioButton();
            this.radSizeL = new System.Windows.Forms.RadioButton();
            this.lblGiaS = new System.Windows.Forms.Label();
            this.txtGiaS = new System.Windows.Forms.TextBox();
            this.lblGiaM = new System.Windows.Forms.Label();
            this.txtGiaM = new System.Windows.Forms.TextBox();
            this.lblGiaL = new System.Windows.Forms.Label();
            this.txtGiaL = new System.Windows.Forms.TextBox();
            this.lblXemNhanhGia = new System.Windows.Forms.Label();
            this.grpHinhAnh = new System.Windows.Forms.GroupBox();
            this.picMonAn = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.btnXoaAnh = new System.Windows.Forms.Button();
            this.lblTenFileAnh = new System.Windows.Forms.Label();
            this.chkConBan = new System.Windows.Forms.CheckBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwThucDon = new System.Windows.Forms.ListView();
            this.colMa = new System.Windows.Forms.ColumnHeader();
            this.colTen = new System.Windows.Forms.ColumnHeader();
            this.colDanhMuc = new System.Windows.Forms.ColumnHeader();
            this.colGiaS = new System.Windows.Forms.ColumnHeader();
            this.colGiaM = new System.Windows.Forms.ColumnHeader();
            this.colGiaL = new System.Windows.Forms.ColumnHeader();
            this.colTrangThai = new System.Windows.Forms.ColumnHeader();
            this.colAnh = new System.Windows.Forms.ColumnHeader();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblLocDanhMuc = new System.Windows.Forms.Label();
            this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnNhapCsv = new System.Windows.Forms.Button();
            this.btnXuatCsv = new System.Windows.Forms.Button();
            this.btnMoPhaChe = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTongSoMon = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDangBan = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTamHet = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTacGia = new System.Windows.Forms.ToolStripStatusLabel();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(52)))), ((int)(((byte)(46)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1240, 70);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 10);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(430, 30);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "HỆ THỐNG QUẢN LÝ THỰC ĐƠN QUÁN CAFE";

            // 
            // lblHeaderSub
            // 
            this.lblHeaderSub.AutoSize = true;
            this.lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(178)))));
            this.lblHeaderSub.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSub.Name = "lblHeaderSub";
            this.lblHeaderSub.Size = new System.Drawing.Size(480, 17);
            this.lblHeaderSub.TabIndex = 1;
            this.lblHeaderSub.Text = "Phân hệ Thực đơn (SV1: Nguyễn Hoàng Phúc) - Quản lý Danh mục, Món ăn, Giá theo Size";

            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblMaMon);
            this.grpThongTin.Controls.Add(this.txtMaMon);
            this.grpThongTin.Controls.Add(this.lblTenMon);
            this.grpThongTin.Controls.Add(this.txtTenMon);
            this.grpThongTin.Controls.Add(this.lblDanhMuc);
            this.grpThongTin.Controls.Add(this.cboDanhMuc);
            this.grpThongTin.Controls.Add(this.btnThemDanhMuc);
            this.grpThongTin.Controls.Add(this.grpGiaTheoSize);
            this.grpThongTin.Controls.Add(this.grpHinhAnh);
            this.grpThongTin.Controls.Add(this.chkConBan);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnLuu);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(12, 78);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(460, 600);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Chi tiết Món ăn";

            // 
            // lblMaMon
            // 
            this.lblMaMon.AutoSize = true;
            this.lblMaMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMaMon.Location = new System.Drawing.Point(15, 28);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(56, 15);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Text = "Mã món:";

            // 
            // txtMaMon
            // 
            this.txtMaMon.Location = new System.Drawing.Point(95, 25);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(140, 24);
            this.txtMaMon.TabIndex = 1;

            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTenMon.Location = new System.Drawing.Point(15, 62);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(59, 15);
            this.lblTenMon.TabIndex = 2;
            this.lblTenMon.Text = "Tên món:";

            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(95, 59);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(345, 24);
            this.txtTenMon.TabIndex = 3;

            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDanhMuc.Location = new System.Drawing.Point(15, 96);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(66, 15);
            this.lblDanhMuc.TabIndex = 4;
            this.lblDanhMuc.Text = "Danh mục:";

            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(95, 93);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(255, 24);
            this.cboDanhMuc.TabIndex = 5;

            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.Location = new System.Drawing.Point(360, 92);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(80, 26);
            this.btnThemDanhMuc.TabIndex = 6;
            this.btnThemDanhMuc.Text = "+ Quản lý";
            this.btnThemDanhMuc.UseVisualStyleBackColor = true;
            this.btnThemDanhMuc.Click += new System.EventHandler(this.btnThemDanhMuc_Click);

            // 
            // grpGiaTheoSize
            // 
            this.grpGiaTheoSize.Controls.Add(this.radSizeS);
            this.grpGiaTheoSize.Controls.Add(this.radSizeM);
            this.grpGiaTheoSize.Controls.Add(this.radSizeL);
            this.grpGiaTheoSize.Controls.Add(this.lblGiaS);
            this.grpGiaTheoSize.Controls.Add(this.txtGiaS);
            this.grpGiaTheoSize.Controls.Add(this.lblGiaM);
            this.grpGiaTheoSize.Controls.Add(this.txtGiaM);
            this.grpGiaTheoSize.Controls.Add(this.lblGiaL);
            this.grpGiaTheoSize.Controls.Add(this.txtGiaL);
            this.grpGiaTheoSize.Controls.Add(this.lblXemNhanhGia);
            this.grpGiaTheoSize.Location = new System.Drawing.Point(15, 128);
            this.grpGiaTheoSize.Name = "grpGiaTheoSize";
            this.grpGiaTheoSize.Size = new System.Drawing.Size(425, 135);
            this.grpGiaTheoSize.TabIndex = 7;
            this.grpGiaTheoSize.TabStop = false;
            this.grpGiaTheoSize.Text = "Giá linh hoạt theo Kích cỡ (Size)";

            // 
            // radSizeS
            // 
            this.radSizeS.AutoSize = true;
            this.radSizeS.Location = new System.Drawing.Point(15, 24);
            this.radSizeS.Name = "radSizeS";
            this.radSizeS.Size = new System.Drawing.Size(100, 21);
            this.radSizeS.TabIndex = 0;
            this.radSizeS.Text = "Size S (Nhỏ)";
            this.radSizeS.UseVisualStyleBackColor = true;
            this.radSizeS.CheckedChanged += new System.EventHandler(this.radSize_CheckedChanged);

            // 
            // radSizeM
            // 
            this.radSizeM.AutoSize = true;
            this.radSizeM.Checked = true;
            this.radSizeM.Location = new System.Drawing.Point(145, 24);
            this.radSizeM.Name = "radSizeM";
            this.radSizeM.Size = new System.Drawing.Size(117, 21);
            this.radSizeM.TabIndex = 1;
            this.radSizeM.TabStop = true;
            this.radSizeM.Text = "Size M (Vừa)";
            this.radSizeM.UseVisualStyleBackColor = true;
            this.radSizeM.CheckedChanged += new System.EventHandler(this.radSize_CheckedChanged);

            // 
            // radSizeL
            // 
            this.radSizeL.AutoSize = true;
            this.radSizeL.Location = new System.Drawing.Point(290, 24);
            this.radSizeL.Name = "radSizeL";
            this.radSizeL.Size = new System.Drawing.Size(103, 21);
            this.radSizeL.TabIndex = 2;
            this.radSizeL.Text = "Size L (Lớn)";
            this.radSizeL.UseVisualStyleBackColor = true;
            this.radSizeL.CheckedChanged += new System.EventHandler(this.radSize_CheckedChanged);

            // 
            // lblGiaS
            // 
            this.lblGiaS.AutoSize = true;
            this.lblGiaS.Location = new System.Drawing.Point(15, 55);
            this.lblGiaS.Name = "lblGiaS";
            this.lblGiaS.Size = new System.Drawing.Size(43, 17);
            this.lblGiaS.TabIndex = 3;
            this.lblGiaS.Text = "Giá S:";

            // 
            // txtGiaS
            // 
            this.txtGiaS.Location = new System.Drawing.Point(62, 52);
            this.txtGiaS.Name = "txtGiaS";
            this.txtGiaS.Size = new System.Drawing.Size(75, 24);
            this.txtGiaS.TabIndex = 4;
            this.txtGiaS.Text = "25000";
            this.txtGiaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaS.TextChanged += new System.EventHandler(this.CapNhatXemNhanhGia);

            // 
            // lblGiaM
            // 
            this.lblGiaM.AutoSize = true;
            this.lblGiaM.Location = new System.Drawing.Point(145, 55);
            this.lblGiaM.Name = "lblGiaM";
            this.lblGiaM.Size = new System.Drawing.Size(47, 17);
            this.lblGiaM.TabIndex = 5;
            this.lblGiaM.Text = "Giá M:";

            // 
            // txtGiaM
            // 
            this.txtGiaM.Location = new System.Drawing.Point(195, 52);
            this.txtGiaM.Name = "txtGiaM";
            this.txtGiaM.Size = new System.Drawing.Size(80, 24);
            this.txtGiaM.TabIndex = 6;
            this.txtGiaM.Text = "30000";
            this.txtGiaM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaM.TextChanged += new System.EventHandler(this.CapNhatXemNhanhGia);

            // 
            // lblGiaL
            // 
            this.lblGiaL.AutoSize = true;
            this.lblGiaL.Location = new System.Drawing.Point(290, 55);
            this.lblGiaL.Name = "lblGiaL";
            this.lblGiaL.Size = new System.Drawing.Size(42, 17);
            this.lblGiaL.TabIndex = 7;
            this.lblGiaL.Text = "Giá L:";

            // 
            // txtGiaL
            // 
            this.txtGiaL.Location = new System.Drawing.Point(335, 52);
            this.txtGiaL.Name = "txtGiaL";
            this.txtGiaL.Size = new System.Drawing.Size(75, 24);
            this.txtGiaL.TabIndex = 8;
            this.txtGiaL.Text = "35000";
            this.txtGiaL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGiaL.TextChanged += new System.EventHandler(this.CapNhatXemNhanhGia);

            // 
            // lblXemNhanhGia
            // 
            this.lblXemNhanhGia.AutoSize = true;
            this.lblXemNhanhGia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblXemNhanhGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblXemNhanhGia.Location = new System.Drawing.Point(15, 95);
            this.lblXemNhanhGia.Name = "lblXemNhanhGia";
            this.lblXemNhanhGia.Size = new System.Drawing.Size(185, 17);
            this.lblXemNhanhGia.TabIndex = 9;
            this.lblXemNhanhGia.Text = "Đang chọn: Size M - 30.000 đ";

            // 
            // grpHinhAnh
            // 
            this.grpHinhAnh.Controls.Add(this.picMonAn);
            this.grpHinhAnh.Controls.Add(this.btnChonAnh);
            this.grpHinhAnh.Controls.Add(this.btnXoaAnh);
            this.grpHinhAnh.Controls.Add(this.lblTenFileAnh);
            this.grpHinhAnh.Location = new System.Drawing.Point(15, 270);
            this.grpHinhAnh.Name = "grpHinhAnh";
            this.grpHinhAnh.Size = new System.Drawing.Size(425, 195);
            this.grpHinhAnh.TabIndex = 8;
            this.grpHinhAnh.TabStop = false;
            this.grpHinhAnh.Text = "Ảnh minh họa (OpenFileDialog & PictureBox)";

            // 
            // picMonAn
            // 
            this.picMonAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.picMonAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMonAn.Location = new System.Drawing.Point(15, 24);
            this.picMonAn.Name = "picMonAn";
            this.picMonAn.Size = new System.Drawing.Size(180, 155);
            this.picMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMonAn.TabIndex = 0;
            this.picMonAn.TabStop = false;

            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChonAnh.Location = new System.Drawing.Point(215, 28);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(190, 36);
            this.btnChonAnh.TabIndex = 1;
            this.btnChonAnh.Text = "Chọn ảnh từ máy...";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            // 
            // btnXoaAnh
            // 
            this.btnXoaAnh.Location = new System.Drawing.Point(215, 72);
            this.btnXoaAnh.Name = "btnXoaAnh";
            this.btnXoaAnh.Size = new System.Drawing.Size(190, 30);
            this.btnXoaAnh.TabIndex = 2;
            this.btnXoaAnh.Text = "Bỏ chọn ảnh";
            this.btnXoaAnh.UseVisualStyleBackColor = true;
            this.btnXoaAnh.Click += new System.EventHandler(this.btnXoaAnh_Click);

            // 
            // lblTenFileAnh
            // 
            this.lblTenFileAnh.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTenFileAnh.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenFileAnh.Location = new System.Drawing.Point(215, 115);
            this.lblTenFileAnh.Name = "lblTenFileAnh";
            this.lblTenFileAnh.Size = new System.Drawing.Size(195, 60);
            this.lblTenFileAnh.TabIndex = 3;
            this.lblTenFileAnh.Text = "File ảnh: Chưa chọn (ảnh lưu tự động vào thư mục Data/Images)";

            // 
            // chkConBan
            // 
            this.chkConBan.AutoSize = true;
            this.chkConBan.Checked = true;
            this.chkConBan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkConBan.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkConBan.Location = new System.Drawing.Point(20, 480);
            this.chkConBan.Name = "chkConBan";
            this.chkConBan.Size = new System.Drawing.Size(248, 23);
            this.chkConBan.TabIndex = 9;
            this.chkConBan.Text = "Đang kinh doanh (Bỏ chọn: Tạm hết)";
            this.chkConBan.UseVisualStyleBackColor = true;
            this.chkConBan.CheckedChanged += new System.EventHandler(this.chkConBan_CheckedChanged);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Location = new System.Drawing.Point(15, 530);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 42);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới / Thêm";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(155, 530);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 42);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu Món ăn";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(320, 530);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 42);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa món";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.lvwThucDon);
            this.grpDanhSach.Controls.Add(this.pnlFilter);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpDanhSach.Location = new System.Drawing.Point(485, 78);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(745, 600);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách Thực đơn quán (ListView Details)";

            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblLocDanhMuc);
            this.pnlFilter.Controls.Add(this.cboLocDanhMuc);
            this.pnlFilter.Controls.Add(this.lblTimKiem);
            this.pnlFilter.Controls.Add(this.txtTimKiem);
            this.pnlFilter.Controls.Add(this.btnNhapCsv);
            this.pnlFilter.Controls.Add(this.btnXuatCsv);
            this.pnlFilter.Controls.Add(this.btnMoPhaChe);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 20);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(739, 85);
            this.pnlFilter.TabIndex = 0;

            // 
            // lblLocDanhMuc
            // 
            this.lblLocDanhMuc.AutoSize = true;
            this.lblLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocDanhMuc.Location = new System.Drawing.Point(10, 15);
            this.lblLocDanhMuc.Name = "lblLocDanhMuc";
            this.lblLocDanhMuc.Size = new System.Drawing.Size(89, 15);
            this.lblLocDanhMuc.TabIndex = 0;
            this.lblLocDanhMuc.Text = "Lọc danh mục:";

            // 
            // cboLocDanhMuc
            // 
            this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDanhMuc.FormattingEnabled = true;
            this.cboLocDanhMuc.Location = new System.Drawing.Point(105, 12);
            this.cboLocDanhMuc.Name = "cboLocDanhMuc";
            this.cboLocDanhMuc.Size = new System.Drawing.Size(200, 24);
            this.cboLocDanhMuc.TabIndex = 1;
            this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboLocDanhMuc_SelectedIndexChanged);

            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimKiem.Location = new System.Drawing.Point(320, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(63, 15);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm:";

            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(390, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập mã hoặc tên món...";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 24);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // 
            // btnNhapCsv
            // 
            this.btnNhapCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnNhapCsv.ForeColor = System.Drawing.Color.White;
            this.btnNhapCsv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNhapCsv.Location = new System.Drawing.Point(10, 48);
            this.btnNhapCsv.Name = "btnNhapCsv";
            this.btnNhapCsv.Size = new System.Drawing.Size(125, 30);
            this.btnNhapCsv.TabIndex = 4;
            this.btnNhapCsv.Text = "Nhập CSV";
            this.btnNhapCsv.UseVisualStyleBackColor = false;
            this.btnNhapCsv.Click += new System.EventHandler(this.btnNhapCsv_Click);

            // 
            // btnXuatCsv
            // 
            this.btnXuatCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.btnXuatCsv.ForeColor = System.Drawing.Color.White;
            this.btnXuatCsv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXuatCsv.Location = new System.Drawing.Point(145, 48);
            this.btnXuatCsv.Name = "btnXuatCsv";
            this.btnXuatCsv.Size = new System.Drawing.Size(125, 30);
            this.btnXuatCsv.TabIndex = 5;
            this.btnXuatCsv.Text = "Xuất CSV";
            this.btnXuatCsv.UseVisualStyleBackColor = false;
            this.btnXuatCsv.Click += new System.EventHandler(this.btnXuatCsv_Click);

            // 
            // btnMoPhaChe
            // 
            this.btnMoPhaChe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.btnMoPhaChe.ForeColor = System.Drawing.Color.White;
            this.btnMoPhaChe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoPhaChe.Location = new System.Drawing.Point(285, 48);
            this.btnMoPhaChe.Name = "btnMoPhaChe";
            this.btnMoPhaChe.Size = new System.Drawing.Size(220, 30);
            this.btnMoPhaChe.TabIndex = 6;
            this.btnMoPhaChe.Text = "Màn hình Pha chế [Timer]";
            this.btnMoPhaChe.UseVisualStyleBackColor = false;
            this.btnMoPhaChe.Click += new System.EventHandler(this.btnMoPhaChe_Click);

            // 
            // lvwThucDon
            // 
            this.lvwThucDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwThucDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMa,
            this.colTen,
            this.colDanhMuc,
            this.colGiaS,
            this.colGiaM,
            this.colGiaL,
            this.colTrangThai,
            this.colAnh});
            this.lvwThucDon.FullRowSelect = true;
            this.lvwThucDon.GridLines = true;
            this.lvwThucDon.Location = new System.Drawing.Point(3, 110);
            this.lvwThucDon.MultiSelect = false;
            this.lvwThucDon.Name = "lvwThucDon";
            this.lvwThucDon.Size = new System.Drawing.Size(739, 485);
            this.lvwThucDon.TabIndex = 1;
            this.lvwThucDon.UseCompatibleStateImageBehavior = false;
            this.lvwThucDon.View = System.Windows.Forms.View.Details;
            this.lvwThucDon.SelectedIndexChanged += new System.EventHandler(this.lvwThucDon_SelectedIndexChanged);

            // 
            // colMa
            // 
            this.colMa.Text = "Mã";
            this.colMa.Width = 60;

            // 
            // colTen
            // 
            this.colTen.Text = "Tên món";
            this.colTen.Width = 190;

            // 
            // colDanhMuc
            // 
            this.colDanhMuc.Text = "Danh mục";
            this.colDanhMuc.Width = 140;

            // 
            // colGiaS
            // 
            this.colGiaS.Text = "Giá Size S";
            this.colGiaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGiaS.Width = 85;

            // 
            // colGiaM
            // 
            this.colGiaM.Text = "Giá Size M";
            this.colGiaM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGiaM.Width = 85;

            // 
            // colGiaL
            // 
            this.colGiaL.Text = "Giá Size L";
            this.colGiaL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colGiaL.Width = 85;

            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTrangThai.Width = 80;

            // 
            // colAnh
            // 
            this.colAnh.Text = "File Ảnh";
            this.colAnh.Width = 90;

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongSoMon,
            this.lblDangBan,
            this.lblTamHet,
            this.lblTacGia});
            this.statusStrip.Location = new System.Drawing.Point(0, 690);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1240, 24);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";

            // 
            // lblTongSoMon
            // 
            this.lblTongSoMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongSoMon.Name = "lblTongSoMon";
            this.lblTongSoMon.Size = new System.Drawing.Size(107, 19);
            this.lblTongSoMon.Text = "Tổng số món: 0";

            // 
            // lblDangBan
            // 
            this.lblDangBan.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDangBan.Name = "lblDangBan";
            this.lblDangBan.Size = new System.Drawing.Size(89, 19);
            this.lblDangBan.Text = "| Còn bán: 0";

            // 
            // lblTamHet
            // 
            this.lblTamHet.ForeColor = System.Drawing.Color.Crimson;
            this.lblTamHet.Name = "lblTamHet";
            this.lblTamHet.Size = new System.Drawing.Size(89, 19);
            this.lblTamHet.Text = "| Tạm hết: 0";

            // 
            // lblTacGia
            // 
            this.lblTacGia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(320, 19);
            this.lblTacGia.Text = "| Sinh viên phụ trách: Nguyễn Hoàng Phúc (Phân hệ Thực đơn)";

            // 
            // FormThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 714);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "FormThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thực đơn - SV1: Nguyễn Hoàng Phúc";
            this.Load += new System.EventHandler(this.FormThucDon_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpGiaTheoSize.ResumeLayout(false);
            this.grpGiaTheoSize.PerformLayout();
            this.grpHinhAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMonAn)).EndInit();
            this.grpDanhSach.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

