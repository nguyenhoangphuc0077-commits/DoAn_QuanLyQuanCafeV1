namespace QuanLyQuanCafe.Forms
{
    partial class frmSoDoBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSoDo = new System.Windows.Forms.Panel();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.lvChiTiet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsBan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miChuyenBan = new System.Windows.Forms.ToolStripMenuItem();
            this.miGopBan = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSoDo.SuspendLayout();
            this.cmsBan.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSoDo
            // 
            this.pnlSoDo.Controls.Add(this.cboKhuVuc);
            this.pnlSoDo.Location = new System.Drawing.Point(0, 0);
            this.pnlSoDo.Name = "pnlSoDo";
            this.pnlSoDo.Size = new System.Drawing.Size(307, 261);
            this.pnlSoDo.TabIndex = 0;
            
            // cboKhuVuc
            // 
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(121, 21);
            this.cboKhuVuc.TabIndex = 0;
            // 
            // lvChiTiet
            // 
            this.lvChiTiet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvChiTiet.HideSelection = false;
            this.lvChiTiet.Location = new System.Drawing.Point(313, 3);
            this.lvChiTiet.Name = "lvChiTiet";
            this.lvChiTiet.Size = new System.Drawing.Size(332, 258);
            this.lvChiTiet.TabIndex = 1;
            this.lvChiTiet.UseCompatibleStateImageBehavior = false;
            this.lvChiTiet.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 85;
            // 
            // cmsBan
            // 
            this.cmsBan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChuyenBan,
            this.miGopBan});
            this.cmsBan.Name = "cmsBan";
            this.cmsBan.Size = new System.Drawing.Size(139, 48);
            // 
            // miChuyenBan
            // 
            this.miChuyenBan.Name = "miChuyenBan";
            this.miChuyenBan.Size = new System.Drawing.Size(180, 22);
            this.miChuyenBan.Text = "Chuyển bàn";
            this.miChuyenBan.Click += new System.EventHandler(this.miChuyenBan_Click);
            // 
            // miGopBan
            // 
            this.miGopBan.Name = "miGopBan";
            this.miGopBan.Size = new System.Drawing.Size(180, 22);
            this.miGopBan.Text = "Gộp bàn";
            this.miGopBan.Click += new System.EventHandler(this.miGopBan_Click);
            // 
            // frmSoDoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvChiTiet);
            this.Controls.Add(this.pnlSoDo);
            this.Name = "frmSoDoBan";
            this.Text = "frmSoDoBan";
            this.Load += new System.EventHandler(this.frmSoDoBan_Load);
            this.pnlSoDo.ResumeLayout(false);
            this.cmsBan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSoDo;
        private System.Windows.Forms.ComboBox cboKhuVuc;
        private System.Windows.Forms.ListView lvChiTiet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip cmsBan;
        private System.Windows.Forms.ToolStripMenuItem miChuyenBan;
        private System.Windows.Forms.ToolStripMenuItem miGopBan;
    }
}