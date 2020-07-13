namespace Tatooine.Helpers
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public static class PageExtensions
    {
        public static void ShowInformativeAlert(this Page page, string icon, string title, string text, int showButton, int timer)
        {
            var input = page.Master.FindControl("ctl00$MainContent$alertEvent"); 

            string parametros = $"'{icon}','{title}','{text}',{showButton},{timer}";
            page.ClientScript.RegisterStartupScript(page.GetType(), "randomtext", $"showAlert_Informative({parametros})", true);
        }

        public static void ShowInteractiveAlert()
        {

        }

        public static void SendAlert(this Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Scripts", $"<script>alert('{message}');</script>");
        }
        public static void ErrorIntegridad(this Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Scripts","<script> function alertaCamposObligatorios() {Swal.fire({icon: 'error',title: 'Error',text: 'Error de integridad'})}</script>");
        }

        public static void CatchException(this Page page, Action func, Action<Exception> onError = null)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex);
            }
        }
    }
}