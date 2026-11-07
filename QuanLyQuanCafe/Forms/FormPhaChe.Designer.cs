namespace QuanLyQuanCafe.Forms
{
    partial class FormPhaChe
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDongHo;
        private System.Windows.Forms.Label lblSubTitle;

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnBatDauPha;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.Button btnHuyDon;
        private System.Windows.Forms.Button btnGiaLapDon;

        private System.Windows.Forms.ListView lvwPhaChe;
        private System.Windows.Forms.ColumnHeader colMaOrder;
        private System.Windows.Forms.ColumnHeader colBan;
        private System.Windows.Forms.ColumnHeader colMon;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colThoiGianGoi;
        private System.Windows.Forms.ColumnHeader colThoiGianCho;
        private System.Windows.Forms.ColumnHeader colGhiChu;
        private System.Windows.Forms.ColumnHeader colTrangThai;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblTongCho;
        private System.Windows.Forms.ToolStripStatusLabel lblDangPha;
        private System.Windows.Forms.ToolStripStatusLabel lblDaXong;
        private System.Windows.Forms.ToolStripStatusLabel lblTimerInfo;

        // Timers (Chương 3)
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerAutoRefresh;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblDongHo = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnBatDauPha = new System.Windows.Forms.Button();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btnHuyDon = new System.Windows.Forms.Button();
            this.btnGiaLapDon = new System.Windows.Forms.Button();
            this.lvwPhaChe = new System.Windows.Forms.ListView();
            this.colMaOrder = new System.Windows.Forms.ColumnHeader();
            this.colBan = new System.Windows.Forms.ColumnHeader();
            this.colMon = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colSoLuong = new System.Windows.Forms.ColumnHeader();
            this.colThoiGianGoi = new System.Windows.Forms.ColumnHeader();
            this.colThoiGianCho = new System.Windows.Forms.ColumnHeader();
            this.colGhiChu = new System.Windows.Forms.ColumnHeader();
            this.colTrangThai = new System.Windows.Forms.ColumnHeader();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblTongCho = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDangPha = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDaXong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTimerInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerAutoRefresh = new System.Windows.Forms.Timer(this.components);

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblDongHo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1150, 75);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(183)))), ((int)(((byte)(77)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(510, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "KITCHEN & BARISTA DISPLAY SYSTEM (KDS)";

            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Silver;
            this.lblSubTitle.Location = new System.Drawing.Point(18, 45);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(560, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Màn hình quầy pha chế [Điểm cộng T2.5] - Tự động cập nhật bằng Timer (Nguyễn Hoàng Phúc)";

            // 
            // lblDongHo
            // 
            this.lblDongHo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDongHo.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDongHo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.lblDongHo.Location = new System.Drawing.Point(850, 18);
            this.lblDongHo.Name = "lblDongHo";
            this.lblDongHo.Size = new System.Drawing.Size(280, 38);
            this.lblDongHo.TabIndex = 2;
            this.lblDongHo.Text = "00:00:00";
            this.lblDongHo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pnlToolbar.Controls.Add(this.lblLocTrangThai);
            this.pnlToolbar.Controls.Add(this.cboLocTrangThai);
            this.pnlToolbar.Controls.Add(this.chkAutoRefresh);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.btnBatDauPha);
            this.pnlToolbar.Controls.Add(this.btnHoanThanh);
            this.pnlToolbar.Controls.Add(this.btnHuyDon);
            this.pnlToolbar.Controls.Add(this.btnGiaLapDon);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 75);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1150, 60);
            this.pnlToolbar.TabIndex = 1;

            // 
            // lblLocTrangThai
            // 
            this.lblLocTrangThai.AutoSize = true;
            this.lblLocTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocTrangThai.Location = new System.Drawing.Point(15, 22);
            this.lblLocTrangThai.Name = "lblLocTrangThai";
            this.lblLocTrangThai.Size = new System.Drawing.Size(65, 15);
            this.lblLocTrangThai.TabIndex = 0;
            this.lblLocTrangThai.Text = "Trạng thái:";

            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Items.AddRange(new object[] {
            "-- Tất cả đơn --",
            "Chờ pha chế",
            "Đang pha chế",
            "Hoàn thành"});
            this.cboLocTrangThai.Location = new System.Drawing.Point(85, 18);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(130, 23);
            this.cboLocTrangThai.TabIndex = 1;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboLocTrangThai_SelectedIndexChanged);

            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkAutoRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.chkAutoRefresh.Location = new System.Drawing.Point(235, 20);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(185, 19);
            this.chkAutoRefresh.TabIndex = 2;
            this.chkAutoRefresh.Text = "Tự động quét Timer (mỗi 3s)";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(430, 15);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 30);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // btnBatDauPha
            // 
            this.btnBatDauPha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnBatDauPha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBatDauPha.ForeColor = System.Drawing.Color.White;
            this.btnBatDauPha.Location = new System.Drawing.Point(530, 13);
            this.btnBatDauPha.Name = "btnBatDauPha";
            this.btnBatDauPha.Size = new System.Drawing.Size(120, 34);
            this.btnBatDauPha.TabIndex = 4;
            this.btnBatDauPha.Text = "Bắt đầu làm";
            this.btnBatDauPha.UseVisualStyleBackColor = false;
            this.btnBatDauPha.Click += new System.EventHandler(this.btnBatDauPha_Click);

            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnHoanThanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.Location = new System.Drawing.Point(660, 13);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(130, 34);
            this.btnHoanThanh.TabIndex = 5;
            this.btnHoanThanh.Text = "Hoàn thành món";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);

            // 
            // btnHuyDon
            // 
            this.btnHuyDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnHuyDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuyDon.ForeColor = System.Drawing.Color.White;
            this.btnHuyDon.Location = new System.Drawing.Point(800, 13);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(95, 34);
            this.btnHuyDon.TabIndex = 6;
            this.btnHuyDon.Text = "Hủy món";
            this.btnHuyDon.UseVisualStyleBackColor = false;
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);

            // 
            // btnGiaLapDon
            // 
            this.btnGiaLapDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGiaLapDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(27)))), ((int)(((byte)(154)))));
            this.btnGiaLapDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGiaLapDon.ForeColor = System.Drawing.Color.White;
            this.btnGiaLapDon.Location = new System.Drawing.Point(945, 12);
            this.btnGiaLapDon.Name = "btnGiaLapDon";
            this.btnGiaLapDon.Size = new System.Drawing.Size(185, 36);
            this.btnGiaLapDon.TabIndex = 7;
            this.btnGiaLapDon.Text = "+ Giả lập Order mới (Test)";
            this.btnGiaLapDon.UseVisualStyleBackColor = false;
            this.btnGiaLapDon.Click += new System.EventHandler(this.btnGiaLapDon_Click);

            // 
            // lvwPhaChe
            // 
            this.lvwPhaChe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaOrder,
            this.colBan,
            this.colMon,
            this.colSize,
            this.colSoLuong,
            this.colThoiGianGoi,
            this.colThoiGianCho,
            this.colGhiChu,
            this.colTrangThai});
            this.lvwPhaChe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPhaChe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvwPhaChe.FullRowSelect = true;
            this.lvwPhaChe.GridLines = true;
            this.lvwPhaChe.Location = new System.Drawing.Point(0, 135);
            this.lvwPhaChe.MultiSelect = false;
            this.lvwPhaChe.Name = "lvwPhaChe";
            this.lvwPhaChe.Size = new System.Drawing.Size(1150, 480);
            this.lvwPhaChe.TabIndex = 2;
            this.lvwPhaChe.UseCompatibleStateImageBehavior = false;
            this.lvwPhaChe.View = System.Windows.Forms.View.Details;

            // 
            // colMaOrder
            // 
            this.colMaOrder.Text = "Mã Đơn";
            this.colMaOrder.Width = 85;

            // 
            // colBan
            // 
            this.colBan.Text = "Khu Vực / Bàn";
            this.colBan.Width = 110;

            // 
            // colMon
            // 
            this.colMon.Text = "Tên món";
            this.colMon.Width = 220;

            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSize.Width = 60;

            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "SL";
            this.colSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoLuong.Width = 50;

            // 
            // colThoiGianGoi
            // 
            this.colThoiGianGoi.Text = "Thời gian gọi";
            this.colThoiGianGoi.Width = 140;

            // 
            // colThoiGianCho
            // 
            this.colThoiGianCho.Text = "Chờ (phút)";
            this.colThoiGianCho.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colThoiGianCho.Width = 90;

            // 
            // colGhiChu
            // 
            this.colGhiChu.Text = "Ghi chú của khách";
            this.colGhiChu.Width = 220;

            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTrangThai.Width = 130;

            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongCho,
            this.lblDangPha,
            this.lblDaXong,
            this.lblTimerInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 615);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1150, 24);
            this.statusStrip.TabIndex = 3;

            // 
            // lblTongCho
            // 
            this.lblTongCho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongCho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblTongCho.Name = "lblTongCho";
            this.lblTongCho.Size = new System.Drawing.Size(120, 19);
            this.lblTongCho.Text = "Chờ pha chế: 0 món";

            // 
            // lblDangPha
            // 
            this.lblDangPha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDangPha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblDangPha.Name = "lblDangPha";
            this.lblDangPha.Size = new System.Drawing.Size(130, 19);
            this.lblDangPha.Text = "| Đang pha chế: 0 món";

            // 
            // lblDaXong
            // 
            this.lblDaXong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDaXong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblDaXong.Name = "lblDaXong";
            this.lblDaXong.Size = new System.Drawing.Size(115, 19);
            this.lblDaXong.Text = "| Hoàn thành: 0 món";

            // 
            // lblTimerInfo
            // 
            this.lblTimerInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTimerInfo.Name = "lblTimerInfo";
            this.lblTimerInfo.Size = new System.Drawing.Size(280, 19);
            this.lblTimerInfo.Text = "| Timer tự động cập nhật: ĐANG HOẠT ĐỘNG (3s)";

            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // 
            // timerAutoRefresh
            // 
            this.timerAutoRefresh.Enabled = true;
            this.timerAutoRefresh.Interval = 3000;
            this.timerAutoRefresh.Tick += new System.EventHandler(this.timerAutoRefresh_Tick);

            // 
            // FormPhaChe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 639);
            this.Controls.Add(this.lvwPhaChe);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FormPhaChe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn hình Quầy Pha Chế (Barista Display) - Nguyễn Hoàng Phúc";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPhaChe_FormClosing);
            this.Load += new System.EventHandler(this.FormPhaChe_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
