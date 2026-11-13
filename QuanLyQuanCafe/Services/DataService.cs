using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuanLyQuanCafe.Models;

namespace QuanLyQuanCafe.Services
{
    public class DataService
    {
        private static DataService? _instance;
        public static DataService Instance => _instance ??= new DataService();

        public const string FILE_DANHMUC = "danhmuc.txt";
        public const string FILE_MON = "mon.txt";
        public const string FILE_DONPHACHE = "donhang_phache.txt";
        public const string FILE_USERS = "users.txt";
        public const string FILE_BAN = "ban.txt";

        public List<DanhMuc> DanhSachDanhMuc { get; set; } = new List<DanhMuc>();
        public List<Mon> DanhSachMon { get; set; } = new List<Mon>();
        public List<DonPhaChe> DanhSachDonPhaChe { get; set; } = new List<DonPhaChe>();

        private DataService()
        {
            KhoiTaoDuLieu();
        }

        public void KhoiTaoDuLieu()
        {
            NapDanhSachDanhMuc();
            NapDanhSachMon();
            NapDanhSachDonPhaChe();

            if (DanhSachDanhMuc.Count == 0 || DanhSachMon.Count == 0)
            {
                TaoDuLieuMauNeuChuaCo();
            }
        }

        public void NapDanhSachDanhMuc()
        {
            DanhSachDanhMuc = FileHelper.DocTapTin(FILE_DANHMUC, DanhMuc.FromCsvLine);
        }

        public void NapDanhSachMon()
        {
            DanhSachMon = FileHelper.DocTapTin(FILE_MON, Mon.FromCsvLine);
        }

        public void NapDanhSachDonPhaChe()
        {
            DanhSachDonPhaChe = FileHelper.DocTapTin(FILE_DONPHACHE, DonPhaChe.FromCsvLine);
        }

        public bool LuuDanhSachDanhMuc()
        {
            return FileHelper.GhiTapTin(FILE_DANHMUC, DanhSachDanhMuc, dm => dm.ToCsvLine());
        }

        public bool LuuDanhSachMon()
        {
            return FileHelper.GhiTapTin(FILE_MON, DanhSachMon, m => m.ToCsvLine());
        }

        public bool LuuDanhSachDonPhaChe()
        {
            return FileHelper.GhiTapTin(FILE_DONPHACHE, DanhSachDonPhaChe, d => d.ToCsvLine());
        }

        public string LayTenDanhMuc(string maDM)
        {
            var dm = DanhSachDanhMuc.FirstOrDefault(d => string.Equals(d.MaDM, maDM, StringComparison.OrdinalIgnoreCase));
            return dm != null ? dm.TenDM : "Chưa phân loại";
        }

        public bool DanhMucDangCoMon(string maDM)
        {
            return DanhSachMon.Any(m => string.Equals(m.MaDanhMuc, maDM, StringComparison.OrdinalIgnoreCase));
        }

