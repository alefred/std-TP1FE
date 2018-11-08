<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CambiarFoto.aspx.vb" Inherits="frame_CambiarFoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="../css/style.css" rel="stylesheet">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body class="md-skin">
    <form id="form1" runat="server">

        <div id="wrapper">
            <div id="page-wrapper">
                <div class="wrapper wrapper-content animated fadeInRight" style="padding: 0px;">
                    <div class="row">
                        <div class="col-lg-12">

                            <div>
                                <div id="divMensajeErrorFoto" runat="server" class="alert alert-danger alert-dismissable">
                                    <strong>Mensaje :&nbsp;<asp:Label ID="lblMensajeErrorFoto" runat="server" Text=""></asp:Label></strong>
                                </div>

                            </div>
                            <div style="text-align: left; margin-bottom: 7px;">
                                <h2>Foto de perfil actual:</h2>
                                <br />
                                <asp:Image ID="imgFotoPerfil" runat="server" class="img-circle" Width="150" Height="150" />
                                <br />
                                <div class="form-group">
                                    <br />
                                    <h2>Cambiar foto de perfil</h2>
                                    <br />
                                    <asp:FileUpload ID="fupFotoPerfil" runat="server" />

                                    <br />
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="alert alert-success">
                                                <h3 >Importante : </h3>
                                                <hr />
                                                <i class="fa fa-warning"></i>&nbsp;&nbsp;Formato permitido: <b>JPG (*.jpg)</b>
                                                <br />
                                                <i class="fa fa-warning"></i>&nbsp;&nbsp;La imagen no debe exceder los 3 MB
                                                <br />
                                                <i class="fa fa-warning"></i>&nbsp;&nbsp;Dimensión recomendada : <b>150 x 150 píxeles</b>
                                            </div>
                                        </div>
                                    </div>                                  
                                </div>
                            </div>
                            <hr />
                            <div style="text-align: right;">
                                <asp:Button ID="btnActualizarFoto" runat="server" CssClass="btn btn-primary" Text="Actualizar" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

<!-- Mainly scripts -->
<script src="../js/jquery-2.1.1.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/plugins/metisMenu/jquery.metisMenu.js"></script>
<script src="../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

<!-- Custom and plugin javascript -->
<script src="../js/inspinia.js"></script>
<script src="../js/plugins/pace/pace.min.js"></script>

<!-- jQuery UI -->
<script src="../js/plugins/jquery-ui/jquery-ui.min.js"></script>

</html>
