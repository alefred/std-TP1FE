Imports BusinessLogicLayer
Imports BusinessEntities
Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("redireccion") Is Nothing Then
            Session.Contents.RemoveAll()
        End If

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim oUsuarioBL As New UsuarioBL
        Dim oUsuarioBE As New UsuarioBE

        Dim strURL As String = ""
        strURL = Session("redireccion")

        Session.Contents.RemoveAll()

        Dim strUsuario As String = txtUsuario.Text.Trim
        Dim strPassword As String = txtPassword.Text.Trim

        Try

            If strUsuario = "" Or strPassword = "" Then
                'Msg : Complete usuario y/o contraseña
                lblMsgAdvertencia.Text = "Complete usuario y/o contraseña"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
                Exit Sub
            End If

            oUsuarioBE = oUsuarioBL.ClienteLoginValidar(strUsuario, strPassword)

            If oUsuarioBE Is Nothing Then
                'Msg : Usuario y/o contraseña incorrecto
                lblMsgAdvertencia.Text = "Usuario y/o contraseña incorrecto"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
                Exit Sub
            Else

                If oUsuarioBE.administrador Then
                    Session("id_perfil") = 2
                Else
                    Session("id_perfil") = 1
                End If

                Session("id_cliente") = oUsuarioBE.id_usuario
                Session("apellido_paterno") = oUsuarioBE.apellido_paterno
                Session("apellido_materno") = oUsuarioBE.apellido_materno
                Session("nombres") = oUsuarioBE.nombres
                Session("email") = oUsuarioBE.email

                If strURL <> "" Then
                    Session("redireccion") = ""
                    Response.Redirect(strURL)
                Else
                    Response.Redirect("pages/frmInicio.aspx")
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
