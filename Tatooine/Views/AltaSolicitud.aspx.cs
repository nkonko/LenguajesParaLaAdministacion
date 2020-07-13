using BLL.Interfaces;
using BLL.Utils;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tatooine.Helpers;

namespace Tatooine.Views
{
    public partial class AltaSolicitud : System.Web.UI.Page
    {
        //Esto devuelve el new de la instancia! de la bll
        private IAltaSolicitudBusiness altaSolicitud_BLL = IOCContainer.Resolve<IAltaSolicitudBusiness>();

        BE.AltaSolicitud altaSolicitud_BE = new BE.AltaSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitSolicitud(object sender, EventArgs e)
        {
            string adicional = "ctl00$MainContent$";

            if (Request.Form[adicional + "producto_sol"] != "" && Request.Form[adicional + "marca_sol"] != "" && Request.Form[adicional + "modelo_sol"] != "" && Request.Form[adicional + "color_sol"] != "" && Request.Form[adicional + "fecha_sol"] != null)
            {
                altaSolicitud_BE.producto = Request.Form[adicional + "producto_sol"];
                altaSolicitud_BE.marca = Request.Form[adicional + "marca_sol"];
                altaSolicitud_BE.modelo = Request.Form[adicional + "modelo_sol"];
                altaSolicitud_BE.color = Request.Form[adicional + "color_sol"];
                altaSolicitud_BE.fecha_compra = Convert.ToDateTime(Request.Form[adicional + "fecha_sol"]);
                altaSolicitud_BE.detalle = Request.Form[adicional + "detalle_sol"];

                if (altaSolicitud_BLL.Add(altaSolicitud_BE))
                {              
                    PageExtensions.ShowInformativeAlert(this,"success","Éxito","Se ha creado su solicitud",1,3000);
                    //Response.Redirect("UserHome.aspx");
                }
                else
                {
                    PageExtensions.ShowInformativeAlert(this, "error", "Error", "Ha ocurrido un error. Por favor, vuelva a intentar", 1, 3000);
                }
            }
            else
            {
                PageExtensions.ShowInformativeAlert(this, "error", "Error", "Debe completar todos los campos", 1, 3000);
            }
        }
    }
}

