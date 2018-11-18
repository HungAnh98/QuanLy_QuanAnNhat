using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ban
    {
        public Ban(int maBan, bool tinhTrang)
        {
            MaBan = maBan;
            TinhTrang = tinhTrang;
        }
        
        public int MaBan { get; set; }
        public bool TinhTrang { get; set; }

    }
}
