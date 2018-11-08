Public Class DistritoBE
    Private id_distrito_ As Integer
    Private distrito_ As String
    Private borrado_ As Boolean
    Private oProvinciaBE_ As New ProvinciaBE

    Public Property IdDistrito() As Integer
        Get
            Return id_distrito_
        End Get
        Set(ByVal value As Integer)
            id_distrito_ = value
        End Set
    End Property

    Public Property Distrito() As String
        Get
            Return distrito_
        End Get
        Set(ByVal value As String)
            distrito_ = value
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

    Public Property oProvinciaBE() As ProvinciaBE
        Get
            Return oProvinciaBE_
        End Get
        Set(ByVal value As ProvinciaBE)
            oProvinciaBE_ = value
        End Set
    End Property
End Class
