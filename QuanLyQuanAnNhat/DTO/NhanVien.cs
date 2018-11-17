using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string Ten { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string ChucVu { get; set; }

        public int Luong { get; set; }
        public int Sdt { get; set; }

        public string DiaChi { get; set; }
        public NhanVien(int maNV, string ten, string gioiTinh, DateTime ngaySinh, string chucVu, int luong, int sdt, string diaChi)
        {
            this.MaNV = maNV;
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            this.ChucVu = chucVu;
            this.Luong = luong;
            this.Sdt = sdt;
            this.DiaChi = diaChi;
        }
    }
}
