namespace Tatooine.Views
{
    using BLL.Utils;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using Tatooine.Helpers;

    public partial class Backup : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (BE.User)Session["user"];

            if (user != null)
            {
                var isAdmin = user.Families.Any(f => f.Description == "Administrador");

                if (!isAdmin)
                {
                    Response.Redirect("Login.aspx");
                }

                ReadBackupFiles();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void ActualizrButton_Click(object sender, EventArgs e)
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

                string _BackupName = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".bak";


                dbBackUp.Devices.AddDevice(ruta.Trim() + _BackupName, DeviceType.File);
                dbBackUp.Initialize = true;
                dbBackUp.SqlBackupAsync(dbServer);
                Label1.Text = "El backup: " + _BackupName + " fue creado con éxito";

                Label1.ForeColor = Color.Red;
                ReadBackupFiles();

            }
            catch (Exception ex)
            {
                this.SendAlert("Ocurrio un error");
                Response.Write(ex.Message);
                return;
            }


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

                if (files.Length > 0)
                {
                    lstBackupfiles.DataSource = files;
                    lstBackupfiles.DataBind();
                    lstBackupfiles.SelectedIndex = 0;
                }
                else
                {
                    lstBackupfiles.DataSource = null;
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void FileSystem_Click(object sender, EventArgs e)
        {
            this.SendAlert("Debe selecciona una ruta.");
        }

    }
}