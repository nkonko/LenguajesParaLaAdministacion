
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaSolicitud.aspx.cs" Inherits="Tatooine.Views.AltaSolicitud" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="altaSolicitud">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row-md-6">
                    <h2>Alta Solicitud</h2>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4 col-sm-offset-4">

                        <div class="form-group">
                            <label for="producto_sol">Producto:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="producto_sol" placeholder="Nombre Producto"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="marca_sol">Marca:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="marca_sol" placeholder="Marca del Producto"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="modelo_sol">Modelo:</label>
                            <asp:TextBox runat="server" type="text" class="form-control" ID="modelo_sol" placeholder="Modelo del Producto"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="color_sol">Color:</label>
                            <asp:DropDownList runat="server" type="select" class="form-control" ID="color_sol">
                                <asp:ListItem Text="Seleccionar" Value=""></asp:ListItem>
                                <asp:ListItem Text="Rojo" Value="Rojo"></asp:ListItem>
                                <asp:ListItem Text="Negro" Value="Negro"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="fecha_sol">Fecha:</label>
                            <asp:TextBox runat="server" type="date" class="form-control" ID="fecha_sol"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="detalle_sol">Detalle:</label>
                            <asp:TextBox id="detalle_sol" class="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server" placeholder="Detalle del defecto..." ReadOnly="true" />

                        </div>
                        <asp:Button ID="BotonSolicitud" class="btn btn-block btn-primary" Text="Solicitar" runat="server" OnClick="SubmitSolicitud" />
                        <asp:Button ID="alertAction" ClientIDMode="Static" runat="server" OnClick="AlertPageAction" style="display:none;"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
