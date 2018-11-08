Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Collections.Generic
Imports System.IO

Partial Class frame_CambiarFoto
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

#End Region

#Region "EVENTOS"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("id_cliente") = Nothing And Session("id_perfil") = Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If

        Try
            If Not Page.IsPostBack Then

                VS_idCliente = Session("id_cliente")

                divMensajeErrorFoto.Visible = False
                lblMensajeErrorFoto.Text = ""
            End If
        Catch ex As Exception

        End Try

        muestraFotoForm()

    End Sub

#End Region

#Region "MÉTODOS"


    Protected Sub btnActualizarFoto_Click(sender As Object, e As EventArgs) Handles btnActualizarFoto.Click
        If VS_idCliente = 0 Then
            Exit Sub
        End If

        divMensajeErrorFoto.Visible = False
        lblMensajeErrorFoto.Text = ""

        If Not validarFoto() Then
            Exit Sub
        End If
        cargarFoto()
    End Sub

    Public Function validarFoto() As Boolean
        Dim pf As HttpPostedFile = fupFotoPerfil.PostedFile

        If fupFotoPerfil.HasFile = False Then
            divMensajeErrorFoto.Visible = True
            lblMensajeErrorFoto.Text = "Seleccione una foto"
            Return False
        End If

        If pf.ContentType.ToLower <> "image/jpeg" Then
            'MensajeAdvertencia("Solo los archivos con formato .jpg están permitidos")
            divMensajeErrorFoto.Visible = True
            lblMensajeErrorFoto.Text = "Solo los archivos con formato .jpg están permitidos"
            Return False
        End If

        If pf.ContentLength >= 3 * 1024 * 1024 Then
            'MensajeAdvertencia("El tamaño del archivo no debe exceder los 5MB")
            divMensajeErrorFoto.Visible = True
            lblMensajeErrorFoto.Text = "El tamaño del archivo no debe exceder los 3 MB"
            Return False
        End If

        '----------------------------------------------

        Return True
    End Function

    Private Sub cargarFoto()

        If fupFotoPerfil.HasFile Then
            Dim pf As HttpPostedFile = fupFotoPerfil.PostedFile
            Dim rutaFotoPubli As String = System.Configuration.ConfigurationManager.AppSettings("rutaFotoPerfil")
            Dim rutaCompletaFoto As String = Server.MapPath(rutaFotoPubli) & Session("id_cliente").ToString() & ".jpg"

            If File.Exists(rutaCompletaFoto) Then
                My.Computer.FileSystem.DeleteFile(rutaCompletaFoto)
            End If

            'fupFotoPubli.SaveAs(rutaFotoPubli & VS_idEmpresaSelect & ".jpg")
            fupFotoPerfil.SaveAs(rutaCompletaFoto)
        End If

        '--------------> REFRESCAR PÁGINA AQUI
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "window.top.location = 'http://intranet.ucal-tls.edu.pe/colaborador/Inicio.aspx';", True)

    End Sub

    Sub muestraFotoForm()
        Dim rutaFotoPerfil As String = System.Configuration.ConfigurationManager.AppSettings("rutaFotoPerfil")
        Dim rutaCompletaFoto As String = Server.MapPath(rutaFotoPerfil) & Session("id_cliente").ToString() & ".jpg"

        If File.Exists(rutaCompletaFoto) Then
            imgFotoPerfil.ImageUrl = rutaFotoPerfil & Session("id_cliente").ToString() & ".jpg"
        Else
            imgFotoPerfil.ImageUrl = rutaFotoPerfil & "sin_foto_perfil.jpg"
        End If
    End Sub
#End Region
End Class
