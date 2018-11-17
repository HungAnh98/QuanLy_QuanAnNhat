using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        public Account(string userName, string password, string idNhanVien)
        {
            UserName = userName;
            Password = password;
            IdNhanVien = idNhanVien;
        }
        public Account()
        { }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdNhanVien { get; set; }
    }
}
