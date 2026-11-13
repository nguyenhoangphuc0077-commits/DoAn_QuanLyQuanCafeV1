namespace QuanLyQuanCafe.Forms
{
    partial class frmTachHoaDon
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpNguon = new System.Windows.Forms.GroupBox();
            this.lvwNguon = new System.Windows.Forms.ListView();
            this.colNguonTen = new System.Windows.Forms.ColumnHeader();
            this.colNguonSize = new System.Windows.Forms.ColumnHeader();
            this.colNguonSL = new System.Windows.Forms.ColumnHeader();
            this.colNguonGia = new System.Windows.Forms.ColumnHeader();
            this.colNguonThanhTien = new System.Windows.Forms.ColumnHeader();
            this.grpDich = new System.Windows.Forms.GroupBox();
            this.lvwDich = new System.Windows.Forms.ListView();
            this.colDichTen = new System.Windows.Forms.ColumnHeader();
            this.colDichSize = new System.Windows.Forms.ColumnHeader();
            this.colDichSL = new System.Windows.Forms.ColumnHeader();
            this.colDichGia = new System.Windows.Forms.ColumnHeader();
            this.colDichThanhTien = new System.Windows.Forms.ColumnHeader();
            this.pnlDieuKhien = new System.Windows.Forms.Panel();
            this.btnChuyen1 = new System.Windows.Forms.Button();
            this.btnChuyenHet = new System.Windows.Forms.Button();
            this.btnTraLai1 = new System.Windows.Forms.Button();
            this.btnTraLaiHet = new System.Windows.Forms.Button();
            this.pnlTuyChon = new System.Windows.Forms.Panel();
            this.rdoGiuBan = new System.Windows.Forms.RadioButton();
            this.rdoSangBanMoi = new System.Windows.Forms.RadioButton();
            this.cboBanTrong = new System.Windows.Forms.ComboBox();
            this.lblTongTienTach = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpNguon.SuspendLayout();
            this.grpDich.SuspendLayout();
            this.pnlDieuKhien.SuspendLayout();
            this.pnlTuyChon.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(162)))));
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(784, 42);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TÁCH HÓA ĐƠN THANH TOÁN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // grpNguon
            // 
            this.grpNguon.Controls.Add(this.lvwNguon);
            this.grpNguon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpNguon.Location = new System.Drawing.Point(12, 50);
            this.grpNguon.Name = "grpNguon";
            this.grpNguon.Size = new System.Drawing.Size(340, 310);
            this.grpNguon.TabIndex = 1;
            this.grpNguon.TabStop = false;
            this.grpNguon.Text = "Hóa đơn hiện tại";

            // 
            // lvwNguon
            // 
            this.lvwNguon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNguonTen,
            this.colNguonSize,
            this.colNguonSL,
            this.colNguonGia,
            this.colNguonThanhTien});
            this.lvwNguon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwNguon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvwNguon.FullRowSelect = true;
            this.lvwNguon.GridLines = true;
            this.lvwNguon.HideSelection = false;
            this.lvwNguon.Location = new System.Drawing.Point(3, 20);
            this.lvwNguon.MultiSelect = false;
            this.lvwNguon.Name = "lvwNguon";
            this.lvwNguon.Size = new System.Drawing.Size(334, 287);
            this.lvwNguon.TabIndex = 0;
            this.lvwNguon.UseCompatibleStateImageBehavior = false;
            this.lvwNguon.View = System.Windows.Forms.View.Details;

            // 
            // colNguonTen
            // 
            this.colNguonTen.Text = "Tên món";
            this.colNguonTen.Width = 115;

            // 
            // colNguonSize
            // 
            this.colNguonSize.Text = "Size";
            this.colNguonSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNguonSize.Width = 38;

            // 
            // colNguonSL
            // 
            this.colNguonSL.Text = "SL";
            this.colNguonSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNguonSL.Width = 35;

            // 
            // colNguonGia
            // 
            this.colNguonGia.Text = "Đơn giá";
            this.colNguonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNguonGia.Width = 65;

            // 
            // colNguonThanhTien
            // 
            this.colNguonThanhTien.Text = "Thành tiền";
            this.colNguonThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNguonThanhTien.Width = 75;

            // 
            // pnlDieuKhien
            // 
            this.pnlDieuKhien.Controls.Add(this.btnChuyen1);
            this.pnlDieuKhien.Controls.Add(this.btnChuyenHet);
            this.pnlDieuKhien.Controls.Add(this.btnTraLai1);
            this.pnlDieuKhien.Controls.Add(this.btnTraLaiHet);
            this.pnlDieuKhien.Location = new System.Drawing.Point(358, 110);
            this.pnlDieuKhien.Name = "pnlDieuKhien";
            this.pnlDieuKhien.Size = new System.Drawing.Size(68, 190);
            this.pnlDieuKhien.TabIndex = 2;

            // 
            // btnChuyen1
            // 
            this.btnChuyen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnChuyen1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyen1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyen1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChuyen1.ForeColor = System.Drawing.Color.White;
            this.btnChuyen1.Location = new System.Drawing.Point(10, 10);
            this.btnChuyen1.Name = "btnChuyen1";
            this.btnChuyen1.Size = new System.Drawing.Size(48, 35);
            this.btnChuyen1.TabIndex = 0;
            this.btnChuyen1.Text = ">";
            this.btnChuyen1.UseVisualStyleBackColor = false;
            this.btnChuyen1.Click += new System.EventHandler(this.btnChuyen1_Click);

            // 
            // btnChuyenHet
            // 
            this.btnChuyenHet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.btnChuyenHet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChuyenHet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChuyenHet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChuyenHet.ForeColor = System.Drawing.Color.White;
            this.btnChuyenHet.Location = new System.Drawing.Point(10, 52);
            this.btnChuyenHet.Name = "btnChuyenHet";
            this.btnChuyenHet.Size = new System.Drawing.Size(48, 35);
            this.btnChuyenHet.TabIndex = 1;
            this.btnChuyenHet.Text = ">>";
            this.btnChuyenHet.UseVisualStyleBackColor = false;
            this.btnChuyenHet.Click += new System.EventHandler(this.btnChuyenHet_Click);

            // 
            // btnTraLai1
            // 
            this.btnTraLai1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnTraLai1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraLai1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraLai1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTraLai1.ForeColor = System.Drawing.Color.White;
            this.btnTraLai1.Location = new System.Drawing.Point(10, 102);
            this.btnTraLai1.Name = "btnTraLai1";
            this.btnTraLai1.Size = new System.Drawing.Size(48, 35);
            this.btnTraLai1.TabIndex = 2;
            this.btnTraLai1.Text = "<";
            this.btnTraLai1.UseVisualStyleBackColor = false;
            this.btnTraLai1.Click += new System.EventHandler(this.btnTraLai1_Click);

            // 
            // btnTraLaiHet
            // 
            this.btnTraLaiHet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnTraLaiHet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraLaiHet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraLaiHet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTraLaiHet.ForeColor = System.Drawing.Color.White;
            this.btnTraLaiHet.Location = new System.Drawing.Point(10, 144);
            this.btnTraLaiHet.Name = "btnTraLaiHet";
            this.btnTraLaiHet.Size = new System.Drawing.Size(48, 35);
            this.btnTraLaiHet.TabIndex = 3;
            this.btnTraLaiHet.Text = "<<";
            this.btnTraLaiHet.UseVisualStyleBackColor = false;
            this.btnTraLaiHet.Click += new System.EventHandler(this.btnTraLaiHet_Click);

            // 
            // grpDich
            // 
            this.grpDich.Controls.Add(this.lvwDich);
            this.grpDich.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpDich.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(31)))), ((int)(((byte)(162)))));
            this.grpDich.Location = new System.Drawing.Point(432, 50);
            this.grpDich.Name = "grpDich";
            this.grpDich.Size = new System.Drawing.Size(340, 310);
            this.grpDich.TabIndex = 3;
            this.grpDich.TabStop = false;
            this.grpDich.Text = "Hóa đơn mới tách";

            // 
            // lvwDich
            // 
            this.lvwDich.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDichTen,
            this.colDichSize,
            this.colDichSL,
            this.colDichGia,
            this.colDichThanhTien});
            this.lvwDich.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvwDich.FullRowSelect = true;
            this.lvwDich.GridLines = true;
            this.lvwDich.HideSelection = false;
            this.lvwDich.Location = new System.Drawing.Point(3, 20);
            this.lvwDich.MultiSelect = false;
            this.lvwDich.Name = "lvwDich";
            this.lvwDich.Size = new System.Drawing.Size(334, 287);
            this.lvwDich.TabIndex = 0;
            this.lvwDich.UseCompatibleStateImageBehavior = false;
            this.lvwDich.View = System.Windows.Forms.View.Details;

            // 
            // colDichTen
            // 
            this.colDichTen.Text = "Tên món";
            this.colDichTen.Width = 115;

            // 
            // colDichSize
            // 
            this.colDichSize.Text = "Size";
            this.colDichSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDichSize.Width = 38;

            // 
            // colDichSL
            // 
            this.colDichSL.Text = "SL";
            this.colDichSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDichSL.Width = 35;

            // 
            // colDichGia
            // 
            this.colDichGia.Text = "Đơn giá";
            this.colDichGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDichGia.Width = 65;

            // 
            // colDichThanhTien
            // 
            this.colDichThanhTien.Text = "Thành tiền";
            this.colDichThanhTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDichThanhTien.Width = 75;

            // 
            // pnlTuyChon
            // 
            this.pnlTuyChon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlTuyChon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTuyChon.Controls.Add(this.lblTongTienTach);
            this.pnlTuyChon.Controls.Add(this.cboBanTrong);
            this.pnlTuyChon.Controls.Add(this.rdoSangBanMoi);
            this.pnlTuyChon.Controls.Add(this.rdoGiuBan);
            this.pnlTuyChon.Location = new System.Drawing.Point(12, 368);
            this.pnlTuyChon.Name = "pnlTuyChon";
            this.pnlTuyChon.Size = new System.Drawing.Size(760, 48);
            this.pnlTuyChon.TabIndex = 4;

            // 
            // rdoGiuBan
            // 
            this.rdoGiuBan.AutoSize = true;
            this.rdoGiuBan.Checked = true;
            this.rdoGiuBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdoGiuBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.rdoGiuBan.Location = new System.Drawing.Point(12, 14);
            this.rdoGiuBan.Name = "rdoGiuBan";
            this.rdoGiuBan.Size = new System.Drawing.Size(262, 19);
            this.rdoGiuBan.TabIndex = 0;
            this.rdoGiuBan.TabStop = true;
            this.rdoGiuBan.Text = "Giữ cùng bàn (Khách thanh toán phần riêng)";
            this.rdoGiuBan.UseVisualStyleBackColor = true;
            this.rdoGiuBan.CheckedChanged += new System.EventHandler(this.rdoGiuBan_CheckedChanged);

            // 
            // rdoSangBanMoi
            // 
            this.rdoSangBanMoi.AutoSize = true;
            this.rdoSangBanMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdoSangBanMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.rdoSangBanMoi.Location = new System.Drawing.Point(286, 14);
            this.rdoSangBanMoi.Name = "rdoSangBanMoi";
            this.rdoSangBanMoi.Size = new System.Drawing.Size(147, 19);
            this.rdoSangBanMoi.TabIndex = 1;
            this.rdoSangBanMoi.Text = "Tách sang bàn trống:";
            this.rdoSangBanMoi.UseVisualStyleBackColor = true;
            this.rdoSangBanMoi.CheckedChanged += new System.EventHandler(this.rdoSangBanMoi_CheckedChanged);

            // 
            // cboBanTrong
            // 
            this.cboBanTrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanTrong.Enabled = false;
            this.cboBanTrong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboBanTrong.FormattingEnabled = true;
            this.cboBanTrong.Location = new System.Drawing.Point(436, 12);
            this.cboBanTrong.Name = "cboBanTrong";
            this.cboBanTrong.Size = new System.Drawing.Size(120, 23);
            this.cboBanTrong.TabIndex = 2;

            // 
            // lblTongTienTach
            // 
            this.lblTongTienTach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTienTach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTongTienTach.Location = new System.Drawing.Point(565, 12);
            this.lblTongTienTach.Name = "lblTongTienTach";
            this.lblTongTienTach.Size = new System.Drawing.Size(185, 23);
            this.lblTongTienTach.TabIndex = 3;
            this.lblTongTienTach.Text = "Tách: 0 đ";
            this.lblTongTienTach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(230, 426);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(200, 40);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "XÁC NHẬN TÁCH";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(450, 426);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "HỦY BỎ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 
            // frmTachHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 480);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.pnlTuyChon);
            this.Controls.Add(this.grpDich);
            this.Controls.Add(this.pnlDieuKhien);
            this.Controls.Add(this.grpNguon);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTachHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tách Hóa Đơn";
            this.Load += new System.EventHandler(this.frmTachHoaDon_Load);
            this.grpNguon.ResumeLayout(false);
            this.grpDich.ResumeLayout(false);
            this.pnlDieuKhien.ResumeLayout(false);
            this.pnlTuyChon.ResumeLayout(false);
            this.pnlTuyChon.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpNguon;
        private System.Windows.Forms.ListView lvwNguon;
        private System.Windows.Forms.ColumnHeader colNguonTen;
        private System.Windows.Forms.ColumnHeader colNguonSize;
        private System.Windows.Forms.ColumnHeader colNguonSL;
        private System.Windows.Forms.ColumnHeader colNguonGia;
        private System.Windows.Forms.ColumnHeader colNguonThanhTien;
        private System.Windows.Forms.GroupBox grpDich;
        private System.Windows.Forms.ListView lvwDich;
        private System.Windows.Forms.ColumnHeader colDichTen;
        private System.Windows.Forms.ColumnHeader colDichSize;
        private System.Windows.Forms.ColumnHeader colDichSL;
        private System.Windows.Forms.ColumnHeader colDichGia;
        private System.Windows.Forms.ColumnHeader colDichThanhTien;
        private System.Windows.Forms.Panel pnlDieuKhien;
        private System.Windows.Forms.Button btnChuyen1;
        private System.Windows.Forms.Button btnChuyenHet;
        private System.Windows.Forms.Button btnTraLai1;
        private System.Windows.Forms.Button btnTraLaiHet;
        private System.Windows.Forms.Panel pnlTuyChon;
        private System.Windows.Forms.RadioButton rdoGiuBan;
        private System.Windows.Forms.RadioButton rdoSangBanMoi;
        private System.Windows.Forms.ComboBox cboBanTrong;
        private System.Windows.Forms.Label lblTongTienTach;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}
