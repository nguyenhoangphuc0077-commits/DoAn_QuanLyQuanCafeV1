namespace QuanLyQuanCafe.Forms
{
    partial class FormQuanLyDanhMuc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvwDanhMuc;
        private System.Windows.Forms.ColumnHeader colMaDM;
        private System.Windows.Forms.ColumnHeader colTenDM;
        private System.Windows.Forms.ColumnHeader colSoLuongMon;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaDM;
        private System.Windows.Forms.TextBox txtMaDM;
        private System.Windows.Forms.Label lblTenDM;
        private System.Windows.Forms.TextBox txtTenDM;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

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
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwDanhMuc = new System.Windows.Forms.ListView();
            this.colMaDM = new System.Windows.Forms.ColumnHeader();
            this.colTenDM = new System.Windows.Forms.ColumnHeader();
            this.colSoLuongMon = new System.Windows.Forms.ColumnHeader();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaDM = new System.Windows.Forms.Label();
            this.txtMaDM = new System.Windows.Forms.TextBox();
            this.lblTenDM = new System.Windows.Forms.Label();
            this.txtTenDM = new System.Windows.Forms.TextBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 60);
            this.pnlHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ DANH MỤC THỰC ĐƠN";

            // grpThongTin
            this.grpThongTin.Controls.Add(this.lblMaDM);
            this.grpThongTin.Controls.Add(this.txtMaDM);
            this.grpThongTin.Controls.Add(this.lblTenDM);
            this.grpThongTin.Controls.Add(this.txtTenDM);
            this.grpThongTin.Controls.Add(this.btnThemMoi);
            this.grpThongTin.Controls.Add(this.btnLuu);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(15, 75);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(620, 130);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin Danh mục";

            // lblMaDM
            this.lblMaDM.AutoSize = true;
            this.lblMaDM.Location = new System.Drawing.Point(20, 32);
            this.lblMaDM.Name = "lblMaDM";
            this.lblMaDM.Size = new System.Drawing.Size(91, 17);
            this.lblMaDM.TabIndex = 0;
            this.lblMaDM.Text = "Mã danh mục:";

            // txtMaDM
            this.txtMaDM.Location = new System.Drawing.Point(125, 29);
            this.txtMaDM.Name = "txtMaDM";
            this.txtMaDM.Size = new System.Drawing.Size(150, 24);
            this.txtMaDM.TabIndex = 1;

            // lblTenDM
            this.lblTenDM.AutoSize = true;
            this.lblTenDM.Location = new System.Drawing.Point(300, 32);
            this.lblTenDM.Name = "lblTenDM";
            this.lblTenDM.Size = new System.Drawing.Size(92, 17);
            this.lblTenDM.TabIndex = 2;
            this.lblTenDM.Text = "Tên danh mục:";

            // txtTenDM
            this.txtTenDM.Location = new System.Drawing.Point(400, 29);
            this.txtTenDM.Name = "txtTenDM";
            this.txtTenDM.Size = new System.Drawing.Size(200, 24);
            this.txtTenDM.TabIndex = 3;

            // btnThemMoi
            this.btnThemMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnThemMoi.Location = new System.Drawing.Point(125, 75);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(100, 35);
            this.btnThemMoi.TabIndex = 4;
            this.btnThemMoi.Text = "Làm mới";
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);

            // btnLuu
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLuu.Location = new System.Drawing.Point(240, 75);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 35);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // btnXoa
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.Location = new System.Drawing.Point(355, 75);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // grpDanhSach
            this.grpDanhSach.Controls.Add(this.lvwDanhMuc);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpDanhSach.Location = new System.Drawing.Point(15, 215);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(620, 240);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách danh mục hiện có";

            // lvwDanhMuc
            this.lvwDanhMuc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaDM,
            this.colTenDM,
            this.colSoLuongMon});
            this.lvwDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDanhMuc.FullRowSelect = true;
            this.lvwDanhMuc.GridLines = true;
            this.lvwDanhMuc.Location = new System.Drawing.Point(3, 20);
            this.lvwDanhMuc.MultiSelect = false;
            this.lvwDanhMuc.Name = "lvwDanhMuc";
            this.lvwDanhMuc.Size = new System.Drawing.Size(614, 217);
            this.lvwDanhMuc.TabIndex = 0;
            this.lvwDanhMuc.UseCompatibleStateImageBehavior = false;
            this.lvwDanhMuc.View = System.Windows.Forms.View.Details;
            this.lvwDanhMuc.SelectedIndexChanged += new System.EventHandler(this.lvwDanhMuc_SelectedIndexChanged);

            // colMaDM
            this.colMaDM.Text = "Mã DM";
            this.colMaDM.Width = 100;

            // colTenDM
            this.colTenDM.Text = "Tên danh mục";
            this.colTenDM.Width = 350;

            // colSoLuongMon
            this.colSoLuongMon.Text = "Số món";
            this.colSoLuongMon.Width = 120;

            // btnDong
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDong.Location = new System.Drawing.Point(535, 465);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            // FormQuanLyDanhMuc
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 510);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuanLyDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Danh mục - Nguyễn Hoàng Phúc";
            this.Load += new System.EventHandler(this.FormQuanLyDanhMuc_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}

