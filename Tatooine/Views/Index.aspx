<%@ Page Title="Tatoine" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Tatooine._Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>
            <asp:Label runat="server" ID="GreetingsLabel"></asp:Label>
        </h1>
        <p>
            Ingrese a login para iniciar
        </p>
    </div>

</asp:Content>
