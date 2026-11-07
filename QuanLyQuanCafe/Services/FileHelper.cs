using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLyQuanCafe.Services
{
    /// <summary>
    /// Class Base xử lý đọc/ghi tập tin văn bản dùng chung cho toàn bộ dự án
    /// Đảm nhiệm bởi: Nguyễn Hoàng Phúc (Task T1.3)
    /// Đáp ứng chuẩn: UTF-8, phân tách bằng dấu ';', StreamReader/StreamWriter,
    /// tự động tạo thư mục/file, try-catch toàn diện, bỏ qua dòng lỗi và ghi log.txt.
    /// </summary>
    public static class FileHelper
    {
        private static string? _dataDirectory;

        /// <summary>
        /// Đường dẫn thư mục Data của phần mềm.
        /// Tự động tìm thư mục Data ở thư mục gốc của ứng dụng hoặc project, và tự tạo nếu chưa có.
        /// </summary>
        public static string DataDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_dataDirectory))
                {
                    // Ưu tiên tìm trong AppDomain hoặc thư mục làm việc
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string candidate = Path.Combine(baseDir, "Data");

                    // Nếu đang chạy trong bin/Debug/..., kiểm tra xem có thư mục Data ở cấp project không
                    if (!Directory.Exists(candidate))
                    {
                        DirectoryInfo? parent = Directory.GetParent(baseDir);
                        for (int i = 0; i < 4 && parent != null; i++)
                        {
                            string projectData = Path.Combine(parent.FullName, "Data");
                            if (Directory.Exists(projectData))
                            {
                                candidate = projectData;
                                break;
                            }
                            parent = parent.Parent;
                        }
                    }

                    if (!Directory.Exists(candidate))
                    {
                        Directory.CreateDirectory(candidate);
                    }

                    _dataDirectory = candidate;
                }
                return _dataDirectory;
            }
            set => _dataDirectory = value;
        }

        /// <summary>
        /// Đường dẫn thư mục hình ảnh Data/Images
        /// </summary>
        public static string ImagesDirectory
        {
            get
            {
                string imgDir = Path.Combine(DataDirectory, "Images");
                if (!Directory.Exists(imgDir))
                {
                    Directory.CreateDirectory(imgDir);
                }
                return imgDir;
            }
        }

        /// <summary>
        /// Đường dẫn file log.txt
        /// </summary>
        public static string LogFilePath => Path.Combine(DataDirectory, "log.txt");

        /// <summary>
        /// Lấy đường dẫn đầy đủ của một file trong thư mục Data
        /// </summary>
        public static string GetFullPath(string fileName)
        {
            if (Path.IsPathRooted(fileName))
                return fileName;
            return Path.Combine(DataDirectory, fileName);
        }

        /// <summary>
        /// Ghi nhật ký lỗi vào file log.txt theo chuẩn thời gian [yyyy-MM-dd HH:mm:ss]
        /// </summary>
        public static void GhiLog(string thongDiep, Exception? ex = null)
        {
            try
            {
                string logPath = LogFilePath;
                string dir = Path.GetDirectoryName(logPath) ?? string.Empty;
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using var sw = new StreamWriter(logPath, append: true, encoding: Encoding.UTF8);
                string timeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sw.WriteLine($"[{timeStr}] [THÔNG BÁO/LỖI]: {thongDiep}");
                if (ex != null)
                {
                    sw.WriteLine($"\tNgoại lệ: {ex.GetType().Name} - {ex.Message}");
                    sw.WriteLine($"\tChi tiết: {ex.StackTrace}");
                }
            }
            catch
            {
                // Tuyệt đối không để việc ghi log làm crash chương trình
            }
        }

        /// <summary>
        /// Đọc danh sách đối tượng T từ file văn bản (.txt hoặc .csv)
        /// Dùng StreamReader với Encoding UTF-8.
        /// Bỏ qua dòng sai định dạng, không làm dừng chương trình và ghi lỗi vào log.txt.
        /// </summary>
        public static List<T> DocTapTin<T>(string fileName, Func<string, T?> chuyenDoiDong)
        {
            var danhSach = new List<T>();
            string fullPath = GetFullPath(fileName);

            try
            {
                // Tự tạo file nếu chưa tồn tại
                if (!File.Exists(fullPath))
                {
                    string dir = Path.GetDirectoryName(fullPath) ?? string.Empty;
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    using (File.Create(fullPath)) { }
                    return danhSach;
                }

                using var sr = new StreamReader(fullPath, Encoding.UTF8);
                string? line;
                int lineNumber = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.TrimStart().StartsWith("#")) continue; // Bỏ qua dòng comment nếu có

                    try
                    {
                        T? item = chuyenDoiDong(line);
                        if (item != null)
                        {
                            danhSach.Add(item);
                        }
                        else
                        {
                            GhiLog($"Dòng {lineNumber} trong file '{fileName}' sai định dạng (bị bỏ qua): \"{line}\"");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Dòng dữ liệu sai định dạng bị bỏ qua không làm chương trình dừng
                        GhiLog($"Lỗi xử lý dòng {lineNumber} trong file '{fileName}': \"{line}\"", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog($"Lỗi đọc file '{fileName}' từ đường dẫn '{fullPath}'", ex);
            }

            return danhSach;
        }

        /// <summary>
        /// Ghi danh sách đối tượng T vào file văn bản (.txt hoặc .csv)
        /// Dùng StreamWriter với Encoding UTF-8, các trường ngăn cách bởi ';'
        /// </summary>
        public static bool GhiTapTin<T>(string fileName, IEnumerable<T> danhSach, Func<T, string> chuyenThanhDong)
        {
            string fullPath = GetFullPath(fileName);
            try
            {
                string dir = Path.GetDirectoryName(fullPath) ?? string.Empty;
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using var sw = new StreamWriter(fullPath, append: false, encoding: Encoding.UTF8);
                foreach (var item in danhSach)
                {
                    if (item == null) continue;
                    string line = chuyenThanhDong(item);
                    sw.WriteLine(line);
                }
                return true;
            }
            catch (Exception ex)
            {
                GhiLog($"Lỗi ghi file '{fileName}' tại '{fullPath}'", ex);
                return false;
            }
        }

        /// <summary>
        /// Xuất dữ liệu ra file CSV chuẩn UTF-8 (có BOM để mở bằng Excel không lỗi font tiếng Việt)
        /// </summary>
        public static bool XuatCsv<T>(string duongDanFile, string tieuDeCot, IEnumerable<T> danhSach, Func<T, string> dinhDangDong)
        {
            try
            {
                // UTF-8 với BOM giúp Microsoft Excel hiển thị đúng tiếng Việt có dấu
                using var sw = new StreamWriter(duongDanFile, append: false, encoding: new UTF8Encoding(true));
                if (!string.IsNullOrWhiteSpace(tieuDeCot))
                {
                    sw.WriteLine(tieuDeCot);
                }

                foreach (var item in danhSach)
                {
                    if (item != null)
                    {
                        sw.WriteLine(dinhDangDong(item));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                GhiLog($"Lỗi xuất file CSV ra '{duongDanFile}'", ex);
                return false;
            }
        }

        /// <summary>
        /// Nhập dữ liệu từ file CSV, kiểm tra từng dòng, ghi log lỗi nếu có
        /// </summary>
        public static List<T> NhapCsv<T>(string duongDanFile, Func<string, T?> parser, bool boQuaTieuDe, out int soDongThanhCong, out int soDongLoi)
        {
            var danhSach = new List<T>();
            soDongThanhCong = 0;
            soDongLoi = 0;

            try
            {
                if (!File.Exists(duongDanFile))
                {
                    GhiLog($"File CSV không tồn tại: {duongDanFile}");
                    return danhSach;
                }

                using var sr = new StreamReader(duongDanFile, Encoding.UTF8);
                string? line;
                int lineNumber = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;
                    if (lineNumber == 1 && boQuaTieuDe) continue;
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    try
                    {
                        T? item = parser(line);
                        if (item != null)
                        {
                            danhSach.Add(item);
                            soDongThanhCong++;
                        }
                        else
                        {
                            soDongLoi++;
                            GhiLog($"File CSV '{duongDanFile}' dòng {lineNumber} không hợp lệ: {line}");
                        }
                    }
                    catch (Exception ex)
                    {
                        soDongLoi++;
                        GhiLog($"Lỗi parse CSV dòng {lineNumber}: {line}", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                GhiLog($"Lỗi khi đọc file CSV '{duongDanFile}'", ex);
            }

            return danhSach;
        }

        /// <summary>
        /// Sao lưu toàn bộ thư mục Data sang thư mục đích
        /// </summary>
        public static bool SaoLuuThuMucData(string thuMucDich, out string thongBao)
        {
            try
            {
                if (!Directory.Exists(DataDirectory))
                {
                    thongBao = "Thư mục Data nguồn không tồn tại!";
                    return false;
                }

                if (!Directory.Exists(thuMucDich))
                {
                    Directory.CreateDirectory(thuMucDich);
                }

                // Copy toàn bộ files
                foreach (string file in Directory.GetFiles(DataDirectory))
                {
                    string fileName = Path.GetFileName(file);
                    string dest = Path.Combine(thuMucDich, fileName);
                    File.Copy(file, dest, overwrite: true);
                }

                // Copy thư mục con (Images, ...)
                foreach (string dir in Directory.GetDirectories(DataDirectory))
                {
                    string dirName = Path.GetFileName(dir);
                    string destSubDir = Path.Combine(thuMucDich, dirName);
                    if (!Directory.Exists(destSubDir))
                    {
                        Directory.CreateDirectory(destSubDir);
                    }
                    foreach (string subFile in Directory.GetFiles(dir))
                    {
                        string subFileName = Path.GetFileName(subFile);
                        File.Copy(subFile, Path.Combine(destSubDir, subFileName), overwrite: true);
                    }
                }

                thongBao = $"Sao lưu thành công vào: {thuMucDich}";
                return true;
            }
            catch (Exception ex)
            {
                thongBao = $"Lỗi sao lưu: {ex.Message}";
                GhiLog("Lỗi khi thực hiện sao lưu thư mục Data", ex);
                return false;
            }
        }
    }
}
