using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using Tatooine.Helpers;

namespace Tatooine.Views
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BackupButton_Click(object sender, EventArgs e)
        {
            //var ruta = RutaDestinoTextBox.Text;
            var ruta = "C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\Backup\\Backup";

            if (string.IsNullOrWhiteSpace(ruta))
            {
                this.SendAlert("Debe rellenar la ruta");

                return;
            }

            try
            {
                var dbServer = new Server(new ServerConnection(SqlUtils.Connection()));
                var dbBackUp = new Microsoft.SqlServer.Management.Smo.Backup() { Action = BackupActionType.Database, Database = "Tatooine" };
                

                dbBackUp.Devices.AddDevice(ruta.Trim() + ".bak", DeviceType.File);
                dbBackUp.Initialize = true;
                dbBackUp.SqlBackupAsync(dbServer);
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