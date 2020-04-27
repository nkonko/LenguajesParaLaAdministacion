<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="Tatooine.Views.Backup" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-6">
                    <h2>Backup</h2>
                    <asp:TextBox ID="RutaDestinoTextBox" runat="server" class="form-control" placeholder="Ruta destino"></asp:TextBox>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4 col-sm-offset-4">
                        <asp:Button ID="BackupButton" class="btnSubmit btn btn-block btn-success" Text="Realizar backup" runat="server" OnClick="BackupButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
