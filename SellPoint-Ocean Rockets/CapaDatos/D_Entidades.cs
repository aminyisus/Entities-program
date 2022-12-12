using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class D_Entidades
    {

        Connection con = new Connection();
        SqlConnection cn;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        public string msg="";
        public int rows = 0;

        private void Open()
        {
            cn = con.Open();
        }

        private void Close()
        {
            cn = con.Close();
        }

        /// <summary>
        /// Metodo que retorna todos los registros de la tabla Entidades
        /// </summary>
        /// <returns>Retorna una variable DataTabe con todos los registros de la Tabla Entidades</returns>
        public DataTable Listar()
        {
            dt = new DataTable();

            try
            {
                Open();
                cmd = new SqlCommand("EntidadesListar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                Close();
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException sqle)
            {
                dt.Rows[0][0] = "sqlerr101";
                dt.Rows[0][1] = sqle.Message;
            }
            catch (Exception e)
            {
                dt = new DataTable();
                dt.Rows[0][0] = "err101";
                dt.Rows[0][1] = e.Message;
            }
            return dt;
        }

        /// <summary>
        /// Metodo para insertar un registro en la tabla Entidades
        /// </summary>
        /// <returns>Un 1 si la insercion fue exitosa, el mensaje de error en caso de error (duh)</returns>
        public int Insert(string desc, string direccion, string local, string typeEnt,
            string typeDoc, long numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
            string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
            string comment, string status, int noElim)
        {

            try
            {
                Open();
                cmd = new SqlCommand("EntidadesInsertar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("@DESCRIPCION", desc);
                cmd.Parameters.AddWithValue("@DIRECCION", direccion);
                cmd.Parameters.AddWithValue("@LOCALIDAD", local);
                cmd.Parameters.AddWithValue("@TIPOENTIDAD", typeEnt);
                cmd.Parameters.AddWithValue("@TIPODOCUMENTO", typeDoc);
                cmd.Parameters.AddWithValue("@NUMERODOCUMENTO", numDoc);
                cmd.Parameters.AddWithValue("@TELEFONOS", tel);
                cmd.Parameters.AddWithValue("@URLPAGINAWEB", urlPag);
                cmd.Parameters.AddWithValue("@URLFACEBOOK", urlFB);
                cmd.Parameters.AddWithValue("@URLINSTAGRAM", urlIG);
                cmd.Parameters.AddWithValue("@URLTWITTER", urlTW);
                cmd.Parameters.AddWithValue("@URLTIKTOK", urlTK);
                cmd.Parameters.AddWithValue("@IDGRUPOENTIDAD", idGrEnt);
                cmd.Parameters.AddWithValue("@IDTIPOENTIDAD", idTypeEnt);
                cmd.Parameters.AddWithValue("@LIMITECREDITO", limCr);
                cmd.Parameters.AddWithValue("@USERNAMEENTIDAD", user);
                cmd.Parameters.AddWithValue("@PASSWORENTIDAD", pass);
                cmd.Parameters.AddWithValue("@ROLUSERENTIDAD", rol);
                cmd.Parameters.AddWithValue("@COMENTARIO", comment);
                cmd.Parameters.AddWithValue("@STATUS", status);
                cmd.Parameters.AddWithValue("@NOELIMINABLE", noElim);
                //Fin de los parametros ;-;

                cmd.ExecuteNonQuery();
                Close();

                return 1;
            }
            catch (SqlException sqle)
            {
                msg = sqle.Message;
                return 3;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 4;
            }
        }

        /// <summary>
        /// Actualiza un registro de la tabla Entidades
        /// </summary>
        /// <returns>El numero de filas modificadas, o un mensaje en caso de error</returns>
        public int Update(int id, string desc, string direccion, string local, string typeEnt,
            string typeDoc, long numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
            string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
            string comment, string status, int noElim)
        {

            try
            {
                Open();
                cmd = new SqlCommand("EntidadesActualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("@IDENTIDAD", id);
                cmd.Parameters.AddWithValue("@DESCRIPCION", desc);
                cmd.Parameters.AddWithValue("@DIRECCION", direccion);
                cmd.Parameters.AddWithValue("@LOCALIDAD", local);
                cmd.Parameters.AddWithValue("@TIPOENTIDAD", typeEnt);
                cmd.Parameters.AddWithValue("@TIPODOCUMENTO", typeDoc);
                cmd.Parameters.AddWithValue("@NUMERODOCUMENTO", numDoc);
                cmd.Parameters.AddWithValue("@TELEFONOS", tel);
                cmd.Parameters.AddWithValue("@URLPAGINAWEB", urlPag);
                cmd.Parameters.AddWithValue("@URLFACEBOOK", urlFB);
                cmd.Parameters.AddWithValue("@URLINSTAGRAM", urlIG);
                cmd.Parameters.AddWithValue("@URLTWITTER", urlTW);
                cmd.Parameters.AddWithValue("@URLTIKTOK", urlTK);
                cmd.Parameters.AddWithValue("@IDGRUPOENTIDAD", idGrEnt);
                cmd.Parameters.AddWithValue("@IDTIPOENTIDAD", idTypeEnt);
                cmd.Parameters.AddWithValue("@LIMITECREDITO", limCr);
                cmd.Parameters.AddWithValue("@USERNAMEENTIDAD", user);
                cmd.Parameters.AddWithValue("@PASSWORENTIDAD", pass);
                cmd.Parameters.AddWithValue("@ROLUSERENTIDAD", rol);
                cmd.Parameters.AddWithValue("@COMENTARIO", comment);
                cmd.Parameters.AddWithValue("@STATUS", status);
                cmd.Parameters.AddWithValue("@NOELIMINABLE", noElim);
                //Fin de los parametros ;-;

                rows = cmd.ExecuteNonQuery();
                Close();

                return 1;
            }
            catch (SqlException sqle)
            {
                msg = sqle.Message;
                return 3;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 4;
            }
        }

        /// <summary>
        /// Elimina un registro de la tabla Entidades
        /// </summary>
        /// <returns>El numero de registros eliminados o un mensaje en caso de error</returns>
        public int Delete(int id)
        {
            int rows;

            try
            {
                Open();
                cmd = new SqlCommand("EntidadesEliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("@IDENTIDAD", id);
                //Fin de los parametros ;-;

                rows = cmd.ExecuteNonQuery();
                Close();

                return 1;
            }
            catch (SqlException sqle)
            {
                msg = sqle.Message;
                return 3;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return 4;
            }
        }

        /// <summary>
        /// Metodo para buscar registros en la tabla Entidades
        /// </summary>
        /// <returns>Un DataTable con los registros que coinciden con los parametros de busqueda</returns>
        public DataTable Buscar(string parametro)
        {
            dt = new DataTable();

            try
            {
                Open();
                cmd = new SqlCommand("EntidadesBuscar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                cmd.Parameters.AddWithValue("@PARAMETRO", parametro);
                //Fin de los parametros ;-;

                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                Close();
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException sqle)
            {
                dt.Rows[0][0] = "sqlerr101";
                dt.Rows[0][1] = sqle.Message;
            }
            catch (Exception e)
            {
                dt = new DataTable();
                dt.Rows[0][0] = "err101";
                dt.Rows[0][1] = e.Message;
            }
            return dt;
        }
    }
}
