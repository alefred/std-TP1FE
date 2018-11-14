<%@ Page Title="" Language="VB"  MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="frmRegistroUsuario.aspx.vb" Inherits="administrador_frmRegistroUsuario" %>

<%@ MasterType VirtualPath="~/MasterPage/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script>
          
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper white-bg page-heading">
        <div class="col-lg-12">
            <h2>
                <asp:Label ID="lblTitulo" runat="server" Text="Registro Nuevo Pichanguero"></asp:Label></h2>

        </div>
    </div>
<div class="wrapper wrapper-content animated fadeInRight">
<div class="row">
    <div class="col-lg-8 col-lg-offset-2" id="divFormulario" runat="server">
                <div class="ibox float-e-margins">
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
          
                        <div style="float: left; width: 350px;" >
            <div class="form-group">
             <label>Nombres</label>
            <asp:TextBox ID="txtNombres" runat="server" class="form-control" placeholder="Nombres" type="text" required="required"></asp:TextBox>                  
           </div> 
                <hr />
            <div class="form-group">
             <label>Apellido Paterno</label>
            <asp:TextBox ID="txtApellidoPat" runat="server" class="form-control" placeholder="Apellido Paterno" type="text"  required="required"></asp:TextBox> 
            </div>
                <hr />
            <div class="form-group">
             <label>Apellido Materno</label>
              <asp:TextBox ID="txtApellidoMat" runat="server" class="form-control" placeholder="Apellido Materno" type="text" required="required"></asp:TextBox>     
            </div>
                <hr />
             <div class="form-group">
             <label>Correo Electronico</label>
              <asp:TextBox ID="txtCorreo" runat="server" class="form-control" placeholder="Correo Electronico" required="required" type="email"></asp:TextBox>
              </div>
                <hr />
             <div class="form-group">
                            <label>Tipo Documento</label>
                            <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-control" Width="200" required="required">
                                <asp:ListItem Value="">[Seleccione]</asp:ListItem>
                                <asp:ListItem Value="1">DNI</asp:ListItem>
                                <asp:ListItem Value="2">RUC</asp:ListItem>
                                <asp:ListItem Value="3">PAS</asp:ListItem>
                                <asp:ListItem Value="3">OTR</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <hr />
          <div class="form-group">
             <label>Documento Identidad</label>
              <asp:TextBox ID="txtDocumento" runat="server" class="form-control" placeholder="Documento" type="number" required="required"></asp:TextBox>
             </div>
              <hr />
          <div id="divFechaIniFin" runat="server" class="form-group">
            <div id="data_1">
                            <label>Fecha de Nacimiento</label>
                <div class="input-group date">
                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" class="form-control input-sm" placeholder="Fecha Nacimiento"></asp:TextBox>
                </div>        
            </div>
              </div>
           <hr />
          <div class="form-group">
             <label>Direccion o Domicilio</label>
              <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" required="required"></asp:TextBox>
            </div>
               <hr />
           <div class="form-group">
             <label>Numero Celular</label>
              <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="Numero Celular" type="number" required="required"></asp:TextBox>
              </div>
                <hr />
                 <div class="form-group">
             <label>Nombre Usuario</label>
              <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario" required="required"></asp:TextBox>
              </div>
                <hr />
           <div class="form-group">
             <label>Contraseña</label>
              <asp:TextBox ID="txtClave" runat="server" class="form-control" placeholder="Contraseña" TextMode="Password" required="required"></asp:TextBox>
           </div>
           <br />
           <hr />  
              <div class="form-group" style="text-align: center;">
                  <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="btn btn-primary btn-lg" />

              </div>        
        
              <div class="form-group" style="text-align: center;">
                  <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Sesion" class="btn btn-primary btn-lg" formnovalidate />

              </div> 
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

