﻿namespace Tatooine.Helpers
{
    using System;
    using System.Web.UI;

    public static class PageExtensions
    {
        public static void SendAlert(this Page page, string Message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "Scripts", $"<script>alert('{Message}');</script>");
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