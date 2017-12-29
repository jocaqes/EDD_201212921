<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="WebApplication1.Reports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="General.css"/> 
    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img alt="Porque no carga mi imagen" src="Imagenes/arbolBin.png" />
    </div>
    <div>
        <img alt="Porque no carga mi imagen" src="Imagenes/espejo.png" />
    </div>
    <div>
        <h3>Datos Arbol Binario</h3>
        <table style="width: 20%;">
            <tr>
                <td>Altura</td>
                <td><% if (servicio != null) %> 
                    <% { Response.Write(servicio.alturaBinario().ToString()); } %> 
                </td>

            </tr>
            <tr>
                <td>Nodos Hoja</td>
                <td><% if (servicio != null) %> 
                    <% { Response.Write(servicio.hojasBinario().ToString()); } %> 
                </td>
            </tr>
            <tr>
                <td>Nodos Rama</td>
                <td><% if (servicio != null) %> 
                    <% { Response.Write(servicio.ramasBinario().ToString()); } %> 
                </td>
            </tr>
        </table>
    </div>

    <div>
        <h3>Tablero de Juego</h3>
        <img alt="Porque no carga mi imagen" src="Imagenes/tablero.png"/>
    </div>
    </form>
</body>
</html>
