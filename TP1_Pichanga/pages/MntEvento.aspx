<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="false" CodeFile="MntEvento.aspx.vb" Inherits="administrador_MntEvento" %>

<%@ MasterType VirtualPath="~/MasterPage/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .myCalendar {
            text-transform: uppercase;
        }
    </style>

    <script>
        function openModalMntEvento() {
            $('#myModalMntEvento').modal('show');
        }

        function closeModalMntEvento() {
            $('#myModalMntEvento').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        }

        function openModalConfirmaEvento() {
            $('#myModalConfirmaEvento').modal('show');
        }

        function closeModalConfirmaEvento() {
            $('#myModalConfirmaEvento').modal('hide');
            $('body').removeClass('modal-open');
            $('.modal-backdrop').remove();
        }

        function ShowHideHoras() {

            var divHoraIniFin = document.getElementById('<%= divHoraIniFin.ClientID%>');

            if (document.getElementById('<%= chkMntTodoDia.ClientID%>').checked) {
                divHoraIniFin.style.display = 'none';
            }
            else {
                divHoraIniFin.style.display = 'block';
            }
        }

        function valida_envia() {

            var ddlMntUnidadNegocio = document.getElementById('ContentPlaceHolder1_ddlMntUnidadNegocio');
            var txtMntTitulo = document.getElementById('ContentPlaceHolder1_txtMntTitulo');
            var txtMntDesc = document.getElementById('ContentPlaceHolder1_txtMntDesc');
            var txtMntFecha = document.getElementById('ContentPlaceHolder1_txtMntFecha');

          <%--  var rbUnDia = document.getElementById('<%= rbUnDia.ClientID%>');
            var rbRangoDias = document.getElementById('<%= rbRangoDias.ClientID%>');--%>

            var txtMntFechaDesde = document.getElementById('<%= txtMntFechaDesde.ClientID%>');
            var txtMntFechaHasta = document.getElementById('<%= txtMntFechaHasta.ClientID%>');

            var divMntMensajeError = document.getElementById('ContentPlaceHolder1_divMntMensajeError');

            if (ddlMntUnidadNegocio.value == 0 || txtMntTitulo.value == '' || txtMntDesc.value == '' || (rbUnDia.checked && txtMntFecha.value == '')) {
                divMntMensajeError.style.display = 'block';
                return false;
            }

            if (ddlMntUnidadNegocio.value == 0 || txtMntTitulo.value == '' || txtMntDesc.value == '' || (rbRangoDias.checked && (txtMntFechaDesde.value == '' || txtMntFechaHasta.value == ''))) {
                divMntMensajeError.style.display = 'block';
                return false;
            }

        }

        function ShowUnDiaEvento() {
            var divDiaCompleto = document.getElementById('<%= divDiaCompleto.ClientID%>')
            divDiaCompleto.style.display = 'block';

            var divDiaIniFin = document.getElementById('<%= divDiaIniFin.ClientID%>')
            divDiaIniFin.style.display = 'none';

        }

        function ShowRangoDiasEvento() {
            var data_1 = document.getElementById('<%= divDiaCompleto.ClientID%>')
            data_1.style.display = 'none';

            var divHoraIniFin = document.getElementById('<%= divHoraIniFin.ClientID%>')
            divHoraIniFin.style.display = 'none';

            var chkMntTodoDia = document.getElementById('<%= chkMntTodoDia.ClientID%>')
            chkMntTodoDia.checked = true;

            var divDiaIniFin = document.getElementById('<%= divDiaIniFin.ClientID%>')
            divDiaIniFin.style.display = 'block';

        }

        javascript: window.history.forward(1);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row wrapper white-bg page-heading">
        <div class="col-lg-12">
            <h2>Gestor de Eventos</h2>
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-content p-md">

                                <div class="row">
                                    <div class="col-lg-5">

                                        <span><i class="fa fa-circle" style="color: #CFD337;"></i>&nbsp;Eventos</span><br />
                                        <%--<span><i class="fa fa-circle" style="color: #00B2EF;"></i>&nbsp;Cumpleaños</span>--%>
                                        <br />

                                        <asp:Calendar ID="Calendar1" OnDayRender="CalendarDRender" runat="server" BorderWidth="1px" NextPrevFormat="FullMonth" BackColor="White" Width="350px" ForeColor="Black" Height="190px" Font-Size="9pt" Font-Names="Verdana" BorderColor="White" CssClass="myCalendar">
                                            <TodayDayStyle BackColor="#CCCCCC" BorderColor="red" BorderWidth="2"></TodayDayStyle>
                                            <NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="#333333" VerticalAlign="Bottom"></NextPrevStyle>
                                            <DayHeaderStyle Font-Size="8pt" Font-Bold="True"></DayHeaderStyle>
                                            <SelectedDayStyle ForeColor="White" BackColor="#B3B3B3"></SelectedDayStyle>
                                            <TitleStyle Font-Size="12pt" Font-Bold="True" BorderWidth="4px" ForeColor="#872286" BorderColor="Transparent" BackColor="White"></TitleStyle>
                                            <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                                        </asp:Calendar>
                                        <hr />

                                    </div>

                                    <div class="col-lg-7">

                                        <div class="row">
                                            <div class="col-lg-6">
                                                Todos los eventos de :
                                                <asp:DropDownList ID="ddlUnidadNegocio" runat="server" CssClass="form-control input-sm" Width="200" AutoPostBack="true">
                                                    <asp:ListItem Value="0">[Todos]</asp:ListItem>
                                                    <asp:ListItem Value="1">TLS</asp:ListItem>
                                                    <asp:ListItem Value="2">UCAL</asp:ListItem>
                                                    <asp:ListItem Value="3">TLS/UCAL</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-6" style="text-align: right;">
                                                <asp:Button ID="btnNuevoEvento" class='btn btn-primary btn-md' runat="server" Text="NUEVO EVENTO" />
                                            </div>
                                        </div>

                                        
                                        <br />
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvEventos" runat="server" Class="table table-bordered table-hover"
                                                AutoGenerateColumns="false" AllowPaging="True" PageSize="10" PagerStyle-CssClass="pgr">
                                                <HeaderStyle Font-Size="Small" />
                                                <RowStyle Font-Size="Small" />
                                                <PagerStyle CssClass="GridPager" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnEventoVer" runat="server" class="fa fa-cog"
                                                                CommandName="Editar" CommandArgument='<%# Eval("id_evento")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" Font-Size="12" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="titulo" HeaderText="Título" />
                                                    <asp:BoundField DataField="fecha_evento" HeaderText="Fecha" />
                                                    <asp:TemplateField HeaderText="Tipo" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label63" runat="server" Text='<%# IIf(Eval("todo_dia") = True, "Todo el día", Eval("hora_inicio_time") & " a " & Eval("hora_fin_time"))%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="oUnidadNegocioBE.unidad_negocio" HeaderText="Unidad de Negocio" />
                                                    <asp:TemplateField HeaderText="Eliminar">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnEventoEliminar" runat="server" class="fa fa-times"
                                                                CommandName="Eliminar" CommandArgument='<%# Eval("id_evento")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" Font-Size="12" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>



                <div class="modal modal-flex fade" id="myModalConfirmaEvento" tabindex="-1" role="dialog" aria-hidden="true">

                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="H3">Servicio para pichangueros</h4>
                            </div>
                            <div class="modal-body">
                                <div style="text-align: center; margin-bottom: 7px;">
                                    <i class="fa fa-question-circle" style="font-size: 5em; color: #f39c12;"></i>
                                </div>
                                <div style="text-align: center; margin-bottom: 7px;">
                                    <asp:Label ID="lblMsgConfirmaDelete" runat="server" Text=""></asp:Label><br />
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
                <%----------------------------POPUP PARA MANTENIMIENTO DE EVENTOS---------------------------------%>
                <div class="modal inmodal" id="myModalMntEvento" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content animated bounceInRight">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblTituloMnt" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body" style="padding-bottom: 0px;">
                                <div class="form-group" id="divMntMensajeError" runat="server">
                                    <i>
                                        <asp:Label ID="lblMntMensajeError" runat="server" Text="Ingrese campos requeridos" ForeColor="#ff0000"></asp:Label></i>
                                </div>
                                <div class="form-group">
                                    <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Nombre del evento:</label>
                                 <asp:TextBox ID="txtNombreEvento" runat="server" CssClass="form-control"></asp:TextBox>
                                     <%--  <asp:DropDownList ID="ddlMntUnidadNegocio" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">[Seleccione]</asp:ListItem>
                                        <asp:ListItem Value="1">TLS</asp:ListItem>
                                        <asp:ListItem Value="2">UCAL</asp:ListItem>
                                        <asp:ListItem Value="3">TLS/UCAL</asp:ListItem>
                                    </asp:DropDownList>--%>
                                </div>
                                <div class="form-group">
                                    <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Mensaje de la invitación:</label>
                                    <asp:TextBox ID="txtMntTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                               <%-- <div class="form-group">
                                    <label>Descripción</label>
                                    <asp:TextBox ID="txtMntDesc" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:RadioButton ID="rbUnDia" runat="server" Text="1 día" Checked="true" GroupName="Dias" onclick="ShowUnDiaEvento()" />&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rbRangoDias" runat="server" Text="Rango de días" GroupName="Dias" onclick="ShowRangoDiasEvento()" />
                                </div>--%>
                                <div class="form-group" id="divDiaCompleto" runat="server">
                                    <div class="row" id="data_1">
                                        <div class="col-xs-6">
                                            <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Fecha</label>
                                            <div class="input-group date">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txtMntFecha" runat="server" class="form-control input-sm" placeholder="Fecha del evento"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xs-6">
                                            <label>&nbsp;</label>
                                            <div class="">
                                                <label>
                                                    <asp:CheckBox ID="chkMntTodoDia" runat="server" Checked="true" onclick="ShowHideHoras()" />
                                                    <i></i>Todo el día</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group" id="divHoraIniFin" runat="server">
                                    <div class="row">
                                        <div class="col-xs-6">
                                            <label>Hora inicio</label>
                                            <asp:DropDownList ID="ddlMntHoraInicio" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">[Seleccione]</asp:ListItem>
                                                <asp:ListItem Value="0600">06:00</asp:ListItem>
                                                <asp:ListItem Value="0630">06:30</asp:ListItem>
                                                <asp:ListItem Value="0700">07:00</asp:ListItem>
                                                <asp:ListItem Value="0730">07:30</asp:ListItem>
                                                <asp:ListItem Value="0800">08:00</asp:ListItem>
                                                <asp:ListItem Value="0830">08:30</asp:ListItem>
                                                <asp:ListItem Value="0900">09:00</asp:ListItem>
                                                <asp:ListItem Value="0930">09:30</asp:ListItem>
                                                <asp:ListItem Value="1000">10:00</asp:ListItem>
                                                <asp:ListItem Value="1030">10:30</asp:ListItem>
                                                <asp:ListItem Value="1100">11:00</asp:ListItem>
                                                <asp:ListItem Value="1130">11:30</asp:ListItem>
                                                <asp:ListItem Value="1200">12:00</asp:ListItem>
                                                <asp:ListItem Value="1230">12:30</asp:ListItem>
                                                <asp:ListItem Value="1300">13:00</asp:ListItem>
                                                <asp:ListItem Value="1330">13:30</asp:ListItem>
                                                <asp:ListItem Value="1400">14:00</asp:ListItem>
                                                <asp:ListItem Value="1430">14:30</asp:ListItem>
                                                <asp:ListItem Value="1500">15:00</asp:ListItem>
                                                <asp:ListItem Value="1530">15:30</asp:ListItem>
                                                <asp:ListItem Value="1600">16:00</asp:ListItem>
                                                <asp:ListItem Value="1630">16:30</asp:ListItem>
                                                <asp:ListItem Value="1700">17:00</asp:ListItem>
                                                <asp:ListItem Value="1730">17:30</asp:ListItem>
                                                <asp:ListItem Value="1800">18:00</asp:ListItem>
                                                <asp:ListItem Value="1830">18:30</asp:ListItem>
                                                <asp:ListItem Value="1900">19:00</asp:ListItem>
                                                <asp:ListItem Value="1930">19:30</asp:ListItem>
                                                <asp:ListItem Value="2000">20:00</asp:ListItem>
                                                <asp:ListItem Value="2030">20:30</asp:ListItem>
                                                <asp:ListItem Value="2100">21:00</asp:ListItem>
                                                <asp:ListItem Value="2130">21:30</asp:ListItem>
                                                <asp:ListItem Value="2200">22:00</asp:ListItem>
                                                <asp:ListItem Value="2230">22:30</asp:ListItem>
                                                <asp:ListItem Value="2300">23:00</asp:ListItem>
                                                <asp:ListItem Value="2330">23:30</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-xs-6">
                                            <label>Hora fin</label>
                                            <asp:DropDownList ID="ddlMntHoraFin" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">[Seleccione]</asp:ListItem>
                                                <asp:ListItem Value="0600">06:00</asp:ListItem>
                                                <asp:ListItem Value="0630">06:30</asp:ListItem>
                                                <asp:ListItem Value="0700">07:00</asp:ListItem>
                                                <asp:ListItem Value="0730">07:30</asp:ListItem>
                                                <asp:ListItem Value="0800">08:00</asp:ListItem>
                                                <asp:ListItem Value="0830">08:30</asp:ListItem>
                                                <asp:ListItem Value="0900">09:00</asp:ListItem>
                                                <asp:ListItem Value="0930">09:30</asp:ListItem>
                                                <asp:ListItem Value="1000">10:00</asp:ListItem>
                                                <asp:ListItem Value="1030">10:30</asp:ListItem>
                                                <asp:ListItem Value="1100">11:00</asp:ListItem>
                                                <asp:ListItem Value="1130">11:30</asp:ListItem>
                                                <asp:ListItem Value="1200">12:00</asp:ListItem>
                                                <asp:ListItem Value="1230">12:30</asp:ListItem>
                                                <asp:ListItem Value="1300">13:00</asp:ListItem>
                                                <asp:ListItem Value="1330">13:30</asp:ListItem>
                                                <asp:ListItem Value="1400">14:00</asp:ListItem>
                                                <asp:ListItem Value="1430">14:30</asp:ListItem>
                                                <asp:ListItem Value="1500">15:00</asp:ListItem>
                                                <asp:ListItem Value="1530">15:30</asp:ListItem>
                                                <asp:ListItem Value="1600">16:00</asp:ListItem>
                                                <asp:ListItem Value="1630">16:30</asp:ListItem>
                                                <asp:ListItem Value="1700">17:00</asp:ListItem>
                                                <asp:ListItem Value="1730">17:30</asp:ListItem>
                                                <asp:ListItem Value="1800">18:00</asp:ListItem>
                                                <asp:ListItem Value="1830">18:30</asp:ListItem>
                                                <asp:ListItem Value="1900">19:00</asp:ListItem>
                                                <asp:ListItem Value="1930">19:30</asp:ListItem>
                                                <asp:ListItem Value="2000">20:00</asp:ListItem>
                                                <asp:ListItem Value="2030">20:30</asp:ListItem>
                                                <asp:ListItem Value="2100">21:00</asp:ListItem>
                                                <asp:ListItem Value="2130">21:30</asp:ListItem>
                                                <asp:ListItem Value="2200">22:00</asp:ListItem>
                                                <asp:ListItem Value="2230">22:30</asp:ListItem>
                                                <asp:ListItem Value="2300">23:00</asp:ListItem>
                                                <asp:ListItem Value="2330">23:30</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group" id="divDiaIniFin" runat="server">
                                    <div class="row" id="data_2">
                                        <div class="col-xs-6">
                                            <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Fecha inicio</label>
                                            <div class="input-group date">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txtMntFechaDesde" runat="server" class="form-control input-sm" placeholder="Fecha inicio"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-xs-6">
                                            <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Fecha fin</label>
                                            <div class="input-group date">
                                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                                <asp:TextBox ID="txtMntFechaHasta" runat="server" class="form-control input-sm" placeholder="Fecha fin"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                  <label style="color: #ff0000;">(*)</label>&nbsp;&nbsp;<label>Lugar:</label>
                                                    
                                 <asp:DropDownList ID="ddlMntUnidadNegocio" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">[Seleccione]</asp:ListItem>
                                        <asp:ListItem Value="1">CANCHITAS VIP</asp:ListItem>
                                        <asp:ListItem Value="2">VILLA SPORT LOS PRECURSORES</asp:ListItem>
                                        <asp:ListItem Value="3">CENTENARIO FC</asp:ListItem>
                                        <asp:ListItem Value="4">COMPLEJO DEPORTIVO LA 9 </asp:ListItem>
                                        <asp:ListItem Value="5">FORZA FUBTOL </asp:ListItem>
                                        <asp:ListItem Value="6">DESPELOTE FC</asp:ListItem>
                                    </asp:DropDownList>
                                  <div style="text-align: right;">
                                    <i>
                                        <label>(*) : Campos requeridos</label></i>
                                </div>
                               <p>
                                <asp:Button ID="btnContactos" runat="server" CssClass="btn btn-default" Text="Seleccionar mis convocados" OnClick="btnContactos_Click" Width="100%" />
                                 </p>
                                     <%---------------------------------------  Lista de contactos -----------------------------------%>
                         
                                <div class="table">
                                      <div style="text-align: left;">
                                    <i>
                                        <label> CONTACTOS DISPONIBLES:</label></i>
                                </div>
                                <div class="ancho">
                                    <asp:GridView ID="grvDetContactos" runat="server" Class="table table-bordered table-hover"
                                    AutoGenerateColumns ="false" AllowPaging="True" PageSize="10" PagerStyle-CssClass="pgr"
                                        OnRowDeleting="grvDetDetContactos_RowDeleting">
                                        
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID" />
                                            <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                            <asp:BoundField DataField="AP_PATERNO" HeaderText="AP_PATERNO" />
                                            <asp:BoundField DataField="AP_MATERNO" HeaderText="AP_MATERNO" />
                                            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" />
                                           <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:CheckBox ID="chkDPVDescuento" runat="server" Checked='<%# Eval("DESCUENTO") %>' />
                                                </ItemTemplate>
                                                <HeaderTemplate>
                                                    <label>DSCTO</label>&nbsp;
                                                    <asp:CheckBox ID="chkHeader" ToolTip="Selecciona tus convocados" runat="server"
                                                        onclick="changeAllCheckBoxes(this)"/>
                                                </HeaderTemplate>
                                            </asp:TemplateField>  --%>                                              
                                             <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDetalleDel" CommandName="Delete" runat="server" 
                                                        ImageUrl="~/Images/ico-bin.png" OnClientClick="if(!confirm('¿Desea eliminar al pichanguero?')){return false;}"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                             <%------------------------------------------------------------------------------------------%>

                            </div>
                        
                            <div class="modal-footer">
                                <div class="row">
                                    <div class="col-xs-6">
                                        <asp:Button ID="btnMntRegistrar" runat="server" CssClass="btn btn-default" Text="Registrar" OnClientClick="return valida_envia();" Width="100%" />
                                        <asp:Button ID="btnMntActualizar" runat="server" CssClass="btn btn-default" Text="Actualizar" OnClientClick="return valida_envia();" Width="100%" />
                                    </div>
                                    <div class="col-xs-6" style="text-align: left;">
                                        <button type="button" class="btn btn-gray" data-dismiss="modal" style="width: 100%;">Cancelar</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>


    </div>

</asp:Content>

