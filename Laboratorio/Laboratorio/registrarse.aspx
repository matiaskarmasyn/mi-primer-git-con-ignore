<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarse.aspx.cs" Inherits="Laboratorio.registrarse" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>LasTonasBeach | Registration Page</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link href="herramientas/CSS/all.min.css" rel="stylesheet" />

    <!-- icheck bootstrap -->
    <link href="herramientas/PLUGINS/icheck-bootstrap.min.css" rel="stylesheet" />
    <!-- Theme style -->
    <link href="herramientas/CSS/adminlte.min.css" rel="stylesheet" />
</head>
<body class="hold-transition register-page">
    <div class="register-box">
        <div class="register-logo">
            <a href="#"><b>Laboratorio</b>LasTonasBeach</a>
        </div>
        <div class="card">
            <div class="card-body register-card-body">
                <p class="login-box-msg">Alta Nuevo Usuario</p>
                <form action="#" method="post" runat="server">
                 
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_NOMBRE" CssClass="form-control" placeholder="Ingrese Nombre" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-user"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_APELLIDO" CssClass="form-control" placeholder="Ingrese Apellido" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-user"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_EMAIL" CssClass="form-control" placeholder="Ingrese Email" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_DNI" CssClass="form-control" placeholder="Ingrese DNI" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_PASSWORD" CssClass="form-control" placeholder="Ingrese Contraseña" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="DDL_Rol" CssClass="form-control" runat="server">
                            <asp:ListItem Text="selecciones Nivel de usuario" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Jefe de Proyecto" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Protocolo" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Estadisitca" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-8">
                            <div class="icheck-primary">
                                <asp:CheckBox ID="CHK_ACEPTARTERMINOS" runat="server" Text=" Acepto todo sin leer" />
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class="col-4">
                            <asp:Button ID="btn_registrar" CssClass="btn btn-primary btn-block" runat="server" Text="Registrar" OnClick="btn_registrar_Click" OnClientClick="return validar()" />

                        </div>
                        <!-- /.col -->
                    </div>
                    <div class="modal fade" id="MODAL_USUARIOCREADO"
                        tabindex="-1"
                        role="dialog"
                        aria-labelledby="exampleModalCenterTitle"
                        aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLongTitle">Laboratorio LasTonasBeach</h5>
                                    
                                    
                                </div>
                                <div class="modal-body">
                                    Usuario Creado Con Exito
                                </div>
                                <div class="modal-footer">
                                  <asp:Button ID="BTN_ACEPTAR" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="BTN_ACEPTAR_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                <!-- jQuery -->
                <script src="herramientas/JS/jquery.min.js"></script>

                <!-- Bootstrap 4 -->
                <script src="herramientas/JS/bootstrap.bundle.min.js"></script>

                <!-- AdminLTE App -->
                <script src="herramientas/JS/adminlte.min.js"></script>
                </form>
                <asp:HyperLink ID="yaestoyregistradolink" href="login.aspx" CssClass="text-center" runat="server">Ya estoy Registrado</asp:HyperLink>

            </div>
            <!-- /.form-box -->
        </div>
        <!-- /.card -->
    </div>
    <!-- /.register-box -->


</body>
</html>
