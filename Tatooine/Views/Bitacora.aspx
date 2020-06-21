<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Tatooine.Views.Bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bitacora</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Esta es la Bitacora</h1>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="agregar registro" />
    </form>
</body>
</html>
