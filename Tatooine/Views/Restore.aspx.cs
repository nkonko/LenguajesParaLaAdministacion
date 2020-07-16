namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Tatooine.Helpers;

    public partial class Restore : System.Web.UI.Page
    {
        private IRestoreBusiness restore = IOCContainer.Resolve<IRestoreBusiness>();

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

                if (!Page.IsPostBack)
                {
                    ReadBackupFiles();
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void RestoreButton_Click(object sender, EventArgs e)
        {

            string _BackupName = lstBackupfiles.SelectedItem.Text.ToString();

            //Mostrar error si el usuario no selecciona ningún bkp.

            try
            {
                var result = restore.ExecuteRestore(_BackupName);

                Label1.Text = "El backup: " + _BackupName + " fue restaurado con éxito";

                Label1.ForeColor = System.Drawing.Color.Red;
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
                lstBackupfiles.DataSource = files;
                lstBackupfiles.DataBind();
                lstBackupfiles.SelectedIndex = 0;


            }
            catch (Exception)
            {
                throw;
            }
        }



        protected void FileSystem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog explorerDialog = new System.Windows.Forms.FolderBrowserDialog();
            explorerDialog.ShowNewFolderButton = false;
        }

    }
}
