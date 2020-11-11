<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Tatooine.Views.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Shopping Cart</h1>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover">
                    <tr>
                        <th>Descripcion</th>
                        <th>Cantidad</th>
                        <th>Precio</th>
                    </tr>
                    <% foreach (var product in Becart.Products)
                                { %>
                    <tr>
                        <td><%=product.Product.Description %></td>
                        <td><%=product.Quantity %></td>
                        <td>$ <%=product.Product.Price %></td>
                        <td></td>
                    </tr>
                     <% } %>
                    <tr>
                        <td>Total:$ <%=Becart.GetTotalOfCart() %> </td>
                    </tr>
                </table>
            </div>

            <div class="col-md-4">
                <asp:Button Text="Terminar compra" runat="server" type="button" class="btn btn-success" OnClick="Finish"></asp:Button>
            </div>
        </div>
    </div>
</asp:Content>
