using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Login
    {
        Connection con = new Connection();
        SqlConnection cn;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        public string errMsg;

        private void Open()
        {
            cn = con.Open();
        }

        private void Close()
        {
            cn = con.Close();
        }

        /// <summary>
        /// Metodo del Login
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns>Retorna un codigo que indice el acceso al sistema o un codigo de datos errones, retorna un mensaje en caso de error</returns>
        /// 

        public DataTable MostrarDatos(string idUserNameEntidad)
        {
            Open();
            cmd = new SqlCommand("MostrarDatos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserNameEntidad", idUserNameEntidad);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            Close();
            dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public int Log(string user, string pass)
        {
            try
            {
                Open();
                cmd = new SqlCommand("EntidadesLogin", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                Close();
                dt = new DataTable();
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                    return 1;
                else
                    return 0;
            }
            catch (SqlException sqle)
            {
                errMsg = sqle.Message;
                return 3;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return 4;
            }
        }
    }
}
