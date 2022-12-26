<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Laboratorio.inicio" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Inicio</title>

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <link href="herramientas/CSS/all.min.css" rel="stylesheet" />

    <link href="herramientas/CSS/adminlte.min.css" rel="stylesheet" />
    <script nonce="10f3c618-2b50-4c16-96f3-1cbdfaf51fd3">(function (w, d) { !function (a, e, t, r) { a.zarazData = a.zarazData || {}; a.zarazData.executed = []; a.zaraz = { deferred: [] }; a.zaraz.q = []; a.zaraz._f = function (e) { return function () { var t = Array.prototype.slice.call(arguments); a.zaraz.q.push({ m: e, a: t }) } }; for (const e of ["track", "set", "ecommerce", "debug"]) a.zaraz[e] = a.zaraz._f(e); a.zaraz.init = () => { var t = e.getElementsByTagName(r)[0], z = e.createElement(r), n = e.getElementsByTagName("title")[0]; n && (a.zarazData.t = e.getElementsByTagName("title")[0].text); a.zarazData.x = Math.random(); a.zarazData.w = a.screen.width; a.zarazData.h = a.screen.height; a.zarazData.j = a.innerHeight; a.zarazData.e = a.innerWidth; a.zarazData.l = a.location.href; a.zarazData.r = e.referrer; a.zarazData.k = a.screen.colorDepth; a.zarazData.n = e.characterSet; a.zarazData.o = (new Date).getTimezoneOffset(); a.zarazData.q = []; for (; a.zaraz.q.length;) { const e = a.zaraz.q.shift(); a.zarazData.q.push(e) } z.defer = !0; for (const e of [localStorage, sessionStorage]) Object.keys(e || {}).filter((a => a.startsWith("_zaraz_"))).forEach((t => { try { a.zarazData["z_" + t.slice(7)] = JSON.parse(e.getItem(t)) } catch { a.zarazData["z_" + t.slice(7)] = e.getItem(t) } })); z.referrerPolicy = "origin"; z.src = "/cdn-cgi/zaraz/s.js?z=" + btoa(encodeURIComponent(JSON.stringify(a.zarazData))); t.parentNode.insertBefore(z, t) };["complete", "interactive"].includes(e.readyState) ? zaraz.init() : a.addEventListener("DOMContentLoaded", zaraz.init) }(w, d, 0, "script"); })(window, document);</script>
</head>
<body class="hold-transition sidebar-mini">

    <div class="wrapper">

        <nav class="main-header navbar navbar-expand navbar-white navbar-light">

            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                </li>
                <li class="nav-item d-none d-sm-inline-block">
                    <a href="laboratorio.aspx" class="nav-link">Laboratorio</a>
                </li>
                <li class="nav-item d-none d-sm-inline-block">
                    <a href="#" class="nav-link">Estadisticas</a>
                </li>
            </ul>
        </nav>


        <aside class="main-sidebar sidebar-dark-primary elevation-4">

            <a href="login.aspx" class="brand-link">
                <img src="herramientas/iconos/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3" style="opacity: .8">
                <span class="brand-text font-weight-light">AdminLTE 3</span>
            </a>

            <div class="sidebar">

                <div class="user-panel mt-3 pb-3 mb-3 d-flex">
                    <div class="image">
                        <img src="herramientas/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
                    </div>
                    <div class="info">
                        <a href="#" class="d-block">Matias Karmasyn</a>
                    </div>
                </div>

                <div class="form-inline">
                    <div class="input-group" data-widget="sidebar-search">
                        <input class="form-control form-control-sidebar" type="search" placeholder="Search" aria-label="Search">
                        <div class="input-group-append">
                            <button class="btn btn-sidebar">
                                <i class="fas fa-search fa-fw"></i>
                            </button>
                        </div>
                    </div>
                </div>

                <nav class="mt-2">
                    <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                        <li class="nav-item">
                            <a href="laboratorio.aspx" class="nav-link">
                                <i class="nav-icon fas fa-tachometer-alt"></i>
                                <p>
                                    Labo Tonas Beach
                                    <i class="right fas fa-angle-left"></i>
                                </p>
                            </a>
                            <%-- <ul class="nav nav-treeview">
                                <li class="nav-item">
                                    <a href="laboratorio.aspx" class="nav-link">
                                        <i class="far fa-circle nav-icon"></i>
                                        <p>TonasBeach</p>
                                    </a>--%>
                            <ul class="nav nav-treeview">
                                <li class="nav-item">
                                    <a href="login.aspx" class="nav-link">
                                        <i class="far fa-circle nav-icon"></i>
                                        <p>Login</p>
                                    </a>
                                </li>
                            </ul>
                            <%--  </li>
                            </ul>--%>
                        </li>
                    </ul>
                </nav>

            </div>

        </aside>

        <div class="content-wrapper">

            <section class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-6">
                            <h1>Blank Page</h1>
                        </div>

                    </div>
                </div>

            </section>

        </div>

        <footer class="main-footer">
            <div class="float-right d-none d-sm-block">
                <b>Version</b> 1.0.0
            </div>
            <strong>Copyright &copy; Insanos Developer Team</strong> All rights reserved.
        </footer>

        <aside class="control-sidebar control-sidebar-dark">
        </aside>

    </div>


    <script src="herramientas/JS/jquery.min.js"></script>

    <script src="herramientas/JS/bootstrap.bundle.js"></script>

    <script src="herramientas/JS/adminlte.min.js"></script>

    <script src="herramientas/JS/demo.js"></script>
</body>
</html>

