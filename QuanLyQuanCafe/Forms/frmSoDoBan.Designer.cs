namespace QuanLyQuanCafe.Forms
{
    partial class frmSoDoBan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Header controls
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblKhuVuc = new System.Windows.Forms.Label();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();

            // Right panel controls
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblTieuDeBan = new System.Windows.Forms.Label();
            this.lvChiTiet = new System.Windows.Forms.ListView();
            this.colTenMon = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colSoLuong = new System.Windows.Forms.ColumnHeader();
            this.colThanhTien = new System.Windows.Forms.ColumnHeader();
            this.colTrangThaiPhaChe = new System.Windows.Forms.ColumnHeader();
            this.pnlThaoTac = new System.Windows.Forms.Panel();
            this.btnGoiMon = new System.Windows.Forms.Button();
            this.btnTachHD = new System.Windows.Forms.Button();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();

            // Main table panel
            this.pnlSoDo = new System.Windows.Forms.Panel();

            // Context Menu
            this.cmsBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miGoiMon = new System.Windows.Forms.ToolStripMenuItem();
            this.miTachHD = new System.Windows.Forms.ToolStripMenuItem();
            this.miChuyenBan = new System.Windows.Forms.ToolStripMenuItem();
            this.miGopBan = new System.Windows.Forms.ToolStripMenuItem();
            this.miThanhToan = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlThaoTac.SuspendLayout();
            this.cmsBan.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.btnLamMoi);
            this.pnlHeader.Controls.Add(this.lblThongKe);
            this.pnlHeader.Controls.Add(this.cboKhuVuc);
            this.pnlHeader.Controls.Add(this.lblKhuVuc);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 46);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblKhuVuc
            // 
            this.lblKhuVuc.AutoSize = true;
            this.lblKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKhuVuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblKhuVuc.Location = new System.Drawing.Point(12, 13);
            this.lblKhuVuc.Name = "lblKhuVuc";
            this.lblKhuVuc.Size = new System.Drawing.Size(89, 17);
            this.lblKhuVuc.TabIndex = 0;
            this.lblKhuVuc.Text = "Lọc khu vực:";

            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(107, 10);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(180, 25);
            this.cboKhuVuc.TabIndex = 1;

            // 
            // lblThongKe
            // 
            this.lblThongKe.AutoSize = true;
            this.lblThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblThongKe.Location = new System.Drawing.Point(310, 14);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(320, 17);
            this.lblThongKe.TabIndex = 2;
            this.lblThongKe.Text = "Tổng: 15 bàn | Trống: 12 bàn | Có khách: 3 bàn";

            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(884, 7);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(88, 30);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.lvChiTiet);
            this.pnlRight.Controls.Add(this.pnlThaoTac);
            this.pnlRight.Controls.Add(this.lblTieuDeBan);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(554, 46);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(430, 515);
            this.pnlRight.TabIndex = 1;

            // 
            // lblTieuDeBan
            // 
            this.lblTieuDeBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblTieuDeBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDeBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTieuDeBan.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeBan.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDeBan.Name = "lblTieuDeBan";
            this.lblTieuDeBan.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lblTieuDeBan.Size = new System.Drawing.Size(428, 36);
            this.lblTieuDeBan.TabIndex = 0;
            this.lblTieuDeBan.Text = "CHI TIẾT MÓN BÀN: (Chưa chọn bàn)";
            this.lblTieuDeBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // lvChiTiet
            // 
            this.lvChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTenMon,
            this.colSize,
            this.colSoLuong,
            this.colThanhTien,
            this.colTrangThaiPhaChe});
            this.lvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvChiTiet.FullRowSelect = true;
            this.lvChiTiet.GridLines = true;
            this.lvChiTiet.HideSelection = false;
            this.lvChiTiet.Location = new System.Drawing.Point(0, 36);
            this.lvChiTiet.MultiSelect = false;
            this.lvChiTiet.Name = "lvChiTiet";
            this.lvChiTiet.Size = new System.Drawing.Size(428, 417);
            this.lvChiTiet.TabIndex = 1;
            this.lvChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvChiTiet.View = System.Windows.Forms.View.Details;

            // 
            // colTenMon
            // 
            this.colTenMon.Text = "Tên món";
            this.colTenMon.Width = 125;

            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSize.Width = 42;

            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "SL";
            this.colSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSoLuong.Width = 38;

            // 
            // colThanhTien
            // 
            this.colThanhTien.Text = "Thành tiền";
            this.colThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colThanhTien.Width = 85;

            // 
            // colTrangThaiPhaChe
            // 
            this.colTrangThaiPhaChe.Text = "Pha chế (KDS)";
            this.colTrangThaiPhaChe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTrangThaiPhaChe.Width = 115;

            // 
            // pnlThaoTac
            // 
            this.pnlThaoTac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlThaoTac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThaoTac.Controls.Add(this.btnThanhToan);
            this.pnlThaoTac.Controls.Add(this.btnGopBan);
            this.pnlThaoTac.Controls.Add(this.btnChuyenBan);
            this.pnlThaoTac.Controls.Add(this.btnTachHD);
            this.pnlThaoTac.Controls.Add(this.btnGoiMon);
            this.pnlThaoTac.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThaoTac.Location = new System.Drawing.Point(0, 453);
            this.pnlThaoTac.Name = "pnlThaoTac";
            this.pnlThaoTac.Size = new System.Drawing.Size(428, 60);
            this.pnlThaoTac.TabIndex = 2;

            // 
            // btnGoiMon
            // 
            this.btnGoiMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnGoiMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoiMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoiMon.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoiMon.ForeColor = System.Drawing.Color.White;
            this.btnGoiMon.Location = new System.Drawing.Point(4, 10);
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.Size = new System.Drawing.Size(78, 38);
            this.btnGoiMon.TabIndex = 0;
            this.btnGoiMon.Text = "➕ Gọi";
            this.btnGoiMon.UseVisualStyleBackColor = false;
            this.btnGoiMon.Click += new System.EventHandler(this.btnGoiMon_Click);

            // 
            // btnTachHD
            // 
            this.btnTachHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(162)))));
            this.btnTachHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTachHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTachHD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTachHD.ForeColor = System.Drawing.Color.White;
            this.btnTachHD.Location = new System.Drawing.Point(86, 10);
            this.btnTachHD.Name = "btnTachHD";
            this.btnTachHD.Size = new System.Drawing.Size(78, 38);
            this.btnTachHD.TabIndex = 1;
            this.btnTachHD.Text = "✂ Tách";
            this.btnTachHD.UseVisualStyleBackColor = false;
            this.btnTachHD.Click += new System.EventHandler(this.btnTachHD_Click);

            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.btnChuyenBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyenBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenBan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChuyenBan.ForeColor = System.Drawing.Color.White;
            this.btnChuyenBan.Location = new System.Drawing.Point(168, 10);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(78, 38);
            this.btnChuyenBan.TabIndex = 2;
            this.btnChuyenBan.Text = "🔁 Đổi";
            this.btnChuyenBan.UseVisualStyleBackColor = false;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);

            // 
            // btnGopBan
            // 
            this.btnGopBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnGopBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGopBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGopBan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGopBan.ForeColor = System.Drawing.Color.White;
            this.btnGopBan.Location = new System.Drawing.Point(250, 10);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(78, 38);
            this.btnGopBan.TabIndex = 3;
            this.btnGopBan.Text = "🔀 Gộp";
            this.btnGopBan.UseVisualStyleBackColor = false;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);

            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(332, 10);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(90, 38);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "💳 T.Toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // 
            // pnlSoDo
            // 
            this.pnlSoDo.AutoScroll = true;
            this.pnlSoDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlSoDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoDo.Location = new System.Drawing.Point(0, 46);
            this.pnlSoDo.Name = "pnlSoDo";
            this.pnlSoDo.Size = new System.Drawing.Size(554, 515);
            this.pnlSoDo.TabIndex = 2;

            // 
            // cmsBan
            // 
            this.cmsBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGoiMon,
            this.miTachHD,
            this.miChuyenBan,
            this.miGopBan,
            this.miThanhToan});
            this.cmsBan.Name = "cmsBan";
            this.cmsBan.Size = new System.Drawing.Size(188, 114);

            // 
            // miGoiMon
            // 
            this.miGoiMon.Name = "miGoiMon";
            this.miGoiMon.Size = new System.Drawing.Size(187, 22);
            this.miGoiMon.Text = "Gọi món";
            this.miGoiMon.Click += new System.EventHandler(this.miGoiMon_Click);

            // 
            // miTachHD
            // 
            this.miTachHD.Name = "miTachHD";
            this.miTachHD.Size = new System.Drawing.Size(187, 22);
            this.miTachHD.Text = "Tách hóa đơn";
            this.miTachHD.Click += new System.EventHandler(this.miTachHD_Click);

            // 
            // miChuyenBan
            // 
            this.miChuyenBan.Name = "miChuyenBan";
            this.miChuyenBan.Size = new System.Drawing.Size(187, 22);
            this.miChuyenBan.Text = "Chuyển bàn";
            this.miChuyenBan.Click += new System.EventHandler(this.miChuyenBan_Click);

            // 
            // miGopBan
            // 
            this.miGopBan.Name = "miGopBan";
            this.miGopBan.Size = new System.Drawing.Size(187, 22);
            this.miGopBan.Text = "Gộp bàn";
            this.miGopBan.Click += new System.EventHandler(this.miGopBan_Click);

            // 
            // miThanhToan
            // 
            this.miThanhToan.Name = "miThanhToan";
            this.miThanhToan.Size = new System.Drawing.Size(187, 22);
            this.miThanhToan.Text = "Thanh toán hóa đơn";
            this.miThanhToan.Click += new System.EventHandler(this.miThanhToan_Click);

            // 
            // frmSoDoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlSoDo);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmSoDoBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sơ đồ bàn - Quản lý Quán Cà Phê";
            this.Load += new System.EventHandler(this.frmSoDoBan_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlThaoTac.ResumeLayout(false);
            this.cmsBan.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblKhuVuc;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.Label lblThongKe;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTieuDeBan;
        private System.Windows.Forms.ListView lvChiTiet;
        private System.Windows.Forms.ColumnHeader colTenMon;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colThanhTien;
        private System.Windows.Forms.ColumnHeader colTrangThaiPhaChe;
        private System.Windows.Forms.Panel pnlThaoTac;
        private System.Windows.Forms.Button btnGoiMon;
        private System.Windows.Forms.Button btnTachHD;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.Button btnThanhToan;

        private System.Windows.Forms.Panel pnlSoDo;

        private System.Windows.Forms.ContextMenuStrip cmsBan;
        private System.Windows.Forms.ToolStripMenuItem miGoiMon;
        private System.Windows.Forms.ToolStripMenuItem miTachHD;
        private System.Windows.Forms.ToolStripMenuItem miChuyenBan;
        private System.Windows.Forms.ToolStripMenuItem miGopBan;
        private System.Windows.Forms.ToolStripMenuItem miThanhToan;
    }
}
