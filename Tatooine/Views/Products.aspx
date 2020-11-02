<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Tatooine.Views.Products" enableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater runat="server" EnableViewState="true" ID="Repeater1">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div class="thumbnail">
                            <div class="caption">
                                <h3><%# Eval("Description") %></h3>
                                <p class="card-text">$<%# Eval("Price") %></p>
                                <asp:TextBox EnableViewState="true" runat="server" type="text" id="txtQuantity" placeholder="Cantidad"></asp:TextBox>
                                <asp:Button Text="Agregar a carrito" runat="server" class="btn btn-primary" OnClick="AddToCart" CommandArgument='<%# Eval("Id") %>' CommandName="De"></asp:Button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
