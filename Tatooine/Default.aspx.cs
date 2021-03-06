﻿// <auto-generated/>
using BLL;
using System;
using System.Web.UI;
using Tatooine.App_Start;

namespace Tatooine
{
    public partial class _Default : Page
    {
        private IUserBusiness userBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            userBusiness = IOCContainer.Resolve<IUserBusiness>();

            if (!Page.IsPostBack)
            {
                UserList.DataSource = userBusiness.Get();
                UserList.DataBind();
            }
        }
    }
}