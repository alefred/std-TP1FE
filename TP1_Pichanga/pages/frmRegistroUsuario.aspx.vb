Imports BusinessEntities
Imports BusinessLogicLayer
Imports System.Collections.Generic
Imports System.IO

Partial Class administrador_frmRegistroUsuario
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("id_cliente") = Nothing And Session("id_perfil") = Nothing Then
            Response.Redirect("../Login.aspx")
            Exit Sub
        End If


        If Not Page.IsPostBack Then
            divMensajeOK.Visible = False
            divMensajeError.Visible = False
            Call LimpiaDatos()
        End If

    End Sub


    Protected Sub BtnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        Dim oUsuarioBL As New UsuarioBL
        Dim cod_mensaje As Integer

        Dim strNombres As String = txtNombres.Text.Trim
        Dim strApellidoPat As String = txtApellidoPat.Text.Trim
        Dim strApellidoMat As String = txtApellidoMat.Text.Trim
        Dim strCorreo As String = txtCorreo.Text.Trim
        Dim strTipoDoc As Integer = ddlTipoDoc.SelectedValue
        Dim strDocumento As String = txtDocumento.Text.Trim
        Dim strFechaNac As String = txtFechaNacimiento.Text.Trim
        Dim strDirrecion As String = txtDireccion.Text.Trim
        Dim strTelefono As String = txtTelefono.Text.Trim
        Dim strUsuario As String = txtUsuario.Text.Trim
        Dim strPassword As String = txtClave.Text.Trim

        Try
            cod_mensaje = oUsuarioBL.RegistroUsuario(strNombres, strApellidoPat, strApellidoMat, strCorreo, strTipoDoc, strDocumento, strFechaNac, strDirrecion, strTelefono, strUsuario, strPassword)

            If cod_mensaje = 0 Then
                divMensajeOK.Visible = True
                divMensajeError.Visible = False
                lblMensajeOK.Text = "Pichangero registrado correctamente"
                Call LimpiaDatos()
                Exit Sub
            Else
                divMensajeError.Visible = True
                divMensajeOK.Visible = False
                lblMensajeError.Text = "Pichanguero ya se encuentra registrado en el sistema"
                Call LimpiaDatos()
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiaDatos()

        txtNombres.Text = ""
        txtApellidoPat.Text = ""
        txtApellidoMat.Text = ""
        txtCorreo.Text = ""
        ddlTipoDoc.SelectedValue = 0
        txtDocumento.Text = ""
        txtFechaNacimiento.Text = ""
        txtDireccion.Text = ""
        txtTelefono.Text = ""
        txtUsuario.Text = ""
        txtClave.Text = ""

    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Session.Contents.RemoveAll()
        Response.Redirect("../Login.aspx")
    End Sub
End Class
