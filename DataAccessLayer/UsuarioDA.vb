Imports System.Data
Imports System.Data.SqlClient
Imports BusinessEntities
Public Class UsuarioDA
#Region " : Variables : "

    Private ConnectionString As String = String.Empty
    Private oConexion As DAConexion = Nothing

#End Region

#Region " : Constructor : "

    Sub New()
        oConexion = New DAConexion
        ConnectionString = oConexion.ConnecionStringPortal
    End Sub

#End Region

#Region " : Funciones : "

    Public Function ClienteLoginValidar(ByVal usuario As String, ByVal password As String) As UsuarioBE
        Dim cn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_UsuarioLoginValidar", cn)
        Try
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario
                .Parameters.Add("@password", SqlDbType.VarChar).Value = password
            End With
            cn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Dim oUsuarioBE As UsuarioBE = Nothing
            While dr.Read
                oUsuarioBE = New UsuarioBE
                oUsuarioBE.id_usuario = dr("id_usuario")
                oUsuarioBE.administrador = dr("administrador")
                oUsuarioBE.apellido_paterno = dr("apellido_paterno")
                oUsuarioBE.apellido_materno = dr("apellido_materno")
                oUsuarioBE.nombres = dr("nombres")
                oUsuarioBE.email = dr("email")
            End While
            Return oUsuarioBE
        Catch ex As Exception
            Throw New Exception
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Dispose()
        End Try
    End Function


#End Region
End Class
