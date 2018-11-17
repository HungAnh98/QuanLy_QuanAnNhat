using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public SanPham(string maSP, string ten, string donVi, int giaBan)
        {
            MaSP = maSP;
            Ten = ten;
            DonVi = donVi;
            GiaBan = giaBan;
        }
        public string MaSP { get; set; }
        public string Ten { get; set; }
        public string DonVi { get; set; }
        public int GiaBan { get; set; }
    }
}
