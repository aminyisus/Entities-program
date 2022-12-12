using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Login
    {
        static D_Login lg = new D_Login();
        public string msg;
        public string err;

        public int Login(string user, string pass)
        {
            int acc = lg.Log(user, pass);

            switch (acc)
            { 
                case 3:
                    err = "Error al conectarse a la Base de Datos";
                    msg = lg.errMsg;
                    return 3;

                case 4:
                    err = "Error inesperado de la aplicacion";
                    msg = lg.errMsg;
                    return 4;

                default:
                    return acc;
            }
        }

        
        public D_Login objetoCD = new D_Login();
        public DataTable MostrarUsuario(string user)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarDatos(user);
            return tabla;
        }
    }
}
