using System;
using System.Windows.Forms;
using QuanLyQuanCafe.Forms;

namespace QuanLyQuanCafe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}