        public void TaoDuLieuMauNeuChuaCo()
        {
            if (DanhSachDanhMuc.Count == 0)
            {
                DanhSachDanhMuc = new List<DanhMuc>
                {
                    new DanhMuc("DM01", "Cà Phê Truyền Thống"),
                    new DanhMuc("DM02", "Cà Phê Máy & Ý"),
                    new DanhMuc("DM03", "Trà & Trà Trái Cây"),
                    new DanhMuc("DM04", "Đá Xay & Freeze"),
                    new DanhMuc("DM05", "Sinh Tố & Nước Ép"),
                    new DanhMuc("DM06", "Bánh Ngọt & Tráng Miệng")
                };
                LuuDanhSachDanhMuc();
            }

            if (DanhSachMon.Count < 20)
            {
                DanhSachMon = new List<Mon>
                {
                    new Mon("CF01", "Cà phê đen đá", "DM01", 25000, 29000, 35000, true, "cf_den_da.jpg"),
                    new Mon("CF02", "Cà phê sữa đá", "DM01", 29000, 35000, 39000, true, "cf_sua_da.jpg"),
                    new Mon("CF03", "Bạc xỉu ba tầng", "DM01", 32000, 38000, 42000, true, "bac_xiu.jpg"),
                    new Mon("CF04", "Cà phê trứng", "DM01", 39000, 45000, 49000, true, "cf_trung.jpg"),
                    new Mon("CF05", "Cà phê muối", "DM01", 32000, 38000, 42000, true, "cf_muoi.jpg"),
                    new Mon("CF06", "Espresso đậm vị", "DM02", 30000, 35000, 40000, true, "espresso.jpg"),
                    new Mon("CF07", "Americano đá", "DM02", 35000, 40000, 45000, true, "americano.jpg"),
                    new Mon("CF08", "Americano nóng", "DM02", 35000, 40000, 45000, true, "americano_hot.jpg"),
                    new Mon("CF09", "Cappuccino bọt sữa", "DM02", 45000, 50000, 55000, true, "cappuccino.jpg"),
                    new Mon("CF10", "Caramel Macchiato", "DM02", 49000, 55000, 60000, true, "caramel_macchiato.jpg"),
                    new Mon("CF11", "Latte vani thơm béo", "DM02", 45000, 50000, 55000, true, "latte.jpg"),
                    new Mon("TR01", "Trà đào cam sả", "DM03", 39000, 45000, 49000, true, "tra_dao_cam_sa.jpg"),
                    new Mon("TR02", "Trà vải hoa hồng", "DM03", 39000, 45000, 49000, true, "tra_vai.jpg"),
                    new Mon("TR03", "Trà sen vàng macchiato", "DM03", 42000, 49000, 55000, true, "tra_sen_vang.jpg"),
                    new Mon("TR04", "Trà ô long sữa dừa", "DM03", 38000, 45000, 50000, true, "tra_olong_sua.jpg"),
                    new Mon("TR05", "Trà chanh", "DM03", 30000, 35000, 40000, true, "tra_chanh.jpg"),
                    new Mon("DX01", "Matcha đá xay kem tuyết", "DM04", 45000, 52000, 58000, true, "matcha_ice.jpg"),
                    new Mon("DX02", "Chocolate Cookie Freeze", "DM04", 45000, 55000, 62000, true, "choco_freeze.jpg"),
                    new Mon("ST01", "Sinh tố bơ", "DM05", 40000, 48000, 55000, true, "sinh_to_bo.jpg"),
                    new Mon("ST02", "Sinh tố xoài", "DM05", 38000, 45000, 50000, true, "sinh_to_xoai.jpg"),
                    new Mon("ST03", "Nước cam ép", "DM05", 35000, 42000, 48000, true, "nuoc_ep_cam.jpg"),
                    new Mon("ST04", "Nước ép dưa hấu", "DM05", 30000, 38000, 45000, true, "nuoc_ep_dua_hau.jpg"),
                    new Mon("BN01", "Bánh Tiramisu phô mai", "DM06", 39000, 39000, 39000, true, "tiramisu.jpg"),
                    new Mon("BN02", "Bánh Mousse chanh leo", "DM06", 38000, 38000, 38000, true, "mousse_chanh_leo.jpg"),
                    new Mon("BN03", "Bánh Croissant bơ tỏi", "DM06", 32000, 32000, 32000, false, "croissant.jpg")
                };
                LuuDanhSachMon();
            }

            if (DanhSachDonPhaChe.Count == 0)
            {
                DanhSachDonPhaChe = new List<DonPhaChe>
                {
                    new DonPhaChe("ORD001", "B01", "Bàn 1", "CF02", "Cà phê sữa đá", "M", 2, "Ít ngọt, nhiều đá"),
                    new DonPhaChe("ORD002", "B03", "Bàn 3", "TR01", "Trà đào cam sả", "L", 1, "Ít đá, để đào riêng"),
                    new DonPhaChe("ORD003", "B02", "Bàn 2", "BN01", "Bánh Tiramisu phô mai", "M", 1, "Dùng ngay"),
                    new DonPhaChe("ORD004", "B05", "Bàn 5", "DX01", "Matcha đá xay kem tuyết", "L", 2, "Nhiều whipping cream")
                };
                LuuDanhSachDonPhaChe();
            }

            string userPath = FileHelper.GetFullPath(FILE_USERS);
            if (!File.Exists(userPath))
            {
                File.WriteAllLines(userPath, new[]
                {
                    "admin;123;QuanTri;Quản Trị Viên",
                    "phuc;123;NhanVien;Nguyễn Hoàng Phúc (SV1)",
                    "trung;123;NhanVien;Trần Trí Trung (SV2)",
                    "vu;123;NhanVien;Đỗ Nguyễn Uy Vũ (SV3)"
                });
            }

            string banPath = FileHelper.GetFullPath(FILE_BAN);
            if (!File.Exists(banPath))
            {
                File.WriteAllLines(banPath, new[]
                {
                    "Ma;Ten;KhuVuc;TrangThai",
                    "B01;Bàn 1;Tầng trệt;Trống",
                    "B02;Bàn 2;Tầng trệt;Trống",
                    "B03;Bàn 3;Tầng trệt;Có khách",
                    "B04;Bàn 4;Tầng trệt;Trống",
                    "B05;Bàn 5;Tầng trệt;Có khách",
                    "B06;Bàn 6;Lầu 1;Có khách",
                    "B07;Bàn 7;Lầu 1;Trống",
                    "B08;Bàn 8;Lầu 1;Trống",
                    "B09;Bàn 9;Lầu 1;Trống",
                    "B10;Bàn 10;Lầu 1;Trống",
                    "B11;Bàn 11;Sân vườn;Trống",
                    "B12;Bàn 12;Sân vườn;Trống",
                    "B13;Bàn 13;Sân vườn;Trống",
                    "B14;Bàn 14;Sân vườn;Trống",
                    "B15;Bàn 15;Sân vườn;Trống"
                });
            }
        }
    }
}
