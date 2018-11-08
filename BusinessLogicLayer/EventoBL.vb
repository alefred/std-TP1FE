Imports DataAccessLayer
Imports BusinessEntities

Public Class EventoBL

    Dim oEventoDA As New EventoDA

    Public Function EventoFiltrarAdm(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As List(Of EventoBE)
        Return oEventoDA.EventoFiltrarAdm(id_unidad_negocio, fecha)
    End Function

    Public Function EventoFiltrar(ByVal id_unidad_negocio As Integer) As DataSet
        Return oEventoDA.EventoFiltrar(id_unidad_negocio)
    End Function

    Public Function EventoFiltrarxFecha(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As DataSet
        Return oEventoDA.EventoFiltrarxFecha(id_unidad_negocio, fecha)
    End Function

    'Public Function CumpleFiltrarxFecha(ByVal id_unidad_negocio As Integer, ByVal fecha As String) As DataSet
    '    Return oEventoDA.CumpleFiltrarxFecha(id_unidad_negocio, fecha)
    'End Function

    Public Function EventoObtener(ByVal id_evento As Integer) As EventoBE
        Return oEventoDA.EventoObtener(id_evento)
    End Function

    Public Function EventoRegistrar(ByVal oEventoBE As EventoBE) As Integer
        Return oEventoDA.EventoRegistrar(oEventoBE)
    End Function

    Public Function EventoActualizar(ByVal oEventoBE As EventoBE) As Integer
        Return oEventoDA.EventoActualizar(oEventoBE)
    End Function

    Public Function EventoEliminar(ByVal id_evento As Integer) As Integer
        Return oEventoDA.EventoEliminar(id_evento)
    End Function

End Class
