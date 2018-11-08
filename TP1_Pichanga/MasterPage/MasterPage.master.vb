Imports System.IO
Partial Class MasterPage_MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("id_cliente") = Nothing And Session("id_perfil") = Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If

        Try

            If Not Page.IsPostBack Then

                If Session("Pagina") Is Nothing Then
                    Session("Pagina") = ""
                End If
                Dim classActive = " class='active' "

                Dim strLiteralMenu As String = ""

                'strLiteralMenu = strLiteralMenu & "<li " & IIf("Inicio.aspx".IndexOf(Session("Pagina")) > -1, classActive, "") & ">"
                'strLiteralMenu = strLiteralMenu & "    <a href='../pages/frmInicio.aspx'><i class='fa fa-home'></i><span class='nav-label'>Inicio</span> </a>	"
                'strLiteralMenu = strLiteralMenu & "</li>"

                strLiteralMenu = strLiteralMenu & "<li " & IIf("Inicio.aspx|Galeria.aspx|GaleriaVideos.aspx".IndexOf(Session("Pagina")) > -1, classActive, "") & ">"
                strLiteralMenu = strLiteralMenu & "    <a href='#'><i class='fa fa-home'></i><span class='nav-label'>Inicio</span> <span class='fa arrow'></span></a>	"
                strLiteralMenu = strLiteralMenu & "    <ul class='nav nav-second-level'>"
                strLiteralMenu = strLiteralMenu & "        <li><a href='../pages/frmInicio.aspx'>Noticias</a></li>	"
                strLiteralMenu = strLiteralMenu & "    </ul>"
                strLiteralMenu = strLiteralMenu & "</li>"

                If Session("id_perfil") = 2 Then
                    strLiteralMenu = strLiteralMenu & "<li " & IIf("MntPublicacion.aspx|MntMOF.aspx|MntEvento.aspx|frmRegistroPublicacion.aspx|frmRegistroMOF.aspx".IndexOf(Session("Pagina")) > -1, classActive, "") & ">	"
                    strLiteralMenu = strLiteralMenu & "    <a href='#'><i class='fa fa-gears'></i><span class='nav-label'>Gestor de contenidos</span> <span class='fa arrow'></span></a>	"
                    strLiteralMenu = strLiteralMenu & "    <ul class='nav nav-second-level'>	"
                    strLiteralMenu = strLiteralMenu & "        <li><a href='../pages/MntPublicacion.aspx'>Publicaciones</a></li>	"
                    strLiteralMenu = strLiteralMenu & "    </ul>"
                    strLiteralMenu = strLiteralMenu & "    <ul class='nav nav-second-level'>	"
                    strLiteralMenu = strLiteralMenu & "        <li><a href='../pages/MntEvento.aspx'>Eventos</a></li>	"
                    strLiteralMenu = strLiteralMenu & "    </ul>"
                    strLiteralMenu = strLiteralMenu & "</li>"

                End If

                LiteralMenu.Text = strLiteralMenu


                If Session("nombres") = "" Then
                    lblNombreUsuario.Text = ""
                    lblApePatUsuario.Text = ""
                Else
                    lblNombreUsuario.Text = Session("nombres")
                    lblApePatUsuario.Text = Session("apellido_paterno")
                    lblCargoUsuario.Text = Session("email")
                End If


                imgLogoUN.ImageUrl = "../Images/logo_tls_perfil.png"


            End If

        Catch ex As Exception

        End Try

        muestraFotoPerfil()

    End Sub

    Public Property LabelMsgAdvertencia() As String
        Get
            Return lblMsgAdvertencia.Text
        End Get
        Set(value As String)
            lblMsgAdvertencia.Text = value
        End Set
    End Property

    Public Property LabelMsgOK() As String
        Get
            Return lblMsgOK.Text
        End Get
        Set(value As String)
            lblMsgOK.Text = value
        End Set
    End Property

    Public Property LabelMsgError() As String
        Get
            Return lblMsgError.Text
        End Get
        Set(value As String)
            lblMsgError.Text = value
        End Set
    End Property

    Sub muestraFotoPerfil()
        Dim rutaFotoPerfil As String = System.Configuration.ConfigurationManager.AppSettings("rutaFotoPerfil")
        Dim rutaCompletaFoto As String = Server.MapPath(rutaFotoPerfil) & Session("id_cliente").ToString() & ".jpg"

        If File.Exists(rutaCompletaFoto) Then
            imgFotoPerfil.ImageUrl = rutaFotoPerfil & Session("id_cliente").ToString() & ".jpg"
        Else
            imgFotoPerfil.ImageUrl = rutaFotoPerfil & "sin_foto_perfil.jpg"
        End If
    End Sub


    Protected Sub linkCerrarSesion_ServerClick(sender As Object, e As EventArgs) Handles linkCerrarSesion.ServerClick
        Session.Contents.RemoveAll()
        Response.Redirect("../Login.aspx")
    End Sub

    Protected Sub linkCerrarSesion2_ServerClick(sender As Object, e As EventArgs) Handles linkCerrarSesion2.ServerClick
        Session.Contents.RemoveAll()
        Response.Redirect("../Login.aspx")
    End Sub
End Class

