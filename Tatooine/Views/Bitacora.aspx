<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Tatooine.Views.Bitacora" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container restore">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-12">
                    <h2>Bitacora</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-10 col-sm-offset-1">
                      <div class="table-container table-responsive">
                    <table class="table">
                        <thead class="thead-dark">
                            <tr class="table-primary">
                                <th scope="col">#</th>
                                <th scope="col">Criticidad</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Usuario</th>
                            </tr>
                        </thead>
                        <tbody>
                            <% foreach (var fila in filas) { %>
                            <tr>
                                <td><%=fila.IdLog %></td>
                                <td><%=fila.Criticidad%></td>
                                <td><%=fila.Fecha.ToString() %></td>
                                <td><%=fila.Usuario%></td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
