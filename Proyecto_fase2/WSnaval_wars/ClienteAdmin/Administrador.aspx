<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="ClienteAdmin.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administracion Naval Wars</title>
    <style type="text/css">
        .auto-style1 {
            width: 160px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div><!--Div titulo-->
    <h1>Administración</h1>
        <ul>
            <li><a href="ReporteBinario.aspx">Reporte Arbol Binario</a></li>
        </ul>
    </div>
    <div><!--div manejo de arbol binario-->
        -------------------------------------------------------------
        <h2>Arbol Binario</h2>
        <h3>Agregar Usuario</h3>
        <table style="width: 30%;"><!--Form para agregar usuarios-->
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Nick"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_nick" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_pass" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Mail"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_mail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Conectado"></asp:Label></td>
                <td><asp:RadioButton ID="radio_ABin_conectado" runat="server" /></td>
            </tr>
        </table>
        <asp:Button ID="boton_ABin_agregar" runat="server" Text="Agregar" />
        <asp:Label ID="msj_ABin_agregar" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <table style="width: 40%;"><!--Form para carga masiva de usuarios-->
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Direccion Usuarios"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_carga" runat="server" Width="300px"></asp:TextBox></td>
                <td><asp:Button ID="boton_ABin_carga" runat="server" Text="Cargar" OnClick="boton_ABin_carga_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label12" runat="server" Text="Direccion Juegos"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_games" runat="server" Width="300px"></asp:TextBox></td>
                <td><asp:Button ID="boton_ABin_games_carga" runat="server" Text="Cargar" OnClick="boton_ABin_games_carga_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="msj_ABin_carga" runat="server" Text=""></asp:Label>
        <br />
        <h3>Modificar/Eliminar Usuario</h3>
        <table style="width: 30%;">
            <tr>
                <td class="auto-style1"><asp:DropDownList ID="drop_ABin_usuarios" runat="server" Width="160px" ></asp:DropDownList></td>
                <td><asp:Button ID="boton_ABin_buscar" runat="server" Text="Buscar" OnClick="boton_ABin_buscar_Click" /></td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="Mail"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_Mmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="Label7" runat="server" Text="Contraseña"></asp:Label></td>
                <td><asp:TextBox ID="text_ABin_Mpass" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="Label8" runat="server" Text="Conectado"></asp:Label></td>
                <td><asp:RadioButton ID="radio_ABin_Mconectado" runat="server" /></td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Button ID="boton_ABin_modificar" runat="server" Text="Modificar" OnClick="boton_ABin_modificar_Click" /></td>
                <td><asp:Button ID="boton_ABin_eliminar" runat="server" Text="Eliminar" OnClick="boton_ABin_eliminar_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="msj_ABin_modificar" runat="server" Text=""></asp:Label>
        <h3>Sus Juegos</h3>
        <asp:Label ID="label_juegos" runat="server" Text=""></asp:Label>

        <table style="width: 20%;">
            <tr>
                <td>Generar Reporte Arbol Binario</td>
                <td><asp:Button ID="boton_reporte_binario" runat="server" Text="Generar" OnClick="boton_reporte_binario_Click" /></td>
            </tr>
        </table>
        <asp:Label ID="msj_reporte_binario" runat="server" Text=""></asp:Label>
    </div>
    ------------------------------------------------------------
    <div><!--div carga partidas-->

    </div>
    <div><!--div carga arbol B-->
        <h2>Arbol B</h2>
        <table style="width: 40%;">
            <tr>
                <td class="auto-style3"><asp:Label ID="Label9" runat="server" Text="Parametro de Orden"></asp:Label></td>
                <td><asp:DropDownList ID="drop_B_parametro" runat="server" CssClass="auto-style2" Width="260px">
                    <asp:ListItem Selected="True" Value="CoordenadaY"></asp:ListItem>
                    <asp:ListItem Value="CoordenadaX"></asp:ListItem>
                    <asp:ListItem Value="Unidad Atacante"></asp:ListItem>
                    <asp:ListItem Value="Resultado"></asp:ListItem>
                    <asp:ListItem Value="Tipo Unidad"></asp:ListItem>
                    <asp:ListItem Value="Emisor"></asp:ListItem>
                    <asp:ListItem Value="Receptor"></asp:ListItem>
                    <asp:ListItem Value="Fecha"></asp:ListItem>
                    <asp:ListItem Value="Tiempo Restante"></asp:ListItem>
                    <asp:ListItem Value="No. Ataque"></asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label11" runat="server" Text="Grado"></asp:Label></td>
                <td><asp:TextBox ID="text_B_grado" runat="server" Width="35px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style3"><asp:Label ID="Label10" runat="server" Text="Direccion"></asp:Label></td>
                <td><asp:TextBox ID="text_B_carga" runat="server" Width="260px"></asp:TextBox></td>
                <td><asp:Button ID="boton_B_cargar" runat="server" Text="Cargar" /></td>
            </tr>
        </table>
        <asp:Label ID="msj_B_carga" runat="server" Text=""></asp:Label>
    
    </div>
        ------------------------------------------------------------
    <div><!--div reglas del juego-->

    </div>
    <div><!--div carga tablero-->

    </div>
    </form>
</body>
</html>
