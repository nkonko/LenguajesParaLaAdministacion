<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Tatooine.Views.SignUp" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-6">
                    <h2>Crear cuenta</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6 col-sm-offset-2">
                        <form>
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" class="form-control" ID="NameInput" Placeholder="Nombre"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" type="text" class="form-control" ID="UsernameInput" Placeholder="Nombre de usuario"></asp:TextBox>
                            </div>
                            <p>Puedes usar letras, números y signos de puntuación</p>
                            <div class="form-group form-inline mb-2">
                                <asp:TextBox class="form-control" runat="server" type="password" ID="PasswordInput" Placeholder="Contraseña"></asp:TextBox>
                                <asp:TextBox class="form-control" runat="server" type="password" ID="ConfirmInput" Placeholder="Confirmacion"></asp:TextBox>
                            </div>
                            <asp:Button ID="SubmitButton" class="btn btn-primary mb-2" Text="Crear" runat="server" OnClick="SubmitButton_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
