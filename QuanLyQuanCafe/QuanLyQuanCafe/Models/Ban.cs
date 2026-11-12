using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.Models
{
    public class Ban
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string KhuVuc { get; set; }
        public string TrangThai { get; set; }

        public Ban() { }

        public Ban(string ma, string ten, string khuVuc, string trangThai)
        {
            Ma = ma; Ten = ten; KhuVuc = khuVuc; TrangThai = trangThai;
        }

        public static Ban FromCsv(string line)
        {
            var parts = line.Split(';');
            if (parts.Length < 4) throw new FormatException("Dòng không hợp lệ");
            return new Ban(parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), parts[3].Trim());
        }

        public string ToCsv()
        {
            return $"{Ma};{Ten};{KhuVuc};{TrangThai}";
        }
    }
}
