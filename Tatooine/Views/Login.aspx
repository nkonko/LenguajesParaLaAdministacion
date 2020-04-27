<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tatooine.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login">
        <div class="row">
            <div class="col-md-3 col-md-offset-5 form-container">
                <form>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Email</label>
                        <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Email">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Password</label>
                        <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
                    </div>
                    <asp:Button ID="SubmitButton" class="btn btn-block btn-primary" Text="Ingresar" runat="server" OnClick="SubmitButton_Click" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>

