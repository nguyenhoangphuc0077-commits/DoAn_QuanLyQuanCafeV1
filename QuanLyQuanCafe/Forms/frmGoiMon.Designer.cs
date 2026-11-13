namespace QuanLyQuanCafe.Forms
{
    partial class frmGoiMon
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

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblMon = new System.Windows.Forms.Label();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.picMon = new System.Windows.Forms.PictureBox();
            this.grpSize = new System.Windows.Forms.GroupBox();
            this.rdoSizeS = new System.Windows.Forms.RadioButton();
            this.rdoSizeM = new System.Windows.Forms.RadioButton();
            this.rdoSizeL = new System.Windows.Forms.RadioButton();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaText = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblThanhTienText = new System.Windows.Forms.Label();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).BeginInit();
            this.grpSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(584, 45);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "GỌI MÓN VÀO BÀN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblDanhMuc);
            this.grpThongTin.Controls.Add(this.cboDanhMuc);
            this.grpThongTin.Controls.Add(this.lblMon);
            this.grpThongTin.Controls.Add(this.cboMon);
            this.grpThongTin.Controls.Add(this.picMon);
            this.grpThongTin.Controls.Add(this.grpSize);
            this.grpThongTin.Controls.Add(this.lblSoLuong);
            this.grpThongTin.Controls.Add(this.nudSoLuong);
            this.grpThongTin.Controls.Add(this.lblDonGiaText);
            this.grpThongTin.Controls.Add(this.lblDonGia);
            this.grpThongTin.Controls.Add(this.lblThanhTienText);
            this.grpThongTin.Controls.Add(this.lblThanhTien);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(16, 55);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(550, 310);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin món gọi";
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(20, 30);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(75, 19);
            this.lblDanhMuc.TabIndex = 0;
            this.lblDanhMuc.Text = "Danh mục:";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(115, 27);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(250, 25);
            this.cboDanhMuc.TabIndex = 1;
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);
            // 
            // lblMon
            // 
            this.lblMon.AutoSize = true;
            this.lblMon.Location = new System.Drawing.Point(20, 70);
            this.lblMon.Name = "lblMon";
            this.lblMon.Size = new System.Drawing.Size(75, 19);
            this.lblMon.TabIndex = 2;
            this.lblMon.Text = "Chọn món:";
            // 
            // cboMon
            // 
            this.cboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(115, 67);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(250, 25);
            this.cboMon.TabIndex = 3;
            this.cboMon.SelectedIndexChanged += new System.EventHandler(this.cboMon_SelectedIndexChanged);
            // 
            // picMon
            // 
            this.picMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(235)))));
            this.picMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMon.Location = new System.Drawing.Point(385, 25);
            this.picMon.Name = "picMon";
            this.picMon.Size = new System.Drawing.Size(145, 145);
            this.picMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMon.TabIndex = 4;
            this.picMon.TabStop = false;
            // 
            // grpSize
            // 
            this.grpSize.Controls.Add(this.rdoSizeS);
            this.grpSize.Controls.Add(this.rdoSizeM);
            this.grpSize.Controls.Add(this.rdoSizeL);
            this.grpSize.Location = new System.Drawing.Point(20, 110);
            this.grpSize.Name = "grpSize";
            this.grpSize.Size = new System.Drawing.Size(345, 65);
            this.grpSize.TabIndex = 5;
            this.grpSize.TabStop = false;
            this.grpSize.Text = "Chọn Size";
            // 
            // rdoSizeS
            // 
            this.rdoSizeS.AutoSize = true;
            this.rdoSizeS.Location = new System.Drawing.Point(15, 27);
            this.rdoSizeS.Name = "rdoSizeS";
            this.rdoSizeS.Size = new System.Drawing.Size(63, 23);
            this.rdoSizeS.TabIndex = 0;
            this.rdoSizeS.Text = "Size S";
            this.rdoSizeS.UseVisualStyleBackColor = true;
            this.rdoSizeS.CheckedChanged += new System.EventHandler(this.rdoSize_CheckedChanged);
            // 
            // rdoSizeM
            // 
            this.rdoSizeM.AutoSize = true;
            this.rdoSizeM.Checked = true;
            this.rdoSizeM.Location = new System.Drawing.Point(125, 27);
            this.rdoSizeM.Name = "rdoSizeM";
            this.rdoSizeM.Size = new System.Drawing.Size(69, 23);
            this.rdoSizeM.TabIndex = 1;
            this.rdoSizeM.TabStop = true;
            this.rdoSizeM.Text = "Size M";
            this.rdoSizeM.UseVisualStyleBackColor = true;
            this.rdoSizeM.CheckedChanged += new System.EventHandler(this.rdoSize_CheckedChanged);
            // 
            // rdoSizeL
            // 
            this.rdoSizeL.AutoSize = true;
            this.rdoSizeL.Location = new System.Drawing.Point(240, 27);
            this.rdoSizeL.Name = "rdoSizeL";
            this.rdoSizeL.Size = new System.Drawing.Size(63, 23);
            this.rdoSizeL.TabIndex = 2;
            this.rdoSizeL.Text = "Size L";
            this.rdoSizeL.UseVisualStyleBackColor = true;
            this.rdoSizeL.CheckedChanged += new System.EventHandler(this.rdoSize_CheckedChanged);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 195);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(66, 19);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nudSoLuong.Location = new System.Drawing.Point(115, 192);
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(85, 26);
            this.nudSoLuong.TabIndex = 7;
            this.nudSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // lblDonGiaText
            // 
            this.lblDonGiaText.AutoSize = true;
            this.lblDonGiaText.Location = new System.Drawing.Point(230, 195);
            this.lblDonGiaText.Name = "lblDonGiaText";
            this.lblDonGiaText.Size = new System.Drawing.Size(60, 19);
            this.lblDonGiaText.TabIndex = 8;
            this.lblDonGiaText.Text = "Đơn giá:";
            // 
            // lblDonGia
            // 
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(64)))), ((int)(((byte)(55)))));
            this.lblDonGia.Location = new System.Drawing.Point(300, 194);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(230, 22);
            this.lblDonGia.TabIndex = 9;
            this.lblDonGia.Text = "0 VNĐ";
            // 
            // lblThanhTienText
            // 
            this.lblThanhTienText.AutoSize = true;
            this.lblThanhTienText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThanhTienText.Location = new System.Drawing.Point(20, 250);
            this.lblThanhTienText.Name = "lblThanhTienText";
            this.lblThanhTienText.Size = new System.Drawing.Size(88, 20);
            this.lblThanhTienText.TabIndex = 10;
            this.lblThanhTienText.Text = "Thành tiền:";
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblThanhTien.Location = new System.Drawing.Point(120, 245);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(300, 30);
            this.lblThanhTien.TabIndex = 11;
            this.lblThanhTien.Text = "0 VNĐ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(135, 385);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(185, 42);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "XÁC NHẬN GỌI MÓN";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(340, 385);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 42);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "HỦY BỎ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmGoiMon
            // 
            this.AcceptButton = this.btnXacNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(584, 445);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoiMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gọi món vào bàn";
            this.Load += new System.EventHandler(this.frmGoiMon_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMon)).EndInit();
            this.grpSize.ResumeLayout(false);
            this.grpSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblMon;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.PictureBox picMon;
        private System.Windows.Forms.GroupBox grpSize;
        private System.Windows.Forms.RadioButton rdoSizeS;
        private System.Windows.Forms.RadioButton rdoSizeM;
        private System.Windows.Forms.RadioButton rdoSizeL;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblDonGiaText;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblThanhTienText;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}
