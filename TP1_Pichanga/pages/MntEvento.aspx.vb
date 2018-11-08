Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data

Partial Class administrador_MntEvento
    Inherits System.Web.UI.Page

#Region "PROPIEDADES"
    Public Property VS_idCliente() As Integer
        Get
            Return ViewState("VS_idCliente")
        End Get
        Set(value As Integer)
            ViewState("VS_idCliente") = value
        End Set
    End Property

    Public Property VS_idPerfil() As Integer
        Get
            Return ViewState("VS_idPerfil")
        End Get
        Set(value As Integer)
            ViewState("VS_idPerfil") = value
        End Set
    End Property
    Public Property VS_idEventoSelect() As Integer
        Get
            Return ViewState("VS_idEventoSelect")
        End Get
        Set(value As Integer)
            ViewState("VS_idEventoSelect") = value
        End Set
    End Property
    Public Property VS_ModoMnt() As String
        Get
            Return ViewState("VS_ModoMnt")
        End Get
        Set(value As String)
            ViewState("VS_ModoMnt") = value
        End Set
    End Property
#End Region

#Region "EVENTOS"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Session("id_cliente") = Nothing And Session("id_perfil") = Nothing Then
        '    Response.Redirect("../Login.aspx")
        '    Exit Sub
        'End If

        'Solo perfil Usuario
        'If Session("id_perfil") <> 2 Then
        '    Response.Redirect("../Login.aspx")
        '    Exit Sub
        'End If

        If Not Page.IsPostBack Then
            VS_idCliente = 0
            VS_idPerfil = 0
            VS_idCliente = Session("id_cliente")
            VS_idPerfil = Session("id_perfil")

            Session("pagina") = Request.Url.Segments(Request.Url.Segments.Length - 1)
            VS_ModoMnt = ""
            'ListarEventos(0, "")

            divMntMensajeError.Style.Add("display", "none")
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "registrarDatePicker();registrarICheck();", True)
    End Sub

    'Protected Sub ddlUnidadNegocio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnidadNegocio.SelectedIndexChanged
    '    ListarEventos(ddlUnidadNegocio.SelectedValue, "")
    'End Sub

    'Protected Sub gvEventos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvEventos.RowCommand
    '    Select Case e.CommandName
    '        Case "Eliminar"

    '             Try

    '                Dim datosBorrar() As String = e.CommandArgument.ToString.Split(New Char() {","})
    '                VS_idEventoSelect = CInt(datosBorrar(0))

    '                lblMsgConfirmaDelete.Text = "¿Desea eliminar el evento?"
    '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "openModalConfirmaEvento();", True)

    '            Catch ex As Exception

    '            End Try

    '        Case "Editar"

    '            Try

    '                limpiarFormulario()

    '                VS_ModoMnt = "UPD"
    '                btnMntRegistrar.Visible = False
    '                btnMntActualizar.Visible = True

    '                Dim datosEditar() As String = e.CommandArgument.ToString.Split(New Char() {","})
    '                VS_idEventoSelect = CInt(datosEditar(0))

    '                lblTituloMnt.Text = "Actualización de evento"
    '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "openModalMntEvento();", True)

    '                Dim oEventoBL As New EventoBL
    '                Dim oEventoBE As New EventoBE

    '                oEventoBE = oEventoBL.EventoObtener(VS_idEventoSelect)

    '                If oEventoBE Is Nothing Then
    '                    Exit Sub
    '                End If

    '                'ddlMntUnidadNegocio.SelectedValue = oEventoBE.oUnidadNegocioBE.id_unidad_negocio
    '                txtMntTitulo.Text = oEventoBE.titulo
    '                txtMntDesc.Text = oEventoBE.descripcion


    '                If oEventoBE.rango_dias Then
    '                    rbRangoDias.Checked = True
    '                    divDiaIniFin.Style.Add("display", "block")
    '                    divDiaCompleto.Style.Add("display", "none")
    '                    txtMntFechaDesde.Text = oEventoBE.fecha_ini
    '                    txtMntFechaHasta.Text = oEventoBE.fecha_fin
    '                Else
    '                    txtMntFecha.Text = oEventoBE.fecha_evento
    '                    chkMntTodoDia.Checked = oEventoBE.todo_dia
    '                    If oEventoBE.todo_dia Then
    '                        ddlMntHoraInicio.SelectedValue = ""
    '                        ddlMntHoraFin.SelectedValue = ""
    '                        divHoraIniFin.Style.Add("display", "none")
    '                    Else
    '                        divHoraIniFin.Style.Add("display", "block")
    '                        ddlMntHoraInicio.SelectedValue = oEventoBE.hora_inicio
    '                        ddlMntHoraFin.SelectedValue = oEventoBE.hora_fin
    '                    End If
    '                End If

    '            Catch ex As Exception
    '                limpiarFormulario()
    '            End Try

    '    End Select
    'End Sub

    Protected Sub btnNuevoEvento_Click(sender As Object, e As EventArgs) Handles btnNuevoEvento.Click
        lblTituloMnt.Text = "Nuevo evento"
        VS_ModoMnt = "INS"
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "openModalMntEvento();", True)
        'rbUnDia.Checked = True
        'divDiaCompleto.Style.Add("display", "block")
        'divDiaIniFin.Style.Add("display", "none")
        btnMntRegistrar.Visible = True
        btnMntActualizar.Visible = False
        limpiarFormulario()
    End Sub

    'Protected Sub btnConfirmaEliminar_Click(sender As Object, e As EventArgs) Handles btnConfirmaEliminar.Click
    '    Try

    '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "closeModalConfirmaEvento();", True)

    '        Dim oEventoBL As New EventoBL

    '        If oEventoBL.EventoEliminar(VS_idEventoSelect) > 0 Then
    '            MensajeOK("Evento eliminado")

    '            VS_idEventoSelect = 0
    '            ddlUnidadNegocio_SelectedIndexChanged(Nothing, EventArgs.Empty)
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnMntActualizar_Click(sender As Object, e As EventArgs) Handles btnMntActualizar.Click

    '    If VS_idCliente = 0 Then
    '        Exit Sub
    '    End If

    '    Try

    '        Dim oEventoBL As New EventoBL
    '        Dim oEventoBE As New EventoBE

    '        oEventoBE.id_evento = VS_idEventoSelect
    '        'oEventoBE.oUnidadNegocioBE.id_unidad_negocio = ddlMntUnidadNegocio.SelectedValue
    '        oEventoBE.titulo = txtMntTitulo.Text.Trim
    '        oEventoBE.descripcion = txtMntDesc.Text.Trim

    '        If rbUnDia.Checked Then
    '            oEventoBE.fecha_evento = txtMntFecha.Text.Trim
    '            oEventoBE.todo_dia = chkMntTodoDia.Checked
    '            If Not chkMntTodoDia.Checked Then
    '                oEventoBE.hora_inicio = ddlMntHoraInicio.SelectedValue
    '                oEventoBE.hora_fin = ddlMntHoraFin.SelectedValue
    '            End If
    '        End If

    '        If rbRangoDias.Checked Then
    '            oEventoBE.rango_dias = rbRangoDias.Checked
    '            oEventoBE.fecha_ini = txtMntFechaDesde.Text
    '            oEventoBE.fecha_fin = txtMntFechaHasta.Text
    '        End If

    '        If oEventoBL.EventoActualizar(oEventoBE) > 0 Then
    '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "closeModalMntEvento();", True)
    '            MensajeOK("Evento actualizado")
    '            VS_idEventoSelect = 0
    '            ddlUnidadNegocio_SelectedIndexChanged(Nothing, EventArgs.Empty)
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Protected Sub btnMntRegistrar_Click(sender As Object, e As EventArgs) Handles btnMntRegistrar.Click

    '    If VS_idCliente = 0 Then
    '        Exit Sub
    '    End If

    '    Try
    '        Dim oEventoBL As New EventoBL
    '        Dim oEventoBE As New EventoBE

    '        'oEventoBE.oUnidadNegocioBE.id_unidad_negocio = ddlMntUnidadNegocio.SelectedValue
    '        oEventoBE.titulo = txtMntTitulo.Text.Trim
    '        oEventoBE.descripcion = txtMntDesc.Text.Trim

    '        If rbUnDia.Checked Then
    '            oEventoBE.fecha_evento = txtMntFecha.Text.Trim
    '            oEventoBE.todo_dia = chkMntTodoDia.Checked
    '            If Not chkMntTodoDia.Checked Then
    '                oEventoBE.hora_inicio = ddlMntHoraInicio.SelectedValue
    '                oEventoBE.hora_fin = ddlMntHoraFin.SelectedValue
    '            End If
    '        End If

    '        If rbRangoDias.Checked Then
    '            oEventoBE.rango_dias = rbRangoDias.Checked
    '            oEventoBE.fecha_ini = txtMntFechaDesde.Text
    '            oEventoBE.fecha_fin = txtMntFechaHasta.Text
    '        End If

    '        If oEventoBL.EventoRegistrar(oEventoBE) > 0 Then
    '            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "closeModalMntEvento();", True)
    '            MensajeOK("Evento registrado")
    '            VS_idEventoSelect = 0
    '            ddlUnidadNegocio_SelectedIndexChanged(Nothing, EventArgs.Empty)
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

