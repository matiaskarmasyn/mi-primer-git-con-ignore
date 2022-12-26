<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rechazado.aspx.cs" Inherits="Laboratorio.deslogueado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_deslogueado" runat="server">
   
        <div class="imagencentral" id="imagencentral" align="right" style="width:100%">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tbody><tr>
            <td style="height: 257px;text-align:center; ">
                <br/>     
                <br/>
                <img src="herramientas/ICONOS/SymbolStop2.png" border="0"/>
                <br/>
                <br/>
                <b  style="color:Red;font-size:medium;">No tiene permisos para esta pagina</b>
                <br/>
                <br/>
                <a href="login.aspx">
                    <img id="cerrarjpg" src="herramientas/iconos/cerrar.jpg" style="border-width:0px;"/>
                </a>
            </td>
        </tr>
    </tbody></table>
</div>
    </form>
</body>
</html>
