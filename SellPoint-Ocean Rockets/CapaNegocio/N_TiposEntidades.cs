using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_TiposEntidades
    {
        D_TiposEntidades dtent = new D_TiposEntidades();
        D_GruposEntidades dgent = new D_GruposEntidades();

        DataTable dt;

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            dt= dtent.Listar();
            msg = dtent.msg;
            return dt;
        }

        public int Insert(string desc, int idGrEnt, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;
            int res= dtent.Insert(desc, idGrEnt, comment, status, intNoElim);
            msg = dtent.msg;
            return res;
        }

        public int Update(int id, string desc, int idGrEnt, string comment, string status, bool noElim)
        {
            int intNoElim=noElim? 1 : 0;
            int res= dtent.Update(id, desc, idGrEnt, comment, status, intNoElim);
            msg = dtent.msg;
            return res;
        }

        public int Delete(int id)
        {
            int res= dtent.Delete(id);
            msg = dtent.msg;
            return res;
        }

        public DataTable Buscar(string param)
        {
            dt= dtent.Buscar(param);
            msg = dtent.msg;
            return dt;
        }

        public string[] CargarGrEntidad(){
            DataTable tbTpEnt= dgent.Listar();
            int o=tbTpEnt.Rows.Count;
            string[] grEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                grEnt[i]=tbTpEnt.Rows[i][0].ToString();
            }

            return grEnt;
        }
    }
}
