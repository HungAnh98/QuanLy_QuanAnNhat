using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ban
    {
        int maBan;
        int soGhe;
        int tang;
        bool tinhTrang;

        public Ban(int maBan, int soGhe, int tang, bool tinhTrang)
        {
            MaBan = maBan;
            SoGhe = soGhe;
            Tang = tang;
            TinhTrang = tinhTrang;
        }
        public int MaBan { get => MaBan; set => MaBan = value; }
        public int SoGhe { get => soGhe; set => soGhe = value; }
        public int Tang { get => Tang; set => Tang = value; }
        public bool TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    }
}
