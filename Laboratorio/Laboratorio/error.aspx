<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Laboratorio.error" %>
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
                        <h1><asp:label runat="server" ID="LBL_ERROR"> 500 Error Page </asp:label></h1>
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

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form_error" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">500 Error Page</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>--%>
