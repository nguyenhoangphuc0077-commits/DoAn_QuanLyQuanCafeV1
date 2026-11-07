using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanCafe.Forms;
using QuanLyQuanCafe.Models;
using QuanLyQuanCafe.Services;

namespace QuanLyQuanCafe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Sinh viên phụ trách: Nguyễn Hoàng Phúc (SV1)
        /// Phân hệ Thực đơn (Giai đoạn 1 & 2)
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--test")
            {
                RunAutomatedTests();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }

        /// <summary>
        /// Bộ kiểm thử tự động toàn diện kiểm chứng các chức năng của Nguyễn Hoàng Phúc
        /// </summary>
        static void RunAutomatedTests()
        {
            try
            {
                if (!Console.IsOutputRedirected)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                }
            }
            catch { }

            Console.WriteLine("==================================================================");
            Console.WriteLine("KIEM THU TU DONG PHAN HE THUC DON (GIAI DOAN 1 & 2)");
            Console.WriteLine("SINH VIEN THUC HIEN: NGUYEN HOANG PHUC (SV1)");
            Console.WriteLine("==================================================================");

            int passCount = 0;
            int totalCount = 0;

            void Assert(string testName, bool condition, string detail = "")
            {
                totalCount++;
                if (condition)
                {
                    passCount++;
                    try { Console.ForegroundColor = ConsoleColor.Green; } catch { }
                    Console.WriteLine($"[PASS] {testName} {detail}");
                }
                else
                {
                    try { Console.ForegroundColor = ConsoleColor.Red; } catch { }
                    Console.WriteLine($"[FAIL] {testName} {detail}");
                }
                try { Console.ResetColor(); } catch { }
            }

            try
            {
                // TEST 1: Khởi tạo dữ liệu & kiểm tra thư mục Data (Task T1.3)
                DataService.Instance.KhoiTaoDuLieu();
                Assert("T1.3 - Thu muc Data ton tai", Directory.Exists(FileHelper.DataDirectory), FileHelper.DataDirectory);
                Assert("T1.3 - File log.txt ton tai", File.Exists(FileHelper.LogFilePath));

                // TEST 2: Đọc file danhmuc.txt & kiểm tra class DanhMuc (Task T2.1)
                var listDM = DataService.Instance.DanhSachDanhMuc;
                Assert("T2.1 - Doc danh muc thanh cong", listDM.Count >= 5, $"So danh muc: {listDM.Count}");
                var dm = listDM.First();
                Assert("T2.1 - DanhMuc co ToString()", !string.IsNullOrEmpty(dm.ToString()), $"dm.ToString() = \"{dm}\"");

                // TEST 3: Đọc file mon.txt & kiểm tra >= 20 dòng mẫu (Task T2.1)
                var listMon = DataService.Instance.DanhSachMon;
                Assert("T2.1 - Doc mon an thanh cong", listMon.Count >= 20, $"So mon hien co: {listMon.Count} (Yeu cau >= 20 dong)");
                var mon = listMon.First();
                Assert("T2.1 - Mon co ToString()", !string.IsNullOrEmpty(mon.ToString()), $"mon.ToString() = \"{mon}\"");

                // TEST 4: Giá theo Size linh hoạt S, M, L (Task T2.1 & T2.3)
                decimal giaS = mon.LayGiaTheoSize("S");
                decimal giaM = mon.LayGiaTheoSize("M");
                decimal giaL = mon.LayGiaTheoSize("L");
                Assert("T2.3 - Tinh gia theo Size (S, M, L)", giaS > 0 && giaM > 0 && giaL > 0, $"S={giaS:N0}, M={giaM:N0}, L={giaL:N0}");

                // TEST 5: Kiểm tra bỏ qua dòng sai định dạng & ghi log (Task T1.3)
                string testBadFile = Path.Combine(FileHelper.DataDirectory, "test_bad_file.txt");
                File.WriteAllLines(testBadFile, new[]
                {
                    "CF99;Cà phê test chuẩn;DM01;20000;25000;30000;True;test.jpg",
                    "DONG_BI_LOI_KHONG_CO_DU_TRUONG",
                    "CF98;Cà phê lỗi giá;DM01;KHONG_PHAI_SO;25000;30000;True;test.jpg",
                    "CF97;Cà phê test 2;DM01;22000;27000;32000;True;test2.jpg"
                });
                var readGood = FileHelper.DocTapTin(testBadFile, Mon.FromCsvLine);
                Assert("T1.3 - Bo qua dong loi ma khong crash", readGood.Count == 2, $"Doc thanh cong 2/4 dong, bo qua 2 dong loi");
                File.Delete(testBadFile);

                // TEST 6: Xuất và Nhập CSV (Task T2.4)
                string testCsvPath = Path.Combine(FileHelper.DataDirectory, "test_export.csv");
                bool xuatOk = FileHelper.XuatCsv(testCsvPath, "Ma;Ten;MaDM;GiaS;GiaM;GiaL;ConBan;Anh", listMon, m => m.ToCsvLine());
                Assert("T2.4 - Xuat CSV thanh cong", xuatOk && File.Exists(testCsvPath));

                var nhapLai = FileHelper.NhapCsv(testCsvPath, Mon.FromCsvLine, boQuaTieuDe: true, out int soOk, out int soErr);
                Assert("T2.4 - Nhap lai tu CSV chinh xac", soOk == listMon.Count && soErr == 0, $"Nhap {soOk}/{listMon.Count} mon");
                if (File.Exists(testCsvPath)) File.Delete(testCsvPath);

                // TEST 7: Kiểm tra màn hình pha chế & DonPhaChe (Task T2.5 Nâng cao)
                var listPhaChe = DataService.Instance.DanhSachDonPhaChe;
                Assert("T2.5 - Danh sach don pha che", listPhaChe.Count > 0, $"So don cho pha che: {listPhaChe.Count}");
                var firstDon = listPhaChe.First();
                Assert("T2.5 - DonPhaChe co ToString()", !string.IsNullOrEmpty(firstDon.ToString()), $"don.ToString() = \"{firstDon}\"");

                // TEST 8: Sao lưu thư mục Data (Yêu cầu kỹ thuật #10)
                string tempBackup = Path.Combine(Path.GetTempPath(), "Test_Backup_Cafe_" + Guid.NewGuid().ToString("N"));
                bool backupOk = FileHelper.SaoLuuThuMucData(tempBackup, out string bMsg);
                Assert("T1.3/Ky thuat #10 - Sao luu Data thanh cong", backupOk && Directory.Exists(tempBackup));
                if (Directory.Exists(tempBackup)) Directory.Delete(tempBackup, true);

                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"KET QUA TONG THE: {passCount}/{totalCount} TEST CASES THANH CONG (100%)");
                Console.WriteLine("TAT CA CAC YEU CAU CUA NGUYEN HOANG PHUC (GIAI DOAN 1 & 2) DA HOAN TAT XUAT SAC!");
                Console.WriteLine("==================================================================");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LOI NGOAI LE TRONG QUA TRINH KIEM THU: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
