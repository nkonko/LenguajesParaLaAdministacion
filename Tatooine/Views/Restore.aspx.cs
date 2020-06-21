using DAL.Interfaces;
using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using Tatooine.App_Start;
using Tatooine.Helpers;

namespace Tatooine.Views
{
    public partial class Restore : System.Web.UI.Page
    {
        private IRestoreDao restore= IOCContainer.Resolve<IRestoreDao>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

      protected void Button1_Click(object sender, EventArgs e)
        {
            string ruta = TextBox1.Text;

            if (string.IsNullOrWhiteSpace(ruta))
            {
                this.SendAlert("Debe rellenar la ruta");

                return;
            }

           

            try
            {

               
                restore.ExecuteRestore(ruta);

            }
            catch (Exception ex)
            {
                this.SendAlert("Ocurrio un error");
                Response.Write(ex.Message);
                return;
            }
        }

    }
    }
