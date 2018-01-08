<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ClienteAdmin.Usuario" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="msj_nombre_usuario" runat="server" Text=""></asp:Label>
            <ul>
                <li><a href="Home.aspx?msj=close">Cerrar Sesion</a></li>
            </ul>
        </div>
        <div><!--mis partidas-->
            <asp:Label ID="label_mis_partidas" runat="server" Text=""></asp:Label>
        </div>
        <div><!--mis contactos-->
            <h3>Contactos</h3>
            <table style="width: 25%;">
                <tr>
                    <td><asp:DropDownList ID="drop_contactos" runat="server" Width="120px"></asp:DropDownList></td>
                    <td><asp:Button ID="boton_buscar" runat="server" Text="Buscar" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Nick"></asp:Label></td>
                    <td colspan="2"><asp:TextBox ID="text_nick" runat="server" Enabled="False" Width="251px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Correo"></asp:Label></td>
                    <td colspan="2"><asp:TextBox ID="text_mail" runat="server" Width="250px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="boton_modificar" runat="server" Text="Modificar" /></td>
                    <td><asp:Button ID="boton_eliminar" runat="server" Text="Eliminar" /></td>
                    <td><asp:Button ID="boton_agregar" runat="server" Text="Agregar" /></td>
                </tr>
            </table>
            <asp:Label ID="label_modificacion" runat="server" Text=""></asp:Label>
        </div>
        <div><!--nueva partida-->
            <table style="width: 25%;">
                <tr>
                    <td>Iniciar nueva Partida</td>
                    <td><asp:Button ID="boton_nueva_partida" runat="server" Text="Iniciar" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
