Imports DataAccessLayer
Imports BusinessEntities

Public Class UsuarioBL
    Dim oPersonaDA As New UsuarioDA
    Public Function ClienteLoginValidar(ByVal usuario As String, ByVal password As String) As UsuarioBE
        Return oPersonaDA.ClienteLoginValidar(usuario, password)
    End Function

    Public Function RegistroUsuario(ByVal nombres As String, ByVal apePat As String, ByVal apeMat As String, ByVal correo As String, ByVal tipodoc As Integer, ByVal documento As String, ByVal fecNac As String, ByVal direccion As String, ByVal telefono As String, ByVal usuario As String, ByVal password As String) As Integer
        Return oPersonaDA.RegistrarUsuario(nombres, apePat, apeMat, correo, tipodoc, documento, fecNac, direccion, telefono, usuario, password)
    End Function

End Class
