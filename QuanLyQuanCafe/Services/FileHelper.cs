using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLyQuanCafe.Services
{
    public static class FileHelper
    {
        private static string? _dataDirectory;

        public static string DataDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_dataDirectory))
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string candidate = Path.Combine(baseDir, "Data");

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

        public static string LogFilePath => Path.Combine(DataDirectory, "log.txt");

        public static string GetFullPath(string fileName)
        {
            if (Path.IsPathRooted(fileName))
                return fileName;
            return Path.Combine(DataDirectory, fileName);
        }

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
            }
        }

        public static List<T> DocTapTin<T>(string fileName, Func<string, T?> chuyenDoiDong)
        {
            var danhSach = new List<T>();
            string fullPath = GetFullPath(fileName);

            try
            {
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
                    if (line.TrimStart().StartsWith("#")) continue;

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

        public static bool XuatCsv<T>(string duongDanFile, string tieuDeCot, IEnumerable<T> danhSach, Func<T, string> dinhDangDong)
        {
            try
            {
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

                foreach (string file in Directory.GetFiles(DataDirectory))
                {
                    string fileName = Path.GetFileName(file);
                    string dest = Path.Combine(thuMucDich, fileName);
                    File.Copy(file, dest, overwrite: true);
                }

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
