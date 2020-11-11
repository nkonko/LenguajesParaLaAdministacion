using System;
using System.Text;
using System.Web.UI;
using System.Xml;

namespace Tatooine.Views
{
    public partial class Employee : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            employees.InnerHtml = ReadXml();
        }

        public string ReadXml()
        {
            var reader = GetReader();
            var builder = new StringBuilder();

            builder.Append(@"<table class=\""table table-striped\""><thead><tr><th scope=\""col\"">Nombre</th><th scope=\""col\"">Apellido</th><th scope=\""col\"">Edad</th><th scope=\""col\"">Cargo</th></tr></thead><tbody><tr>");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        if (reader.Name == "NOMBRE")
                        {
                            builder.Append("<tr>");
                            builder.Append("<td>");

                        }

                        if (reader.Name == "APELLIDO" || reader.Name == "EDAD")
                        {
                            builder.Append("<td>");
                        }

                        if (reader.Name == "CARGO")
                        {
                            builder.Append("<td>");
                            builder.Append("</tr>");
                        }

                        break;
                    case XmlNodeType.Text:
                        builder.Append(reader.Value);
                        builder.Append("</td>");
                        break;
                }
            }

            reader.Close();
            builder.Append("</tbody></table>");
            return builder.ToString();
        }

        private XmlReader GetReader()
        {
            return XmlReader.Create(@"C:\Users\nicoa\Documents\Universidad\LPPA\LenguajesParaLaAdministacion\Tatooine\Views\empleados.xml");
        }

    }
}