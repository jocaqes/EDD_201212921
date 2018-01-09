<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteBinario.aspx.cs" Inherits="ClienteAdmin.ReporteBinario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte Binario</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Reporte Arbol Binario</h1>
        <table style="width: 50%;" border="1">
            <tr>
                <td colspan="2">Arbol Binario</td>
            </tr>
            <tr>
                <td colspan="2"><img alt="Intente Recargar" src="Imagenes/binario.png" height="800" width ="800"/></td>
            </tr>
            <tr>
                <td>Altura</td>
                <td><asp:Label ID="label_altura" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Numero de Hojas</td>
                <td><asp:Label ID="label_hojas" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>Numero de Ramas</td>
                <td><asp:Label ID="label_ramas" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">Arbol Espejo</td>
            </tr>
            <tr>
                <td colspan="2"><img alt="Intente Recargar" src="Imagenes/espejo.png" height="800" width ="800"/></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
