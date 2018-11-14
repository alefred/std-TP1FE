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


    Public Function RegistrarUsuario(ByVal nombres As String, ByVal apePat As String, ByVal apeMat As String, ByVal correo As String, ByVal tipodoc As Integer, ByVal documento As String, ByVal fecNac As String, ByVal direccion As String, ByVal telefono As String, ByVal usuario As String, ByVal password As String) As Integer
        Dim cn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_RegistraNuevoUsuario", cn)
        Try
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario
                .Parameters.Add("@password", SqlDbType.VarChar).Value = password
                .Parameters.Add("@Apellido_paterno", SqlDbType.VarChar).Value = apePat
                .Parameters.Add("@Apellido_materno", SqlDbType.VarChar).Value = apeMat
                .Parameters.Add("@nombres", SqlDbType.VarChar).Value = nombres
                .Parameters.Add("@tipo_doc", SqlDbType.Int).Value = tipodoc
                .Parameters.Add("@nro_documento", SqlDbType.VarChar).Value = documento
                .Parameters.Add("@email", SqlDbType.VarChar).Value = correo
                .Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = fecNac
                .Parameters.Add("@celular", SqlDbType.VarChar).Value = telefono
                .Parameters.Add("@direccion", SqlDbType.VarChar).Value = direccion
                .Parameters.Add("@tipo_usu", SqlDbType.Int).Value = 2
                .Parameters.Add("@msg", SqlDbType.SmallInt)
                .Parameters("@msg").Direction = ParameterDirection.Output
            End With
            cn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Dim cod_msg As Integer = CInt(cmd.Parameters("@msg").Value)
            Return cod_msg

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
