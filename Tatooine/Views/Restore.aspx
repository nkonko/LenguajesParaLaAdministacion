<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="Tatooine.Views.Restore" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container restore">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-12">
                    <h2>Realizar Restore</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    
                </div>
                 <div align=center>
                     <p>Seleccione un backup para realizar la restauración: </p>
                    <asp:ListBox ID="lstBackupfiles" runat="server" Height="236px" Width="354px"></asp:ListBox>
                         
                </div>
                <div class="row" align=center>
                    <div class="col-md-4 col-sm-offset-4">
                        <asp:Button ID="RestoreButton" class="btnSubmit btn btn-block btn-success" Text="Restore" runat="server" OnClick="RestoreButton_Click" />
                    </div>
                </div>
                <div align=center>
        
                    <asp:Label ID="Label1" runat="server" Text="" Width="454px"></asp:Label>
                    
                 </div>
                 

            </div>
        </div>
    </div>
</asp:Content>
