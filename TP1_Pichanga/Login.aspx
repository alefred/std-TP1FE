<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<!DOCTYPE html>

<html>


<!-- Mirrored from webapplayers.com/inspinia_admin-v1.8/login.html by HTTrack Website Copier/3.x [XR&CO'2013], Fri, 09 Jan 2015 18:09:24 GMT -->
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>GRUPO UCAL -TLS | Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

    <style type="text/css">



        body {
            background: url('Images/img_login.jpg') no-repeat center center fixed;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
        }
    </style>


</head>

<body class="gray-bg" onload="mostrarCumple()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="middle-box text-center loginscreen  animated fadeInDown">
                    <div>
                        <div>
                            <center>
                                <img src="Images/logo_login.png" class="img-responsive" />
                            </center>
                            
                            <br />
                        </div>
                        <p style="color: red; font-family: Arial; font-size: 18px;">
                            ¡Bienvenido a la web de Pichangas!
                        </p>
                        <div class="m-t" role="form">
                            <div class="form-group">
                                <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario" required></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password" required></asp:TextBox>
                            </div>
                           
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-verde" />
                             <br />
                             <hr /> 
                          </div>
                    </div>
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>

          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            <div class="form-group">
                 <center>
                             <asp:Button ID="btnNuevoRegistro" runat="server"  Text="Registrar" class="btn btn-celeste" onclic="btnNuevoRegistro_Click" formnovalidate/>
            </div>
                </center>
                </ContentTemplate>
         </asp:UpdatePanel>
  

        <!-- Flex Modal -->
        <div class="modal modal-flex fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="flexModalLabel" aria-hidden="true">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="flexModalLabel">Intranet de colaboradores</h4>
                            </div>
                            <div class="modal-body">

                                <div style="text-align: center; margin-bottom: 7px;">
                                    <i class="fa fa-exclamation-triangle text-orange" style="font-size: 5em;"></i>
                                </div>
                                <div style="text-align: center; margin-bottom: 7px;">
                                    <asp:Label ID="lblMsgAdvertencia" runat="server" Text="Label"></asp:Label><br />
                                </div>
                                <div style="text-align: right;">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                                </div>

                            </div>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <!-- Mainly scripts -->
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>

    <script>

        function openModal() {
            $('#myModal').modal('show');
        }
        function closeModal() {
            $('#myModal').modal('hide');
        }
    </script>

</body>


</html>

