<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClienteAdmin.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Home</h1>
    </div>
    <div><!--Div apariencia de login-->
        <table style="width: 25%;">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></td>
                <td><asp:TextBox ID="text_admin_nick" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label></td>
                <td><asp:TextBox ID="text_admin_pass" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="boton_login" runat="server" Text="Aceptar" OnClick="boton_login_Click" />
        <asp:Label ID="msj_error" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
