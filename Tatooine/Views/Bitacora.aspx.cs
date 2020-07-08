using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Interfaces;
using DAL.Utils;

namespace Tatooine.Views
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DAL.BitacoraDao dalbit = new DAL.BitacoraDao();

            
            DateTime hoy = DateTime.Now;

            // dalbit.Error(4, "algo", "desc", hoy);

            //List<BE.Bitacora> lista = dalbit.ObtenerTodos();

            DateTime desde = new DateTime(2020, 4, 4);
            DateTime hasta = new DateTime(2020, 6, 21);

            List<BE.Bitacora> lista = dalbit.ObtenerFiltro(desde, hasta, "", "ALTA");


        }
    }
}