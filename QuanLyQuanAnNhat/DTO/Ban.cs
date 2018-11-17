using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ban
    {
        public Ban(int maBan, int soGhe, int tang, bool tinhTrang)
        {
            MaBan = maBan;
            SoGhe = soGhe;
            Tang = tang;
            TinhTrang = tinhTrang;
        }
        
        public int MaBan { get; set; }
        public int SoGhe { get; set; }
        public int Tang { get; set; }
        public bool TinhTrang { get; set; }

    }
}
