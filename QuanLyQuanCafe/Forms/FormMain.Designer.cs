namespace QuanLyQuanCafe.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuSaoLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;

        private System.Windows.Forms.ToolStripMenuItem mnuThucDon;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyThucDon;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyDanhMuc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuManHinhPhaChe;

        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuTileHorizontal;
        private System.Windows.Forms.ToolStripMenuItem mnuTileVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuDongTatCa;

        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;
        private System.Windows.Forms.ToolStripMenuItem mnuThongTinSV;

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblPhanHe;
        private System.Windows.Forms.ToolStripStatusLabel lblThuMucData;
        private System.Windows.Forms.ToolStripStatusLabel lblThoiGian;
        private System.Windows.Forms.Timer timerClockMain;

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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThucDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyThucDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuManHinhPhaChe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTileVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDongTatCa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongTinSV = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPhanHe = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblThuMucData = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClockMain = new System.Windows.Forms.Timer(this.components);

            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuThucDon,
            this.mnuCuaSo,
            this.mnuTroGiup});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.MdiWindowListItem = this.mnuCuaSo;
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1280, 25);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";

            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaoLuu,
            this.toolStripSeparator1,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(73, 21);
            this.mnuHeThong.Text = "&Hệ thống";

            // 
            // mnuSaoLuu
            // 
            this.mnuSaoLuu.Name = "mnuSaoLuu";
            this.mnuSaoLuu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuSaoLuu.Size = new System.Drawing.Size(237, 22);
            this.mnuSaoLuu.Text = "&Sao lưu thư mục Data...";
            this.mnuSaoLuu.Click += new System.EventHandler(this.mnuSaoLuu_Click);

            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);

            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuThoat.Size = new System.Drawing.Size(237, 22);
            this.mnuThoat.Text = "&Thoát chương trình";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);

            // 
            // mnuThucDon
            // 
            this.mnuThucDon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQuanLyThucDon,
            this.mnuQuanLyDanhMuc,
            this.toolStripSeparator2,
            this.mnuManHinhPhaChe});
            this.mnuThucDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuThucDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.mnuThucDon.Name = "mnuThucDon";
            this.mnuThucDon.Size = new System.Drawing.Size(201, 21);
            this.mnuThucDon.Text = "&Phân hệ Thực đơn (SV1: Phúc)";

            // 
            // mnuQuanLyThucDon
            // 
            this.mnuQuanLyThucDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuQuanLyThucDon.Name = "mnuQuanLyThucDon";
            this.mnuQuanLyThucDon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mnuQuanLyThucDon.Size = new System.Drawing.Size(258, 22);
            this.mnuQuanLyThucDon.Text = "&Quản lý Món ăn / Thực đơn";
            this.mnuQuanLyThucDon.Click += new System.EventHandler(this.mnuQuanLyThucDon_Click);

            // 
            // mnuQuanLyDanhMuc
            // 
            this.mnuQuanLyDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuQuanLyDanhMuc.Name = "mnuQuanLyDanhMuc";
            this.mnuQuanLyDanhMuc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuQuanLyDanhMuc.Size = new System.Drawing.Size(258, 22);
            this.mnuQuanLyDanhMuc.Text = "Quản lý &Danh mục";
            this.mnuQuanLyDanhMuc.Click += new System.EventHandler(this.mnuQuanLyDanhMuc_Click);

            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(255, 6);

            // 
            // mnuManHinhPhaChe
            // 
            this.mnuManHinhPhaChe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mnuManHinhPhaChe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.mnuManHinhPhaChe.Name = "mnuManHinhPhaChe";
            this.mnuManHinhPhaChe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnuManHinhPhaChe.Size = new System.Drawing.Size(258, 22);
            this.mnuManHinhPhaChe.Text = "Màn hình &Pha chế [Timer]";
            this.mnuManHinhPhaChe.Click += new System.EventHandler(this.mnuManHinhPhaChe_Click);

            // 
            // mnuCuaSo
            // 
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuTileHorizontal,
            this.mnuTileVertical,
            this.toolStripSeparator3,
            this.mnuDongTatCa});
            this.mnuCuaSo.Name = "mnuCuaSo";
            this.mnuCuaSo.Size = new System.Drawing.Size(60, 21);
            this.mnuCuaSo.Text = "&Cửa sổ";

            // 
            // mnuCascade
            // 
            this.mnuCascade.Name = "mnuCascade";
            this.mnuCascade.Size = new System.Drawing.Size(184, 22);
            this.mnuCascade.Text = "&Sắp xếp bậc thang";
            this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);

            // 
            // mnuTileHorizontal
            // 
            this.mnuTileHorizontal.Name = "mnuTileHorizontal";
            this.mnuTileHorizontal.Size = new System.Drawing.Size(184, 22);
            this.mnuTileHorizontal.Text = "Sắp xếp &ngang";
            this.mnuTileHorizontal.Click += new System.EventHandler(this.mnuTileHorizontal_Click);

            // 
            // mnuTileVertical
            // 
            this.mnuTileVertical.Name = "mnuTileVertical";
            this.mnuTileVertical.Size = new System.Drawing.Size(184, 22);
            this.mnuTileVertical.Text = "Sắp xếp &dọc";
            this.mnuTileVertical.Click += new System.EventHandler(this.mnuTileVertical_Click);

            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);

            // 
            // mnuDongTatCa
            // 
            this.mnuDongTatCa.Name = "mnuDongTatCa";
            this.mnuDongTatCa.Size = new System.Drawing.Size(184, 22);
            this.mnuDongTatCa.Text = "Đóng &tất cả cửa sổ";
            this.mnuDongTatCa.Click += new System.EventHandler(this.mnuDongTatCa_Click);

            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuThongTinSV});
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(69, 21);
            this.mnuTroGiup.Text = "&Trợ giúp";

            // 
            // mnuThongTinSV
            // 
            this.mnuThongTinSV.Name = "mnuThongTinSV";
            this.mnuThongTinSV.Size = new System.Drawing.Size(251, 22);
            this.mnuThongTinSV.Text = "Thông tin đề tài & Sinh viên (SV1)";
            this.mnuThongTinSV.Click += new System.EventHandler(this.mnuThongTinSV_Click);

            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung,
            this.lblPhanHe,
            this.lblThuMucData,
            this.lblThoiGian});
            this.statusStripMain.Location = new System.Drawing.Point(0, 729);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1280, 24);
            this.statusStripMain.TabIndex = 2;

            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(176, 19);
            this.lblNguoiDung.Text = "Đăng nhập: Nguyễn Hoàng Phúc";

            // 
            // lblPhanHe
            // 
            this.lblPhanHe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblPhanHe.Name = "lblPhanHe";
            this.lblPhanHe.Size = new System.Drawing.Size(200, 19);
            this.lblPhanHe.Text = "| Phân hệ 1: Thực đơn (Giai đoạn 1 & 2)";

            // 
            // lblThuMucData
            // 
            this.lblThuMucData.ForeColor = System.Drawing.Color.DimGray;
            this.lblThuMucData.Name = "lblThuMucData";
            this.lblThuMucData.Size = new System.Drawing.Size(193, 19);
            this.lblThuMucData.Text = "| CSDL: Bộ nhớ List<T> + Tập tin UTF-8";

            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(696, 19);
            this.lblThoiGian.Spring = true;
            this.lblThoiGian.Text = "Thời gian: 00:00:00";
            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // timerClockMain
            // 
            this.timerClockMain.Enabled = true;
            this.timerClockMain.Interval = 1000;
            this.timerClockMain.Tick += new System.EventHandler(this.timerClockMain_Tick);

            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 753);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Quán Cà Phê - Đề tài 3 (SV1: Nguyễn Hoàng Phúc)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

