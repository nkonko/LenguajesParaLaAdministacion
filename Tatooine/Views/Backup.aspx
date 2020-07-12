<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="Tatooine.Views.Backup" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container backup">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-12">
                    <h2>Realizar Backup</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4 col-sm-offset-4">
                        <div class="input-bar">
                            <div class="input-bar-item">
                               

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" align=center>
                    <div class="col-md-4 col-sm-offset-4">
                        <asp:Button ID="Button1" class="btnSubmit btn btn-block btn-success" Text="Crear Backup" runat="server" OnClick="BackupButton_Click" />
                        <asp:Button ID="Button2" class="btnActualizar btn btn-block btn-success" Text="Actualizar Lista" runat="server" OnClick="ActualizrButton_Click" />
                    </div>
                </div>
                <div align=center>
                    <p>Backups:</p>
                    <asp:ListBox ID="lstBackupfiles" runat="server" Height="236px" Width="454px"></asp:ListBox>
                    
                 </div>

                <div align=center>
        
                    <asp:Label ID="Label1" runat="server" Text="" Width="454px"></asp:Label>
                    
                 </div>
                 

            </div>
        </div>
    </div>
</asp:Content>
