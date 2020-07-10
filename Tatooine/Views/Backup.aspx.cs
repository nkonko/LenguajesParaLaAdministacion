namespace Tatooine.Views
{
    using BLL.Utils;
    using BLL.Interfaces;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Windows.Forms;
    using Tatooine.Helpers;
    using System.IO;

    public partial class Backup : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadBackupFiles();
        }

        protected void BackupButton_Click(object sender, EventArgs e)
        {
            //var ruta = "C:\\Program Files\\Microsoft SQL Server\\MSSQL14.SQLEXPRESS\\MSSQL\\Backup\\Backup";

            var ruta = "C:\\SQLServerBackups\\";

            try
            {
                var dbServer = new Server(new ServerConnection(DatabaseConection.GetConnection()));
                var dbBackUp = new Microsoft.SqlServer.Management.Smo.Backup() { Action = BackupActionType.Database, Database = "Tatooine" };

                string _BackupName = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()+ ".bak";

               
                dbBackUp.Devices.AddDevice(ruta.Trim() +_BackupName, DeviceType.File);
                dbBackUp.Initialize = true;
                dbBackUp.SqlBackupAsync(dbServer);
                
            }
            catch (Exception ex)
            {
                this.SendAlert("Ocurrio un error");
                Response.Write(ex.Message);
                return;
            }

            ReadBackupFiles();
        }

        private void ReadBackupFiles()
        {
            try
            {
                if (!Directory.Exists(@"c:\SQLServerBackups\"))
                {
                    Directory.CreateDirectory(@"c:\SQLServerBackups\");
                }

                string[] files = Directory.GetFiles(@"c:\SQLServerBackups\", "*.bak");
                lstBackupfiles.DataSource = files;
                lstBackupfiles.DataBind();
                lstBackupfiles.SelectedIndex = 0;
            }
            catch (Exception exception)
            {
                //lblMessage.Text = exception.Message.ToString();
            }
        }

        protected void FileSystem_Click(object sender, EventArgs e)
        {
            this.SendAlert("Debe selecciona una ruta.");
        }
    }
}