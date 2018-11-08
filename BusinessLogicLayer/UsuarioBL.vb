Imports DataAccessLayer
Imports BusinessEntities

Public Class UsuarioBL
    Dim oPersonaDA As New UsuarioDA
    Public Function ClienteLoginValidar(ByVal usuario As String, ByVal password As String) As UsuarioBE
        Return oPersonaDA.ClienteLoginValidar(usuario, password)
    End Function

End Class
