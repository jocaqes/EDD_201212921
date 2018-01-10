<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUnidades.aspx.cs" Inherits="ClienteAdmin.Usuarios.AgregarUnidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Unidades</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <li><a href="../Usuario.aspx">Perfil</a></li>
            </ul>
        </div>
    <div>
    <h2>Aqui puedes agregar tus unidades al tablero</h2>
        <table style="width: 100%;">
            <tr>
                <td>Satelites</td>
                <td>Aviones</td>
                <td>Tipo de Unidad</td>
                <td align="right"><asp:DropDownList ID="drop_tipo_unidades" runat="server">
                    <asp:ListItem Selected="True">Submarino</asp:ListItem>
                    <asp:ListItem>Fragata</asp:ListItem>
                    <asp:ListItem>Crucero</asp:ListItem>
                    <asp:ListItem>Caza</asp:ListItem>
                    <asp:ListItem>Helicoptero de Combate</asp:ListItem>
                    <asp:ListItem>Bombardero</asp:ListItem>
                    <asp:ListItem>Neosatelite</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="label_tablero_satelites" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="label_tablero_aviones" runat="server" Text=""></asp:Label></td>
                <td>Coordenada X(letras)</td>
                <td align="right"><asp:TextBox ID="text_coordenada_x" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Barcos</td>
                <td>Submarinos</td>
                <td>Coordenada Y(numeros)</td>
                <td align="right"><asp:TextBox ID="text_coordenada_y" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="label_tablero_barcos" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="label_tablero_submarinos" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="label_unidades_restantes" runat="server" Text=""></asp:Label></td>
                <td align="right"><asp:Button ID="boton_agregar_unidad" runat="server" Text="Agregar" OnClick="boton_agregar_unidad_Click" /></td>
            </tr>
            <tr>
                <td colspan="4" align="right"><asp:Label ID="msj_insertar" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
