using DAL.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Tatooine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Tatooine.Views
{
    public partial class Restore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RestoreButton_Click(object sender, EventArgs e)
        {
            //var ruta = RutaDestinoTextBox.Text;
            var ruta = "C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\Backup\\Backup";
            if (string.IsNullOrWhiteSpace(ruta))
            {
                this.SendAlert("Debe selecciona una ruta.");
                return;
            }
        }

        protected void FileSystem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerDialog = new System.Windows.Forms.FolderBrowserDialog();
            explorerDialog.ShowNewFolderButton = false;
        }
    }
}