#End Region

#Region "MÉTODOS"

    Sub limpiarFormulario()
        ddlMntUnidadNegocio.SelectedValue = 0
        txtMntTitulo.Text = ""
        txtMntDesc.Text = ""
        txtMntFecha.Text = ""
        txtMntFechaDesde.Text = ""
        txtMntFechaHasta.Text = ""

        ddlMntHoraInicio.SelectedValue = ""
        ddlMntHoraFin.SelectedValue = ""

        divDiaCompleto.Style.Add("display", "block")
        divHoraIniFin.Style.Add("display", "none")
        divDiaIniFin.Style.Add("display", "none")

        rbUnDia.Checked = True
        chkMntTodoDia.Checked = True
    End Sub

    Protected Sub CalendarDRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs)

        'Dim ds As New DataSet
        'Dim oReportesBL As New EventoBL

        'ds = oReportesBL.EventoFiltrar(3)

        ''If the month is CurrentMonth
        'If Not e.Day.IsOtherMonth Then
        '    Dim dr As DataRow
        '    For Each dr In ds.Tables(0).Rows
        '        'If EventDate is not Null
        '        If Not dr("fecha_evento") Is DBNull.Value Then
        '            Dim dtEvent As DateTime = dr("fecha_evento").ToString

        '            'If EventDate =CalendarDate
        '            If dtEvent.Equals(e.Day.Date) Then
        '                If dr("id_evento") > 0 Then
        '                    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFD337")   'Evento
        '                    'Else
        '                    '    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff") 'Cumpleaños
        '                End If

        '            End If

        '            'Rango de evento
        '            If dr("rango_dias") And (e.Day.Date >= dr("fecha_ini") And e.Day.Date <= dr("fecha_fin")) Then
        '                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#CFD337")   'Evento
        '            End If

        '        End If
        '    Next
        '    'If the month is not CurrentMonth then hide the Dates
        'Else
        '    e.Cell.Text = ""
        'End If
    End Sub

    'Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
    '    ListarEventos(0, Calendar1.SelectedDate.ToString)
    '    ddlUnidadNegocio.SelectedValue = 0
    'End Sub

    'Sub ListarEventos(ByVal id_unidad_negocio As Integer, ByVal fecha As String)
    '    Dim oEventoBL As New EventoBL
    '    Dim loEventoBE As List(Of EventoBE)

    '    loEventoBE = oEventoBL.EventoFiltrarAdm(id_unidad_negocio, fecha)

    '    gvEventos.DataSource = Nothing
    '    gvEventos.DataSource = loEventoBE
    '    gvEventos.DataBind()
    '    'MakeAccessible(gvMOF)

    '    Session("listaEventos") = Nothing
    '    Session("listaEventos") = loEventoBE
    'End Sub


    'Public Sub MensajeOK(ByVal mensaje As String)
    '    Master.LabelMsgOK = mensaje
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalOK();", True)
    'End Sub
    'Public Sub MensajeAdvertencia(ByVal mensaje As String)
    '    Master.LabelMsgAdvertencia = mensaje
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalAdvertencia();", True)
    'End Sub
    'Public Sub MensajeError(ByVal mensaje As String)
    '    Master.LabelMsgError = mensaje
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalError();", True)
    'End Sub

#End Region


End Class
