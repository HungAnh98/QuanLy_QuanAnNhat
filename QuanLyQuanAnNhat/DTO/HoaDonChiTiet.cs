using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonChiTiet
    {
        public HoaDonChiTiet(int maHD, string maSP, int soLuong)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
        }

        public int MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }

    }
}
