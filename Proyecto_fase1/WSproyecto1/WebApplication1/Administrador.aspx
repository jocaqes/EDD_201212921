<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="WebApplication1.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style5 {
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Administracion</h1>
    </div>
    <div><!--Area de Menu-->
    <h3>Agregar Usuario</h3>
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
    
        <asp:Label ID="label_msj_insertar" runat="server" Text=""></asp:Label>
    
        <br />
        ---------------------------------------------------------------
    </div>
    <div>
        <h3>Buscar y Modificar Usuario</h3>
        <asp:Label ID="Label5" runat="server" Text="Nickname"></asp:Label>
        <asp:TextBox ID="text_busqueda" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="text_pass_busqueda" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="text_mail_busqueda" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="boton_buscar" runat="server" Text="Buscar" OnClick="boton_buscar_Click" />
        <asp:Button ID="boton_modificar" runat="server" Text="Modificar" OnClick="boton_modificar_Click" />
        <asp:Button ID="boton_eliminar" runat="server" Text="Eliminar" OnClick="boton_eliminar_Click" />
        <asp:Label ID="label_msj_busqueda" runat="server" Text=""></asp:Label>
        <br />
        ---------------------------------------------------------------<br />
    </div>
    <div>
        <h3>ABC Juegos</h3>
        <table style="width: 50%;">
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="Label8" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="text_jugador_principal" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label9" runat="server" Text="Oponente"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="text_oponente" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Label ID="Label10" runat="server" Text="Unidades Desplegadas"></asp:Label>
        <asp:TextBox ID="text_desplegadas" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Sobrevivientes"></asp:Label>
        <asp:TextBox ID="text_sobrevivientes" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Destruidas"></asp:Label>
        <asp:TextBox ID="text_destruidos" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Check si gano"></asp:Label>
        <asp:RadioButton ID="check_victoria" runat="server" />
        <br />
        <asp:Button ID="boton_add_juego" runat="server" Text="Agregar" OnClick="boton_add_juego_Click" />
        <asp:Label ID="label_msj_juego" runat="server" Text=""></asp:Label>
        <br />
        ---------------------------------------------------------------<br />

    </div>
    <div>
        <h3>Carga Masiva</h3>
        <asp:Label ID="Label4" runat="server" Text="Carga Masiva Usuarios"></asp:Label>
        <asp:TextBox ID="text_carga_masiva" runat="server"></asp:TextBox>

        <asp:Button ID="boton_carga_masiva" runat="server" Text="Cargar" OnClick="boton_carga_masiva_Click" />

        <br />
        <asp:Label ID="Label14" runat="server" Text="Carga Masiva Juegos"></asp:Label>

        <asp:TextBox ID="text_carga_juegos" runat="server"></asp:TextBox>

        <asp:Button ID="boton_carga_juegos" runat="server" Text="Cargar" OnClick="boton_carga_juegos_Click" />

        <br />
        <asp:Button ID="boton_graficar" runat="server" Text="Graficar" OnClick="boton_graficar_Click" />

        <asp:Label ID="label_msj_carga" runat="server" Text=""></asp:Label>

        <br />
        ---------------------------------------------------------------

    </div>
    <div>
        <h3>Agregar Juego</h3>
        <br />

    </div>
    <div>
        <ul>
                <li><a href="Home.aspx?msj=close">Cerrar Sesion</a></li>
            
        </ul>
    </div>
    </form>
</body>
</html>
