using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaDatos.Properties;

namespace CapaDatos
{
    internal class Connection
    {
        SqlConnection cn = new SqlConnection(Settings.Default.StringConnectionSQLServer);

        public SqlConnection Open()
        {
            cn.Open();
            return cn;
        }

        public SqlConnection Close()
        {
            cn.Close();
            return cn;
        }
    }
}
