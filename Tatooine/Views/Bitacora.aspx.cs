﻿namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;

    public partial class Bitacora : System.Web.UI.Page
    {
        private readonly IBitacoraBusiness bitacora = IOCContainer.Resolve<IBitacoraBusiness>();
        public List<BE.Bitacora> filas;
        protected void Page_Load(object sender, EventArgs e)
        {
            filas = bitacora.GetBitacora();
        } 
    }
}