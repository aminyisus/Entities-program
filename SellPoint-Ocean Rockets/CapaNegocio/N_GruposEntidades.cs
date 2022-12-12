using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_GruposEntidades
    {
        D_GruposEntidades dgent = new D_GruposEntidades();

        DataTable dt;

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            dt = dgent.Listar();
            msg = dgent.msg;
            return dt;
        }

        public int Insert(string desc, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;
            int res = dgent.Insert(desc, comment, status, intNoElim);
            msg = dgent.msg;
            return res;
        }

        public int Update(int id, string desc, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;
            int res = dgent.Update(id, desc, comment, status, intNoElim);
            msg = dgent.msg;
            return res;
        }

        public int Delete(int id)
        {
            int res= dgent.Delete(id);
            msg = dgent.msg;
            return res;
        }

        public DataTable Buscar(string param)
        {
            dt= dgent.Buscar(param);
            msg = dgent.msg;
            return dt;
        }
    }
}
