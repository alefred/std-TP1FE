Imports System.Data
Imports System.Data.SqlClient
Imports BusinessEntities

Public Class EventoDA

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

    Public Function EventoObtener(ByVal id_evento As Integer) As EventoBE
        Dim cn As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("usp_EventoObtener", cn)
        Try
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@id_evento", SqlDbType.Int).Value = id_evento
            End With
            cn.Open()
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Dim oEventoBE As EventoBE = Nothing
            While dr.Read
                oEventoBE = New EventoBE
                oEventoBE.id_evento = dr("id_evento")
                oEventoBE.titulo = dr("titulo")
                oEventoBE.descripcion = dr("descripcion")
                oEventoBE.fecha_registro = dr("fecha_registro")
                oEventoBE.fecha_evento = dr("fecha_evento")
                oEventoBE.todo_dia = dr("todo_dia")
                oEventoBE.hora_inicio = dr("hora_inicio")
                oEventoBE.hora_inicio_time = dr("hora_inicio_time")
                oEventoBE.hora_fin = dr("hora_fin")
                oEventoBE.hora_fin_time = dr("hora_fin_time")
                oEventoBE.rango_dias = dr("rango_dias")
                oEventoBE.fecha_ini = dr("fecha_ini")
                oEventoBE.fecha_fin = dr("fecha_fin")
            End While
            Return oEventoBE
        Catch ex As Exception
            Throw New Exception
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cmd.Dispose()
        End Try

    End Function

    Public Function EventoRegistrar(ByVal oEventoBE As EventoBE) As Integer
        Dim oSqlConnection As New SqlConnection(ConnectionString)
        Dim oSqlCommand As New SqlCommand("usp_EventoRegistrar", oSqlConnection)
        Dim oResult As Integer = 0

        Try
            oSqlConnection.Open()
            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@titulo", SqlDbType.VarChar).Value = oEventoBE.titulo
            oSqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = oEventoBE.descripcion
            oSqlCommand.Parameters.Add("@fecha_evento", SqlDbType.VarChar).Value = oEventoBE.fecha_evento
            oSqlCommand.Parameters.Add("@todo_dia", SqlDbType.VarChar).Value = oEventoBE.todo_dia
            oSqlCommand.Parameters.Add("@hora_inicio", SqlDbType.VarChar).Value = oEventoBE.hora_inicio
            oSqlCommand.Parameters.Add("@hora_fin", SqlDbType.VarChar).Value = oEventoBE.hora_fin
            oSqlCommand.Parameters.Add("@rango_dias", SqlDbType.VarChar).Value = oEventoBE.rango_dias
            oSqlCommand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = oEventoBE.fecha_ini
            oSqlCommand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = oEventoBE.fecha_fin

            oResult = oSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            oResult = 0
            Throw New Exception("Se produjo error al registrar", ex)
        Finally
            If oSqlConnection.State = ConnectionState.Open Then oSqlConnection.Close()
            oSqlCommand.Dispose()
        End Try

        Return oResult
    End Function

    Public Function EventoActualizar(ByVal oEventoBE As EventoBE) As Integer
        Dim oSqlConnection As New SqlConnection(ConnectionString)
        Dim oSqlCommand As New SqlCommand("usp_EventoActualizar", oSqlConnection)
        Dim oResult As Integer = 0

        Try
            oSqlConnection.Open()
            oSqlCommand.CommandType = CommandType.StoredProcedure
            oSqlCommand.Parameters.Add("@id_evento", SqlDbType.Int).Value = oEventoBE.id_evento
            oSqlCommand.Parameters.Add("@titulo", SqlDbType.VarChar).Value = oEventoBE.titulo
            oSqlCommand.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = oEventoBE.descripcion
            oSqlCommand.Parameters.Add("@fecha_evento", SqlDbType.VarChar).Value = oEventoBE.fecha_evento
            oSqlCommand.Parameters.Add("@todo_dia", SqlDbType.VarChar).Value = oEventoBE.todo_dia
            oSqlCommand.Parameters.Add("@hora_inicio", SqlDbType.VarChar).Value = oEventoBE.hora_inicio
            oSqlCommand.Parameters.Add("@hora_fin", SqlDbType.VarChar).Value = oEventoBE.hora_fin
            oSqlCommand.Parameters.Add("@rango_dias", SqlDbType.VarChar).Value = oEventoBE.rango_dias
            oSqlCommand.Parameters.Add("@fecha_ini", SqlDbType.VarChar).Value = oEventoBE.fecha_ini
            oSqlCommand.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = oEventoBE.fecha_fin

            oResult = oSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            oResult = 0
            Throw New Exception("Se produjo error al actualizar", ex)
        Finally
            If oSqlConnection.State = ConnectionState.Open Then oSqlConnection.Close()
            oSqlCommand.Dispose()
        End Try

        Return oResult
    End Function

    Public Function EventoEliminar(ByVal id_evento As Integer) As Integer
        Dim oSqlConnection As New SqlConnection(ConnectionString)
        Dim oSqlCommand As New SqlCommand("usp_EventoEliminar", oSqlConnection)
        Dim oResult As Integer = 0

        Try
            oSqlConnection.Open()
            oSqlCommand.CommandType = CommandType.StoredProcedure
            oSqlCommand.Parameters.Add("@id_evento", SqlDbType.Int).Value = id_evento

            oResult = oSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            oResult = 0
            Throw New Exception("Se produjo error al eliminar", ex)
        Finally
            If oSqlConnection.State = ConnectionState.Open Then oSqlConnection.Close()
            oSqlCommand.Dispose()
        End Try

        Return oResult
    End Function

    Public Function EventoFiltrarAdm(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As List(Of EventoBE)
        Dim oSqlConnection As New SqlConnection(ConnectionString)
        Dim oSqlCommand As New SqlCommand("usp_EventoFiltrarAdm", oSqlConnection)

        Dim oEventoBE As EventoBE = Nothing
        Dim loEventoBE As New List(Of EventoBE)
        Dim lector As SqlDataReader

        Try

            oSqlConnection.Open()
            oSqlCommand.CommandType = CommandType.StoredProcedure

            oSqlCommand.Parameters.Add("@id_unidad_negocio", SqlDbType.Int).Value = id_unidad_negocio
            oSqlCommand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha

            lector = oSqlCommand.ExecuteReader

            Dim p0 As Int32 = lector.GetOrdinal("id_evento")
            Dim p1 As Int32 = lector.GetOrdinal("titulo")
            Dim p2 As Int32 = lector.GetOrdinal("descripcion")
            Dim p3 As Int32 = lector.GetOrdinal("fecha_registro")
            Dim p4 As Int32 = lector.GetOrdinal("fecha_evento")
            Dim p6 As Int32 = lector.GetOrdinal("todo_dia")
            Dim p7 As Int32 = lector.GetOrdinal("hora_inicio")
            Dim p8 As Int32 = lector.GetOrdinal("hora_inicio_time")
            Dim p9 As Int32 = lector.GetOrdinal("hora_fin")
            Dim p10 As Int32 = lector.GetOrdinal("hora_fin_time")
            Dim p11 As Int32 = lector.GetOrdinal("id_unidad_negocio")
            Dim p12 As Int32 = lector.GetOrdinal("unidad_negocio")

            While lector.Read
                oEventoBE = New EventoBE
                oEventoBE.id_evento = lector(p0)
                oEventoBE.titulo = lector(p1)
                oEventoBE.descripcion = lector(p2)
                oEventoBE.fecha_registro = lector(p3)
                oEventoBE.fecha_evento = lector(p4)
                oEventoBE.todo_dia = lector(p6)
                oEventoBE.hora_inicio = lector(p7)
                oEventoBE.hora_inicio_time = lector(p8)
                oEventoBE.hora_fin = lector(p9)
                oEventoBE.hora_fin_time = lector(p10)


                loEventoBE.Add(oEventoBE)
            End While

        Catch ex As Exception
            Throw New Exception("Ocurrió un error al tratar de listar", ex)
        Finally
            If oSqlConnection.State = ConnectionState.Open Then oSqlConnection.Close()
            oSqlCommand.Dispose()
        End Try

        Return loEventoBE

    End Function

    Public Function EventoFiltrar(ByVal id_unidad_negocio As Integer) As DataSet

        Dim ds As New DataSet
        Try
            Using con As New SqlConnection(ConnectionString)
                Using da As SqlDataAdapter = New SqlDataAdapter("usp_EventoListar", con)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.Add("@id_unidad_negocio", SqlDbType.Int).Value = id_unidad_negocio
                    da.Fill(ds, "AllTables")
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al tratar de listar", ex)
        End Try
        Return ds
    End Function

    Public Function EventoFiltrarxFecha(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As DataSet

        Dim ds As New DataSet
        Try
            Using con As New SqlConnection(ConnectionString)
                Using da As SqlDataAdapter = New SqlDataAdapter("usp_EventoFiltrarxFecha", con)
                    da.SelectCommand.CommandType = CommandType.StoredProcedure
                    da.SelectCommand.Parameters.Add("@id_unidad_negocio", SqlDbType.Int).Value = id_unidad_negocio
                    da.SelectCommand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha
                    da.Fill(ds, "AllTables")
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Ocurrió un error al tratar de listar", ex)
        End Try
        Return ds
    End Function

    'Public Function CumpleFiltrarxFecha(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As DataSet

    '    Dim ds As New DataSet
    '    Try
    '        Using con As New SqlConnection(ConnectionString)
    '            Using da As SqlDataAdapter = New SqlDataAdapter("usp_CumpleFiltrarxFecha", con)
    '                da.SelectCommand.CommandType = CommandType.StoredProcedure
    '                da.SelectCommand.Parameters.Add("@id_unidad_negocio", SqlDbType.Int).Value = id_unidad_negocio
    '                da.SelectCommand.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha
    '                da.Fill(ds, "AllTables")
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New Exception("Ocurrió un error al tratar de listar", ex)
    '    End Try
    '    Return ds
    'End Function

#End Region

End Class
