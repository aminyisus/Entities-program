using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_Entidades
    {
        D_Entidades dent = new D_Entidades();
        D_TiposEntidades dtent = new D_TiposEntidades();
        D_GruposEntidades dgent = new D_GruposEntidades();

        DataTable dt;

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            dt = dent.Listar();
            msg = dent.msg;
            return dt;
        }

        private string[] SetUrls(string urlPag, string urlFB, string urlIG, string urlTW, string urlTK)
        {
            string[] urls = new string[5];

            urls[0] = urlPag == "Url Pagina Web" ? "" : urlPag;
            urls[1] = urlFB == "Url Facebook" ? "" : urlFB;
            urls[2] = urlIG == "Url Instagram" ? "" : urlIG;
            urls[3] = urlTW == "Url Twitter" ? "" : urlTW;
            urls[4] = urlTK == "Url TikTok" ? "" : urlTK;

            return urls;
        }

        private bool IsLessThanZero(float credito)
        {
            return credito < 0;
        }

        public int Insert(string desc, string direccion, string local, string typeEnt,
            string typeDoc, string numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
            string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
            string comment, string status, bool noElim)
        {
            if (IsLessThanZero(limCr))
            {
                return 2;
            }
            else
            {
                int intNoElim = noElim ? 1 : 0;

                string[] urls = SetUrls(urlPag, urlFB, urlIG, urlTW, urlTK);
                long longNumDoc = Convert.ToInt64(numDoc.Replace("-", ""));

                int res = dent.Insert(desc, direccion, local, typeEnt, typeDoc, longNumDoc, tel, urls[0], urls[1],
                    urls[2], urls[3], urls[4], idGrEnt, idTypeEnt, limCr, user, pass, rol, comment, status, intNoElim);
                msg = dent.msg;

                return res;
            }
        }

        public int Update(int id, string desc, string direccion, string local, string typeEnt,
           string typeDoc, string numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
           string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
           string comment, string status, int noElim)
        {
            if (IsLessThanZero(limCr))
            {
                return 2;
            }
            else
            {
                string[] urls = SetUrls(urlPag, urlFB, urlIG, urlTW, urlTK);

                long longNumDoc = Convert.ToInt64(numDoc.Replace("-", ""));

                int res = dent.Update(id, desc, direccion, local, typeEnt,
                typeDoc, longNumDoc, tel, urls[0], urls[1], urls[2], urls[3],
                urls[4], idGrEnt, idTypeEnt, limCr, user, pass, rol,
                comment, status, noElim);
                msg = dent.msg;

                return res;
            }
        }

        public int Delete(int id)
        {
            int res = dent.Delete(id);
            msg = dent.msg;

            return res;
        }

        public DataTable Buscar(string param)
        {
            dt = dent.Buscar(param);
            msg = dent.msg;
            return dt;
        }

        public string[] CargarTpEntidad(){
            DataTable tbTpEnt= dtent.Listar();
            int o= tbTpEnt.Rows.Count;
            string[] tpEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                tpEnt[i]= tbTpEnt.Rows[i][0].ToString();
            }

            return tpEnt;
        }

        public string[] CargarGrEntidad(){
            DataTable tbGrEnt= dgent.Listar();
            int o= tbGrEnt.Rows.Count;
            string[] grEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                grEnt[i]= tbGrEnt.Rows[i][0].ToString();
            }

            return grEnt;
        }
    }
}
