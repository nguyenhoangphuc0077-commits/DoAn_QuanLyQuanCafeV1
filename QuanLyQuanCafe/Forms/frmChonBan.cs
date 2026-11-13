using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyQuanCafe.Forms
{
    public partial class frmChonBan : Form
    {
        public Ban? BanDuocChon { get; private set; }

        public frmChonBan(List<Ban> dsBan, string tieuDe)
        {
            InitializeComponent();
            this.Text = tieuDe;

            cboDanhSachBan.DataSource = dsBan;
            cboDanhSachBan.DisplayMember = "Ten";
        }

        public frmChonBan()
        {
            InitializeComponent();
        }

        private void btnChon_Click(object? sender, EventArgs e)
        {
            if (cboDanhSachBan.SelectedItem is Ban ban)
            {
                BanDuocChon = ban;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
