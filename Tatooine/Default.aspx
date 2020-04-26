<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tatooine._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Usuarios</h1>
        <p>
            <asp:ListView ID="UserList" runat="server" ItemType="BE.User">
                <ItemTemplate>
                    <div class ="list-group">
                        <table>
                            <tr><td><%# Item.Id %></td></tr>
                            <tr><td><%# Item.Name %></td></tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>
        </p>
        <a href="http://www.asp.net" class="btn btn-primary btn-lg">Presione»</a></div>

    </asp:Content>
