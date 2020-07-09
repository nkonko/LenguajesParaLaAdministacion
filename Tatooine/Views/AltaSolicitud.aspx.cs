using BLL.Interfaces;
using BLL.Utils;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tatooine.Views
{
    public partial class AltaSolicitud : System.Web.UI.Page
    {
        //Esto devuelve el new de la instancia! de la bll
        private readonly IAltaSolicitudBusiness altaSolicitudBusiness = IOCContainer.Resolve<IAltaSolicitudBusiness>();

        BE.AltaSolicitud altaSolicitud_BE = new BE.AltaSolicitud();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitSolicitud(object sender, EventArgs e)
        {
            string adicional = "ctl00$MainContent$";
            altaSolicitud_BE.producto = Request.Form[adicional + "producto_sol"];
            altaSolicitud_BE.marca = Request.Form[adicional + "marca_sol"];
            altaSolicitud_BE.modelo = Request.Form[adicional + "modelo_sol"];
            altaSolicitud_BE.color = Request.Form[adicional + "color_sol"];
            altaSolicitud_BE.fecha_compra = Convert.ToDateTime(Request.Form[adicional + "fecha_sol"]);
            altaSolicitud_BE.detalle = Request.Form[adicional + "detalle_sol"];

            if (altaSolicitudBusiness.Add(altaSolicitud_BE))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se creó la solicitud');</script>");
                CleanControl(this.Controls);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Hubo un error');</script>");
            }
        }

        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }
    }
}

