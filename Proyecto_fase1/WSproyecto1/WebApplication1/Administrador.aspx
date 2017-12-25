<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WebApplication1.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Administracion</h1>
    </div>
    <div><!--Area de Menu-->
    
        <asp:Label ID="Label1" runat="server" Text="Nickname"></asp:Label>
        <asp:TextBox ID="text_nickuser" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="text_passuser" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="text_mailuser" runat="server"></asp:TextBox>
    
        <br />
        <asp:Button ID="boton_aceptar" runat="server" Text="Aceptar" OnClick="boton_aceptar_Click" />
    
        <asp:Button ID="boton_graficar" runat="server" Text="Graficar" OnClick="boton_graficar_Click" />
    
    </div>
    <div>

        <asp:Label ID="Label4" runat="server" Text="Direccion Carga Masiva"></asp:Label>
        <asp:TextBox ID="text_carga_masiva" runat="server"></asp:TextBox>

        <asp:Button ID="boton_carga_masiva" runat="server" Text="Cargar" OnClick="boton_carga_masiva_Click" />

    </div>
    <div>
        <ul>
                <li><a href="Home.aspx">Home</a></li>
        </ul>
    </div>
    </form>
</body>
</html>
