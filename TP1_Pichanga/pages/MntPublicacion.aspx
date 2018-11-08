<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MntPublicacion.aspx.vb" Inherits="administrador_MntPublicacion" %>

<%@ MasterType VirtualPath="~/MasterPage/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        function openModalConfirmaPubli() {
            $('#myModalConfirmaPubli').modal('show');
        }

        function closeModalConfirmaPubli() {
            $('#myModalConfirmaPubli').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        }

        javascript: window.history.forward(1);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper white-bg page-heading">
        <div class="col-lg-12">
            <h2>Gestor de Publicaciones</h2>
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-lg-10 col-lg-offset-1">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content p-md">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <label>TIPO DE PUBLICACIÓN</label>
                                    </div>
                                    <div class="col-lg-4">
                                        <asp:DropDownList ID="ddlTipoPublicacion" runat="server" AutoPostBack="true" class="form-control" Width="200"></asp:DropDownList>
                                    </div>
                                    <div class="col-lg-6" style="text-align: right;">
                                        <a href="frmRegistroPublicacion.aspx?vModo=INS&vPubli=0" class='btn btn-primary btn-lg' style="width: 200px;">Nueva publicación</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-10 col-lg-offset-1">
                        <asp:GridView ID="gvPublicacion" runat="server" Class="table table-bordered table-green"
                            AutoGenerateColumns="false" AllowPaging="True" PageSize="5" PagerStyle-CssClass="pgr" ShowHeader="false">
                            <HeaderStyle Font-Size="X-Small" />
                            <PagerStyle CssClass="GridPager" />
                            <Columns>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-12" style="text-align: right;">
                                                <a href='<%# "frmRegistroPublicacion.aspx?vModo=UPD&vPubli=" & Eval("IdPublicacion")%>' class='btn btn-warning btn-sm'>Editar</a> &nbsp;
                                                    <asp:Button ID="btnPublicacionDelete" runat="server" Text="Eliminar" class="btn btn-danger  btn-sm"
                                                        CommandName="Eliminar" CommandArgument='<%# Eval("IdPublicacion")%>' />
                                            </div>
                                            <div class="col-lg-3">
                                                <img src='../fotos/logo_publicacion/<%# Eval("IdPublicacion")%>.jpg' style="max-width: 150px; max-height: 100px; margin-top: 10px;" />
                                            </div>
                                            <div class="col-lg-9" style="text-align: left;">
                                                <h3><%# Eval("Titulo")%></h3>
                                                <span class="small">Publicado el <%# DateTime.Parse(Eval("FechaRegistro").ToString()).ToString("d")%></span><br />
                                                <br />
                                                <%# Eval("Descripcion")%>
                                            </div>
                                            <div class="col-lg-12" style="text-align: right;">
                                                <br />
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5" />
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="modal modal-flex fade" id="myModalConfirmaPubli" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="H3">Intranet de colaboradores</h4>
                            </div>
                            <div class="modal-body">

                                <div style="text-align: center; margin-bottom: 7px;">
                                    <i class="fa fa-question-circle" style="font-size: 5em; color: #f39c12;"></i>
                                </div>
                                <div style="text-align: center; margin-bottom: 7px;">
                                    <asp:Label ID="lblMsgConfirmaPubli" runat="server" Text=""></asp:Label><br />
                                </div>
                                <div style="text-align: right;">
                                    <asp:Button ID="btnConfirmaEliminar" runat="server" class="btn btn-default" Text="Sí" />
                                    &nbsp;&nbsp;&nbsp;
                                            <button type="button" class="btn btn-gray" data-dismiss="modal">No</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

