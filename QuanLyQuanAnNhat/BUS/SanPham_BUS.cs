﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace BUS
{
    public class SanPham_BUS
    {
        public DataTable GetThongTinMenu()
        {
            return new SanPham_DAO().GetTableProduct();
        }
    }
}