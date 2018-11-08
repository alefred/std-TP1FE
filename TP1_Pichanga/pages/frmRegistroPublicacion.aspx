<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="frmRegistroPublicacion.aspx.vb" Inherits="administrador_frmRegistroPublicacion" %>

<%@ MasterType VirtualPath="~/MasterPage/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
        function ShowHideHoras() {

            var divFechaIniFin = document.getElementById('<%= divFechaIniFin.ClientID%>');

            if (document.getElementById('<%= chkPermanente.ClientID%>').checked) {
                divFechaIniFin.style.display = 'none';
            }
            else {
                divFechaIniFin.style.display = 'block';
            }
        }

        function valida_envia() {

            var divMntMensajeError = document.getElementById('ContentPlaceHolder1_divMntMensajeError');
            var txtFechaInicio = document.getElementById('<%= txtFechaInicio.ClientID%>');
            var txtFechaFin = document.getElementById('<%= txtFechaFin.ClientID%>');

            if (document.getElementById('<%= chkPermanente.ClientID%>').checked == false && (txtFechaInicio.value == '' || txtFechaFin.value == '')) {
                divMntMensajeError.style.display = 'block';
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper white-bg page-heading">
        <div class="col-lg-12">
            <h2>
                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h2>

        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">

            <div class="col-lg-8 col-lg-offset-2" id="divMensajeSinPermiso" runat="server">
                <div class="form-horizontal">
                    <div class="row">
                        <div class="col-lg-12">

                            <div class="alert alert-danger alert-dismissable" style="text-align: center; font-size: 16px;">

                                <div class="form-group">
                                    <div class="col-sm-12">
                                        <ul class="list-inline">
                                            <li>
                                                <div style="text-align: left;">
                                                    <br />
                                                    <label class="text-red" style="font-size: 2em; font-family: Arial; font-weight: lighter;">Acceso denegado</label>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


            <div class="col-lg-8 col-lg-offset-2" id="divFormulario" runat="server">
                <div class="ibox float-e-margins">
                    <div class="ibox-content p-md">

                        <div class="row" id="divMensajeError" runat="server">
                            <div class="col-lg-12">
                                <div class="alert alert-danger alert-dismissable">
                                    <strong>Mensaje : </strong>
                                    <asp:Label ID="lblMensajeError" runat="server" Text="Mensaje Error"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row" id="divMensajeOK" runat="server">
                            <div class="col-lg-12">
                                <div class="alert alert-success alert-dismissable" style="text-align: center; font-size: 16px;">
                                    <i class="fa fa-check-circle text-green" style="font-size: 4em;"></i>
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMensajeOK" runat="server" Text="Mensaje OK"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Unidad de negocio</label>
                            <asp:DropDownList ID="ddlUnidadNegocio" runat="server" CssClass="form-control" Width="200" required>
                                <asp:ListItem Value="">[Seleccione]</asp:ListItem>
                                <asp:ListItem Value="1">TLS</asp:ListItem>
                                <asp:ListItem Value="2">UCAL</asp:ListItem>
                                <asp:ListItem Value="3">TLS/UCAL</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <hr />

                        <div class="form-group">
                            <label>Tipo de publicación</label>
                            <asp:DropDownList ID="ddlTipoPublicacion" runat="server" CssClass="form-control input-sm" Width="200" required>
                                <asp:ListItem Value="">[Seleccione]</asp:ListItem>
                                <asp:ListItem Value="1">Noticia</asp:ListItem>
                                <asp:ListItem Value="2">Beneficio</asp:ListItem>
                                <asp:ListItem Value="3">Galería de fotos</asp:ListItem>
                                <asp:ListItem Value="4">Galería de videos</asp:ListItem>
                                <asp:ListItem Value="5">Menú de la semana</asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <div class="form-group">
                            <label>Título</label>
                            <asp:TextBox ID="txtTitulo" runat="server" class="form-control input-sm" placeholder="Título" MaxLength="200" required></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Descripción</label>
                            <textarea id="txtDescripcion" runat="server" class="form-control input-sm" maxlength="5000" rows="15" placeholder="Contenido"></textarea>
                        </div>
                        <div class="form-group" id="divLink" runat="server">
                            <label>Link</label>
                            <asp:TextBox ID="txtLink" runat="server" class="form-control input-sm" placeholder="Link" MaxLength="200"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Vigencia</label>
                            <div class="">
                                <label>
                                    <asp:CheckBox ID="chkPermanente" runat="server" Checked="true" onclick="ShowHideHoras()" />
                                    <i></i>Permanente</label>
                            </div>
                            <div class="form-group" id="divMntMensajeError" runat="server">
                                <i>
                                    <asp:Label ID="lblMntMensajeError" runat="server" Text="Ingrese la fecha de inicio y fin de vigencia" ForeColor="#ff0000"></asp:Label></i>
                            </div>
                        </div>
                        <div id="divFechaIniFin" runat="server" class="form-group">
                            <div id="data_1">
                                <div class="col-sm-6">
                                    <label>Fecha de inicio</label>
                                    <div class="input-group date">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                        <asp:TextBox ID="txtFechaInicio" runat="server" class="form-control input-sm" placeholder="Fecha inicio"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="data_1">
                                <div class="col-sm-6">
                                    <label>Fecha fin</label>
                                    <div class="input-group date">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                        <asp:TextBox ID="txtFechaFin" runat="server" class="form-control input-sm" placeholder="Fecha fin"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <hr />
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6 col-sm-12">
                                    <h2>Foto actual:</h2>
                                    <asp:Image ID="imgLogoPublicacion" runat="server" ImageUrl="../fotos/logo_publicacion/sin_logo.jpg" Style="max-width: 250px;" />
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12">
                                    <h2>&nbsp;</h2>
                                    <div class="alert alert-warning">
                                        <h3>Importante : </h3>
                                        <hr />
                                        <i class="fa fa-warning"></i>&nbsp;&nbsp;Formato permitido: <b>JPG (*.jpg)</b><br />
                                        <br />
                                        <i class="fa fa-warning"></i>&nbsp;&nbsp;La imagen no debe exceder de 1 MB
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <label>Cargar foto</label>
                            <asp:FileUpload ID="fupFotoPubli" runat="server" />
                        </div>
                        <hr />
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-6 col-sm-12">
                                    <h2>Adjuntar documento </h2>
                                    <asp:Image ID="imgLogoDocumento" runat="server" ImageUrl="../Images/sin_logo_file.jpg" Style="max-width: 200px;" />
                                    <a id="btnArchivoPubli" class="btn btn-success" runat="server"><i class="fa fa-download"></i>&nbsp;&nbsp;Descargar documento</a>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12">
                                    <h2>&nbsp;</h2>
                                    <div class="alert alert-warning">
                                        <h3>Importante : </h3>
                                        <hr />
                                        <i class="fa fa-warning"></i>&nbsp;&nbsp;El documento no debe exceder los 3 MB
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="form-group">
                            <label>Cargar archivo</label>
                            <asp:FileUpload ID="fupArchivoPubli" runat="server" />
                        </div>
                        <hr />
                        <div class="form-group">
                            <asp:CheckBox ID="chkActivo" runat="server" class="input-lg" Text="&nbsp;&nbsp;&nbsp;Activo" />
                        </div>
                        <div class="form-group" style="text-align: center;">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-primary btn-lg" OnClientClick="return valida_envia();" />
                            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="btn btn-primary btn-lg" OnClientClick="return valida_envia();" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

