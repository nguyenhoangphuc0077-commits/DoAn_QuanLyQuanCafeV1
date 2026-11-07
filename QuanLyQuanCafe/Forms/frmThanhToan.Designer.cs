namespace QuanLyQuanCafe.Forms
{
    partial class frmThanhToan
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
            this.lblSoHD = new System.Windows.Forms.Label();
            this.lblMaBan = new System.Windows.Forms.Label();
            this.lvwChiTiet = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTienThoi = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHD.Location = new System.Drawing.Point(25, 25);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(95, 18);
            this.lblSoHD.TabIndex = 0;
            this.lblSoHD.Text = "Số HĐ: HĐ01";

            this.lblMaBan.AutoSize = true;
            this.lblMaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBan.Location = new System.Drawing.Point(220, 25);
            this.lblMaBan.Name = "lblMaBan";
            this.lblMaBan.Size = new System.Drawing.Size(79, 18);
            this.lblMaBan.TabIndex = 1;
            this.lblMaBan.Text = "Bàn: B01";

            this.lvwChiTiet.FullRowSelect = true;
            this.lvwChiTiet.GridLines = true;
            this.lvwChiTiet.HideSelection = false;
            this.lvwChiTiet.Location = new System.Drawing.Point(28, 65);
            this.lvwChiTiet.Name = "lvwChiTiet";
            this.lvwChiTiet.Size = new System.Drawing.Size(460, 220);
            this.lvwChiTiet.TabIndex = 2;
            this.lvwChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvwChiTiet.View = System.Windows.Forms.View.Details;

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Giảm giá (%):";

            this.txtGiamGia.Location = new System.Drawing.Point(120, 302);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(100, 20);
            this.txtGiamGia.TabIndex = 4;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tổng tiền:";

            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(120, 343);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(67, 20);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "0 VNĐ";

            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tiền khách đưa:";

            this.txtTienKhachDua.Location = new System.Drawing.Point(120, 382);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(140, 20);
            this.txtTienKhachDua.TabIndex = 8;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);

            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tiền thối lại:";

            this.lblTienThoi.AutoSize = true;
            this.lblTienThoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThoi.ForeColor = System.Drawing.Color.Green;
            this.lblTienThoi.Location = new System.Drawing.Point(120, 423);
            this.lblTienThoi.Name = "lblTienThoi";
            this.lblTienThoi.Size = new System.Drawing.Size(46, 16);
            this.lblTienThoi.TabIndex = 10;
            this.lblTienThoi.Text = "0 VNĐ";

            this.btnThanhToan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(270, 465);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(110, 40);
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            this.btnHuy.Location = new System.Drawing.Point(390, 465);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 40);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 525);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lblTienThoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTienKhachDua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwChiTiet);
            this.Controls.Add(this.lblMaBan);
            this.Controls.Add(this.lblSoHD);
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.Label lblMaBan;
        private System.Windows.Forms.ListView lvwChiTiet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTienThoi;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHuy;
    }
}