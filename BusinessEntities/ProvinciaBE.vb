Public Class ProvinciaBE
    Private id_provincia_ As Integer
    Private provincia_ As String
    Private borrado_ As Boolean
    Private oDepartamentoBE_ As New DepartamentoBE

    Public Property IdProvincia() As Integer
        Get
            Return id_provincia_
        End Get
        Set(ByVal value As Integer)
            id_provincia_ = value
        End Set
    End Property

    Public Property Provincia() As String
        Get
            Return provincia_
        End Get
        Set(ByVal value As String)
            provincia_ = value
        End Set
    End Property

    Public Property Borrado() As Boolean
        Get
            Return borrado_
        End Get
        Set(ByVal value As Boolean)
            borrado_ = value
        End Set
    End Property

    Public Property oDepartamentoBE() As DepartamentoBE
        Get
            Return oDepartamentoBE_
        End Get
        Set(ByVal value As DepartamentoBE)
            oDepartamentoBE_ = value
        End Set
    End Property
End Class
