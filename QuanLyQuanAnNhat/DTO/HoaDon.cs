using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public HoaDon(int maHD, int maNV, int maBan, int tongTien, DateTime thoiGian, bool tinhTrang)
        {
            MaHD = maHD;
            MaNV = maNV;
            MaBan = maBan;
            TongTien = tongTien;
            ThoiGian = thoiGian;
            TinhTrang = tinhTrang;
        }
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public int MaBan { get; set; }
        public int TongTien { get; set; }
        public DateTime ThoiGian { get; set; }
        public bool TinhTrang { get; set; }

    }
}
