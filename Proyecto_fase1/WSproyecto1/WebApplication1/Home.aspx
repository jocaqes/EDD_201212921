<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Naval Wars</h1>
    </div>
    <div><!--Inicio de Sesion-->

        <asp:Label ID="Label1" runat="server" Text="Nickname"></asp:Label>
        <asp:TextBox ID="text_nick" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="text_pass" runat="server" TextMode="Password"></asp:TextBox>

        <br />
        <asp:Button ID="boton_aceptar" runat="server" Text="Aceptar" OnClick="boton_aceptar_Click" />

        <asp:Label ID="label_mensaje" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
