Public Class DepartamentoBE
    Private id_departamento_ As Integer
    Private departamento_ As String
    Private borrado_ As Boolean

    Public Property IdDepartamento() As Integer
        Get
            Return id_departamento_
        End Get
        Set(ByVal value As Integer)
            id_departamento_ = value
        End Set
    End Property

    Public Property Departamento() As String
        Get
            Return departamento_
        End Get
        Set(ByVal value As String)
            departamento_ = value
        End Set
    End Property
End Class
