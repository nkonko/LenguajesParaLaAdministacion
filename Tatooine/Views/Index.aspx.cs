﻿// <auto-generated/>
using BLL.Interfaces;
using BLL.Utils;
using System;
using System.Web.UI;

namespace Tatooine
{
    public partial class _Index : Page
    {

        private readonly IIntegrityBusiness integrityBusiness = IOCContainer.Resolve<IIntegrityBusiness>();

        public string LoginMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GreetingsLabel.Text = "Bienvenido a Tatooine";
                LoginMessage = "Ingrese a login para iniciar";
            }
        }
    }
}