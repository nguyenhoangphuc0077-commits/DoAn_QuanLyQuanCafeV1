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
            this.pnlSoDo = new System.Windows.Forms.Panel();
            this.cboKhuVuc = new System.Windows.Forms.ComboBox();
            this.pnlSoDo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSoDo
            // 
            this.pnlSoDo.Controls.Add(this.cboKhuVuc);
            this.pnlSoDo.Location = new System.Drawing.Point(0, 0);
            this.pnlSoDo.Name = "pnlSoDo";
            this.pnlSoDo.Size = new System.Drawing.Size(200, 100);
            this.pnlSoDo.TabIndex = 0;
            // 
            // cboKhuVuc
            // 
            this.cboKhuVuc.FormattingEnabled = true;
            this.cboKhuVuc.Location = new System.Drawing.Point(0, 0);
            this.cboKhuVuc.Name = "cboKhuVuc";
            this.cboKhuVuc.Size = new System.Drawing.Size(121, 21);
            this.cboKhuVuc.TabIndex = 0;
            // 
            // frmSoDoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlSoDo);
            this.Name = "frmSoDoBan";
            this.Text = "frmSoDoBan";
            this.Load += new System.EventHandler(this.frmSoDoBan_Load);
            this.pnlSoDo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSoDo;
        private System.Windows.Forms.ComboBox cboKhuVuc;
    }
}