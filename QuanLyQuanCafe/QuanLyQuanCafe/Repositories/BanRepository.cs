using QuanLyQuanCafe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyQuanCafe.Repositories
{
    public class BanRepository
    {
        private readonly string _filePath;

        public BanRepository()
        {
            // Đường dẫn tới thư mục Data
            string dataDir = Path.Combine(Application.StartupPath, "Data");
            _filePath = Path.Combine(dataDir, "ban.txt");
        }

        public List<Ban> LoadAll()
        {
            var list = new List<Ban>();
            if (!File.Exists(_filePath)) return list;

            try
            {
                using (var reader = new StreamReader(_filePath, Encoding.UTF8))
                {
                    string line;
                    bool isFirstLine = true;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        if (isFirstLine && line.StartsWith("Ma;Ten"))
                        {
                            isFirstLine = false;
                            continue;
                        }
                        isFirstLine = false;

                        try { list.Add(Ban.FromCsv(line)); }
                        catch { /* Bỏ qua dòng lỗi */ }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file ban.txt: " + ex.Message);
            }
            return list;
        }

        public void SaveAll(List<Ban> dsBan)
        {
            try
            {
                using (var writer = new StreamWriter(_filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("Ma;Ten;KhuVuc;TrangThai");
                    foreach (var b in dsBan) writer.WriteLine(b.ToCsv());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file ban.txt: " + ex.Message);
            }
        }

        // Hàm cập nhật trạng thái bàn (dùng cho Chuyển/Gộp bàn)
        public void CapNhatTrangThai(string maBan, string trangThaiMoi)
        {
            var dsBan = LoadAll();
            foreach (var b in dsBan)
            {
                if (b.Ma == maBan)
                {
                    b.TrangThai = trangThaiMoi;
                    break;
                }
            }
            SaveAll(dsBan);
        }
    }
}
