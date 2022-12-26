<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Laboratorio.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>LasTonasBeach</title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link href="herramientas/CSS/all.min.css" rel="stylesheet" />

    <!-- icheck bootstrap -->
    <link href="herramientas/CSS/icheck-bootstrap.min.css" rel="stylesheet" />

    <!-- Theme style -->
    <link href="herramientas/CSS/adminlte.min.css" rel="stylesheet" />

</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <a href="#"><b>Laboratorio</b>TonasBeach</a>
        </div>
        <!-- /.login-logo -->
        <div class="card">
            <div class="card-body login-card-body">
                <p class="login-box-msg">Ingrese E-mail y Contraseña</p>
                <form id="WebForm1" runat="server">
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_EMAIL" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="TXT_PASSWORD" CssClass="form-control" placeholder="Password" TextMode="Password" 
                            runat="server"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-8">
                        </div>
                        <!-- /.col -->
                        <div class="col-4">
                            <asp:Button ID="BTN_INGRESAR" runat="server" Text="INGRESAR"
                                CssClass="btn btn-primary btn-block" OnClientClick="return validar()"
                                OnClick="BTN_INGRESAR_Click" />
                        </div>
                        <!-- /.col -->
                    </div>
                </form>
                 <asp:HyperLink ID="registrarselink" href="registrarse.aspx" CssClass="text-center" runat="server">Registrarme</asp:HyperLink>
                <!-- /.social-auth-links -->
            </div>
            <!-- /.login-card-body -->
        </div>
    </div>
  <div class="modal" id="loginerror">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
          <span aria-hidden="true"></span>
        </button>
      </div>
      <div class="modal-body">
        <p>Modal body text goes here.</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary">Save changes</button>
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
    <!-- /.login-box -->
    <!-- jQuery -->
    <script src="herramientas/JS/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="herramientas/JS/bootstrap.bundle.js"></script>
    <!-- AdminLTE App -->
    <script src="herramientas/JS/adminlte.min.js"></script>
    <script src="Js/validadores.js" type="text/javascript"></script>
</body>
</html>
