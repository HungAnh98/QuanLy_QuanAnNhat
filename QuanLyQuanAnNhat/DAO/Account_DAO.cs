﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class Account_DAO : Dataprovider
    {
        public DataTable GetTableAccount()
        {
            return GetDataSet("Account").Tables[0];
        }

      

    }
}
