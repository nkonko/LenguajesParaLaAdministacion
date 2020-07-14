<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tatooine.Views.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-6">
                    <h2>Iniciar sesion</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4 col-sm-offset-4">
                        <form>
                            <div class="form-group">
                                <label for="UsernameInput">User Name</label>
                                <asp:TextBox runat="server" type="text" class="form-control" id="UsernameInput" placeholder="User Name"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="PasswordInput">Password</label>
                                <asp:TextBox runat="server" type="password" class="form-control" id="PasswordInput" placeholder="Password"></asp:TextBox>
                            </div>
                            <asp:Button ID="SubmitButton" class="btn btn-block btn-primary" Text="Iniciar" runat="server" OnClick="SubmitButton_Click" />
                            <asp:Button ID="alertAction" ClientIDMode="Static" runat="server" OnClick="AlertPageAction" style="display:none;"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
