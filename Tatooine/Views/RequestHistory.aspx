<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="RequestHistory.aspx.cs" Inherits="Tatooine.Views.RequestHistory" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container request-history">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-12">
                    <h2>Solicitudes</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="table-container table-responsive">
                    <table class="table">
                        <thead class="thead-dark">
                            <tr class="table-primary">
                                <th scope="col">#</th>
                                <th scope="col">Producto</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var request in Solicitudes)
                                { %>
                            <tr>
                                <th scope="row"><%=request.id %></th>
                                <td><%=request.producto %></td>
                                <td><%=request.fecha_compra.ToString() %></td>
                                <td><%=request.estado %></td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
