Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Collections.Generic
Imports System.IO

Partial Class administrador_frmRegistroPublicacion
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
    Public Property VS_idPublicacion() As Integer
        Get
            Return ViewState("VS_idPublicacion")
        End Get
        Set(value As Integer)
            ViewState("VS_idPublicacion") = value
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
    Public Property VS_Modo() As String
        Get
            Return ViewState("VS_Modo")
        End Get
        Set(value As String)
            ViewState("VS_Modo") = value
        End Set
    End Property
    Public Property VS_ExtensionFile() As String
        Get
            Return ViewState("VS_ExtensionFile")
        End Get
        Set(value As String)
            ViewState("VS_ExtensionFile") = value
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
    '        VS_idCliente = 0
    '        VS_idCliente = Session("id_cliente")
    '        VS_ExtensionFile = ""

    '        divMensajeOK.Visible = False
    '        divMensajeError.Visible = False
    '        divMensajeSinPermiso.Visible = False
    '        divMntMensajeError.Style.Add("display", "none")
    '        Try

    '            If Request.QueryString("vModo") = Nothing Or Request.QueryString("vPubli") = Nothing Then
    '                divMensajeSinPermiso.Visible = True
    '                divFormulario.Visible = False
    '                Exit Sub
    '            End If

    '            VS_idPerfil = 0
    '            VS_idPublicacion = 0
    '            VS_Modo = ""

    '            VS_idPerfil = Session("id_perfil")
    '            VS_idPublicacion = Request.QueryString("vPubli")
    '            VS_Modo = Request.QueryString("vModo").ToString

    '            If VS_Modo <> "UPD" And VS_Modo <> "INS" Then
    '                divMensajeSinPermiso.Visible = True
    '                divFormulario.Visible = False
    '            End If

    '            '---------------------------------

    '            limpiarDatosPublicacion()

    '            If VS_Modo = "UPD" Then
    '                'Cargar datos de la oferta
    '                cargarDatosPublicacion()
    '                btnActualizar.Visible = True
    '                btnRegistrar.Visible = False

    '                lblTitulo.Text = "Actualización de Publicación"
    '            ElseIf VS_Modo = "INS" Then
    '                ''Nuevo                    
    '                btnActualizar.Visible = False
    '                btnRegistrar.Visible = True
    '                btnArchivoPubli.Visible = False

    '                chkPermanente.Checked = True
    '                divFechaIniFin.Style.Add("display", "none")

    '                lblTitulo.Text = "Registro de Publicación"
    '            Else
    '                divMensajeSinPermiso.Visible = True
    '                divFormulario.Visible = False
    '                Exit Sub
    '            End If

    '        Catch ex As Exception

    '        End Try

    '    End If

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "ShowHideHoras();", True)
    'End Sub

    'Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

    '    If VS_idCliente = 0 Then
    '        Exit Sub
    '    End If

    '    Try

    '        lblMensajeError.Text = ""
    '        lblMensajeOK.Text = ""
    '        divMensajeError.Visible = False
    '        divMensajeOK.Visible = False

    '        If Not ValidarDatosPublicacion() Then
    '            Exit Sub
    '        End If

    '        Dim oPublicacionBL As New PublicacionBL
    '        Dim oPublicacionBE As New PublicacionBE

    '        Dim oResult As Integer = 0

    '        oPublicacionBE.oUnidadNegocioBE.id_unidad_negocio = ddlUnidadNegocio.SelectedValue
    '        oPublicacionBE.oTipoPublicacionBE.IdTipoPublicacion = ddlTipoPublicacion.SelectedValue
    '        oPublicacionBE.Titulo = txtTitulo.Text.Trim
    '        oPublicacionBE.Descripcion = txtDescripcion.Value.Trim
    '        oPublicacionBE.Link = txtLink.Text.Trim
    '        oPublicacionBE.permanente = chkPermanente.Checked
    '        If Not chkPermanente.Checked Then
    '            oPublicacionBE.FechaVigenciaIni = txtFechaInicio.Text.Trim
    '            oPublicacionBE.FechaVigenciaFin = txtFechaFin.Text.Trim
    '        End If
    '        oPublicacionBE.Activo = chkActivo.Checked
    '        oPublicacionBE.extension_file = VS_ExtensionFile

    '        oResult = oPublicacionBL.PublicacionRegistrar(oPublicacionBE)
    '        VS_idPublicacion = oResult

    '        If oResult > 0 Then

    '            cargarFoto()
    '            cargarArchivo()

    '            divMensajeOK.Visible = True
    '            lblMensajeOK.Text = "La publicación fue registrada satisfactoriamente"

    '            limpiarDatosPublicacion()

    '        Else
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "La publicación no pudo ser registrada"
    '        End If

    '        imgLogoPublicacion.Visible = False
    '        btnRegistrar.Visible = False


    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
    '    If VS_idCliente = 0 Then
    '        Exit Sub
    '    End If

    '    Try

    '        lblMensajeError.Text = ""
    '        lblMensajeOK.Text = ""
    '        divMensajeError.Visible = False
    '        divMensajeOK.Visible = False

    '        If Not ValidarDatosPublicacion() Then
    '            Exit Sub
    '        End If

    '        Dim oPublicacionBL As New PublicacionBL
    '        Dim oPublicacionBE As New PublicacionBE

    '        oPublicacionBE.IdPublicacion = VS_idPublicacion
    '        oPublicacionBE.oUnidadNegocioBE.id_unidad_negocio = ddlUnidadNegocio.SelectedValue
    '        oPublicacionBE.oTipoPublicacionBE.IdTipoPublicacion = ddlTipoPublicacion.SelectedValue
    '        oPublicacionBE.Titulo = txtTitulo.Text.Trim
    '        oPublicacionBE.Descripcion = txtDescripcion.Value.Trim
    '        oPublicacionBE.Link = txtLink.Text.Trim
    '        oPublicacionBE.permanente = chkPermanente.Checked
    '        If Not chkPermanente.Checked Then
    '            oPublicacionBE.FechaVigenciaIni = txtFechaInicio.Text.Trim
    '            oPublicacionBE.FechaVigenciaFin = txtFechaFin.Text.Trim
    '        End If
    '        oPublicacionBE.Activo = chkActivo.Checked
    '        oPublicacionBE.extension_file = VS_ExtensionFile

    '        If oPublicacionBL.PublicacionActualizar(oPublicacionBE) > 0 Then

    '            cargarFoto()
    '            cargarArchivo()

    '            divMensajeOK.Visible = True
    '            lblMensajeOK.Text = "La publicación fue actualizada satisfactoriamente"

    '            limpiarDatosPublicacion()

    '        Else
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "La publicación no pudo ser actualizada"
    '        End If

    '        imgLogoPublicacion.Visible = False
    '        btnActualizar.Visible = False


    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region "MÉTODOS"

    'Private Sub cargarFoto()

    '    If fupFotoPubli.HasFile Then
    '        Dim pf As HttpPostedFile = fupFotoPubli.PostedFile
    '        Dim rutaFotoPubli As String = System.Configuration.ConfigurationManager.AppSettings("rutaLogoPublica")
    '        Dim rutaCompletaFoto As String = Server.MapPath(rutaFotoPubli) & VS_idPublicacion.ToString() & ".jpg"

    '        If File.Exists(rutaCompletaFoto) Then
    '            My.Computer.FileSystem.DeleteFile(rutaCompletaFoto)
    '        End If

    '        fupFotoPubli.SaveAs(rutaCompletaFoto)
    '    End If

    'End Sub

    'Private Sub cargarArchivo()

    '    If fupArchivoPubli.HasFile Then
    '        Dim pf As HttpPostedFile = fupArchivoPubli.PostedFile
    '        Dim ext As String = Path.GetExtension(fupArchivoPubli.FileName)
    '        Dim rutaArchivoPublica As String = System.Configuration.ConfigurationManager.AppSettings("rutaArchivoPublica")
    '        Dim rutaCompletaFile As String = Server.MapPath(rutaArchivoPublica) & VS_idPublicacion.ToString() & ext

    '        If File.Exists(rutaCompletaFile) Then
    '            My.Computer.FileSystem.DeleteFile(rutaCompletaFile)
    '        End If

    '        fupArchivoPubli.SaveAs(rutaCompletaFile)
    '    End If

    'End Sub

    'Public Function ValidarDatosPublicacion() As Boolean

    '    If txtFechaInicio.Text.Trim <> "" And txtFechaFin.Text.Trim <> "" Then
    '        If Not IsDate(txtFechaInicio.Text.Trim) Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "La fecha inicial no es correcta"
    '            Return False
    '        End If

    '        If Not IsDate(txtFechaFin.Text.Trim) Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "La fecha final no es correcta"
    '            Return False
    '        End If

    '        If Date.Parse(txtFechaInicio.Text.Trim) > Date.Parse(txtFechaFin.Text.Trim) Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "La fecha inicial no debe ser mayor a la final"
    '            Return False
    '        End If
    '    End If

    '    'Validar foto : Solo en Insert -----------------------------------

    '    If VS_Modo = "INS" Or (VS_Modo = "UPD" And fupFotoPubli.HasFile) Then

    '        Dim pf As HttpPostedFile = fupFotoPubli.PostedFile

    '        If fupFotoPubli.HasFile = False Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "Seleccione una imagen para la publicación"
    '            Return False
    '        End If

    '        If pf.ContentType.ToLower <> "image/jpeg" Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "Solo los archivos con formato .jpg están permitidos"
    '            Return False
    '        End If

    '        If pf.ContentLength >= 1 * 1024 * 1024 Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "El tamaño de la imagen no debe exceder de 1 MB"
    '            Return False
    '        End If

    '    End If

    '    '----------------------------------------------

    '    If fupArchivoPubli.HasFile Then

    '        Dim pf2 As HttpPostedFile = fupArchivoPubli.PostedFile
    '        'Dim ext As String = Path.GetExtension(pf2.FileName)

    '        If pf2.ContentLength >= 3 * 1024 * 1024 Then
    '            divMensajeError.Visible = True
    '            lblMensajeError.Text = "El tamaño del archivo adjunto no debe exceder los 3 MB"
    '            Return False
    '        End If

    '        VS_ExtensionFile = Path.GetExtension(pf2.FileName)

    '    End If

    '    Return True

    'End Function

    'Sub limpiarDatosPublicacion()
    '    ddlUnidadNegocio.SelectedValue = ""
    '    ddlTipoPublicacion.SelectedValue = ""
    '    txtTitulo.Text = ""
    '    txtDescripcion.Value = ""
    '    txtLink.Text = ""
    '    txtFechaInicio.Text = ""
    '    txtFechaFin.Text = ""
    '    chkActivo.Checked = False
    '    chkPermanente.Checked = True
    '    divFechaIniFin.Style.Add("display", "none")
    '    ddlUnidadNegocio.Focus()
    'End Sub

    'Sub cargarDatosPublicacion()

    '    Dim oPublicacionBE As New PublicacionBE
    '    Dim oPublicacionBL As New PublicacionBL

    '    Try

    '        oPublicacionBE = oPublicacionBL.PublicacionObtener(VS_idPublicacion)

    '        If Not oPublicacionBE Is Nothing Then
    '            ddlUnidadNegocio.SelectedValue = IIf(oPublicacionBE.oUnidadNegocioBE.id_unidad_negocio = 0, "", oPublicacionBE.oUnidadNegocioBE.id_unidad_negocio)
    '            ddlTipoPublicacion.SelectedValue = oPublicacionBE.oTipoPublicacionBE.IdTipoPublicacion
    '            txtTitulo.Text = oPublicacionBE.Titulo
    '            txtDescripcion.Value = oPublicacionBE.Descripcion
    '            txtLink.Text = oPublicacionBE.Link
    '            chkPermanente.Checked = oPublicacionBE.permanente
    '            chkActivo.Checked = oPublicacionBE.Activo
    '            VS_ExtensionFile = oPublicacionBE.extension_file

    '            If oPublicacionBE.permanente Then
    '                txtFechaInicio.Text = ""
    '                txtFechaFin.Text = ""
    '                divFechaIniFin.Style.Add("display", "none")
    '            Else
    '                divFechaIniFin.Style.Add("display", "block")
    '                txtFechaInicio.Text = oPublicacionBE.FechaVigenciaIni
    '                txtFechaFin.Text = oPublicacionBE.FechaVigenciaFin
    '            End If

    '            muestraFotoForm()
    '            muestraArchivoPubli(oPublicacionBE.extension_file)


    '        Else
    '            limpiarDatosPublicacion()
    '            divMensajeSinPermiso.Visible = True
    '            divFormulario.Visible = False
    '            Exit Sub
    '        End If

    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Sub muestraFotoForm()
    '    Dim rutaFotoPubli As String = System.Configuration.ConfigurationManager.AppSettings("rutaLogoPublica")
    '    Dim rutaCompletaFoto As String = Server.MapPath(rutaFotoPubli) & VS_idPublicacion.ToString() & ".jpg"

    '    If File.Exists(rutaCompletaFoto) Then
    '        imgLogoPublicacion.ImageUrl = rutaFotoPubli & VS_idPublicacion.ToString() & ".jpg"
    '    Else
    '        'imgLogoPublicacion.ImageUrl = rutaFotoPubli & VS_idTipoPubliSelect & "_" & "sin_logo.jpg"
    '        imgLogoPublicacion.ImageUrl = rutaFotoPubli & "sin_logo.jpg"
    '    End If
    'End Sub

    'Sub muestraArchivoPubli(ByVal ext As String)
    '    Dim rutaFilePubli As String = System.Configuration.ConfigurationManager.AppSettings("rutaArchivoPublica")
    '    Dim rutaCompletaFile As String = Server.MapPath(rutaFilePubli) & VS_idPublicacion.ToString() & ext

    '    If File.Exists(rutaCompletaFile) Then 'Existe documento

    '        imgLogoDocumento.Visible = False
    '        btnArchivoPubli.Visible = True

    '        btnArchivoPubli.HRef = rutaFilePubli & VS_idPublicacion.ToString() & ext

    '    Else 'No exise documento
    '        imgLogoDocumento.Visible = True
    '        btnArchivoPubli.Visible = False

    '        imgLogoDocumento.ImageUrl = "../Images/sin_logo_file.jpg"
    '    End If
    'End Sub

#End Region


End Class
