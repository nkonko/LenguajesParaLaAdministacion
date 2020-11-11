<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Tatooine.Views.Employee" MasterPageFile="~/Site.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1>Empleados</h1>
        <br />
        <div class="col-md-8" id="employees" runat="server">
        </div>
    </div>
</asp:Content>
