Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Collections.Generic
Imports System.IO

Partial Class administrador_MntPublicacion
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
    Public Property VS_idPublicacionSelect() As Integer
        Get
            Return ViewState("VS_idPublicacionSelect")
        End Get
        Set(value As Integer)
            ViewState("VS_idPublicacionSelect") = value
        End Set
    End Property

    Public Property VS_idTipoPubliSelect() As Integer
        Get
            Return ViewState("VS_idTipoPubliSelect")
        End Get
        Set(value As Integer)
            ViewState("VS_idTipoPubliSelect") = value
        End Set
    End Property

#End Region

#Region "EVENTOS"

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Session("id_cliente") = Nothing And Session("id_perfil") = Nothing Then
    '        Response.Redirect("../Login.aspx")
    '        Exit Sub
    '    End If

    '    'Solo perfil Usuario
    '    'If Session("id_perfil") <> 2 Then
    '    '    Response.Redirect("../Login.aspx")
    '    '    Exit Sub
    '    'End If

    '    If Not Page.IsPostBack Then
    '        Session("pagina") = Request.Url.Segments(Request.Url.Segments.Length - 1)

    '        'VS_idCliente = 0
    '        'VS_idPerfil = 0
    '        VS_idPublicacionSelect = 0
    '        'VS_idTipoPubliSelect = 0

    '        'VS_idPublicacionSelect = Session("idPubliSelectFoto")
    '        'VS_idTipoPubliSelect = Session("idTipoPubliSelectFoto")

    '        'VS_idCliente = Session("id_cliente")
    '        'VS_idPerfil = Session("id_perfil")

    '        'cargarCombos()            

    '    End If

    'End Sub

    'Protected Sub gvPublicacion_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvPublicacion.PageIndexChanging

    '    If Session("listaPublica") Is Nothing Then
    '        CargarPublicaciones()
    '        Exit Sub
    '    End If

    '    gvPublicacion.PageIndex = e.NewPageIndex
    '    gvPublicacion.DataSource = CType(Session("listaPublica"), List(Of PublicacionBE))
    '    gvPublicacion.DataBind()
    'End Sub

    'Protected Sub gvPublicacion_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvPublicacion.RowCommand
    '    Select Case e.CommandName
    '        Case "Eliminar"

    '            Try

    '                Dim datosBorrar() As String = e.CommandArgument.ToString.Split(New Char() {","})
    '                VS_idPublicacionSelect = CInt(datosBorrar(0))

    '                lblMsgConfirmaPubli.Text = "¿Desea eliminar la publicación?"
    '                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "openModalConfirmaPubli();", True)

    '            Catch ex As Exception

    '            End Try

    '    End Select
    'End Sub

    ''Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
    ''    btnRegistrar.Visible = True
    ''    btnActualizar.Visible = False
    ''    divFotoPubli.Visible = False
    ''    btnCancelar.Visible = False
    ''    VS_idPublicacionSelect = 0
    ''    VS_idTipoPubliSelect = 0
    ''    limpiarPublicacion()
    ''End Sub

    'Protected Sub btnConfirmaEliminar_Click(sender As Object, e As EventArgs) Handles btnConfirmaEliminar.Click
    '    Try

    '        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "Pop", "closeModalConfirmaPubli();", True)

    '        Dim oPublicacionBL As New PublicacionBL

    '        If oPublicacionBL.PublicacionEliminar(VS_idPublicacionSelect) > 0 Then
    '            MensajeOK("Publicación eliminada")

    '            VS_idPublicacionSelect = 0
    '            CargarPublicaciones()
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub ddlTipoPublicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTipoPublicacion.SelectedIndexChanged
    '    CargarPublicaciones()
    'End Sub

#End Region

#Region "MÉTODOS"

    'Sub cargarCombos()
    '    AddSeleccione(ddlTipoPublicacion)
    '    Dim oTipoPublicacionBL As New TipoPublicacionBL
    '    ddlTipoPublicacion.DataSource = Nothing
    '    ddlTipoPublicacion.DataSource = oTipoPublicacionBL.TipoPublicacionListar
    '    ddlTipoPublicacion.DataValueField = "IdTipoPublicacion"
    '    ddlTipoPublicacion.DataTextField = "TipoPublicacion"
    '    ddlTipoPublicacion.DataBind()
    'End Sub

    'Sub AddSeleccione(ByVal ddl As DropDownList)
    '    ddl.Items.Clear()
    '    ddl.AppendDataBoundItems = True
    '    Dim itemList As New ListItem With {.Text = "[ Seleccione ]", .Value = 0, .Selected = True}
    '    ddl.Items.Add(itemList)
    'End Sub

    'Sub CargarPublicaciones()

    '    Dim oPublicacionBL As New PublicacionBL
    '    Dim oPublicacionBE As New PublicacionBE

    '    Try

    '        Dim loPublicacionBE As List(Of PublicacionBE)

    '        loPublicacionBE = oPublicacionBL.PublicacionFiltrar(ddlTipoPublicacion.SelectedValue, False)

    '        gvPublicacion.DataSource = Nothing
    '        gvPublicacion.DataSource = loPublicacionBE
    '        gvPublicacion.DataBind()
    '        'MakeAccessible(gvClienteEstudio)

    '        Session("listaPublica") = Nothing
    '        Session("listaPublica") = loPublicacionBE

    '    Catch ex As Exception

    '    Finally
    '        oPublicacionBL = Nothing
    '    End Try

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
