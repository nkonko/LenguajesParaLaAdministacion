using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tatooine.Views
{
    public class Solicitud
    {
        public int id { get; set; }
        public string producto { get; set; }
        public string fecha { get; set; }
        public string estado { get; set; }

        public Solicitud(int id, string p, string f, string e)
        {
            this.id = id;
            this.producto = p;
            this.fecha = f;
            this.estado = e;
        }
    }
    public partial class RequestHistory : System.Web.UI.Page
    {
        protected List<Solicitud> dummy = new List<Solicitud>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener listado de solicitudes desde BE. Ejemplo Pedidos Distar:
            // List<Distar_EntidadesNegocio.Pedido> lista_pedidos = new List<Distar_EntidadesNegocio.Pedido>();
            getViewData();
        }

        private void getViewData()
        {
            // lista_pedidos = pedidoBL.getAllPedidos();
            dummy.Add(new Solicitud(1, "Samsung Galaxy S10", "02/05/20202", "Resuelto"));
            dummy.Add(new Solicitud(2, "Samsung Galaxy S102", "02/05/20202", "Resuelto"));
            dummy.Add(new Solicitud(3, "Samsung Galaxy S103", "02/05/20202", "Resuelto"));
            dummy.Add(new Solicitud(4, "Samsung Galaxy S104", "02/05/20202", "Resuelto"));
            dummy.Add(new Solicitud(5, "Samsung Galaxy S105", "02/05/20202", "Resuelto"));
            dummy.Add(new Solicitud(6, "Samsung Galaxy S106", "02/05/20202", "Resuelto"));
        }
    }
}