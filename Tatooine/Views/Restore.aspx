﻿<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="Tatooine.Views.Restore" MasterPageFile="~/Site.Master" %>

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
                    <div class="col-md-4 col-sm-offset-4">
                        <div class="input-bar">
                            <div class="input-bar-item">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control width100" placeholder="Ruta destino"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="FileSystemButton" class="btnSubmit btn btn-block btn-info" Text="Examinar" runat="server" OnClick="FileSystem_Click" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-sm-offset-4">
                        <asp:Button ID="RestoreButton" class="btnSubmit btn btn-block btn-success" Text="Aceptar" runat="server" OnClick="RestoreButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>