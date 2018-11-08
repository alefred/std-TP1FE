Public Class EventoBE
    Private id_evento_ As Integer
    Private titulo_ As String
    Private descripcion_ As String
    Private fecha_registro_ As String
    Private fecha_evento_ As String
    Private todo_dia_ As Boolean
    Private hora_inicio_ As String
    Private hora_inicio_time_ As String
    Private hora_fin_ As String
    Private hora_fin_time_ As String

    Private rango_dias_ As Boolean
    Private fecha_ini_ As String
    Private fecha_fin_ As String

    Public Property id_evento() As Integer
        Get
            Return id_evento_
        End Get
        Set(ByVal value As Integer)
            id_evento_ = value
        End Set
    End Property

    Public Property titulo() As String
        Get
            Return titulo_
        End Get
        Set(ByVal value As String)
            titulo_ = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return descripcion_
        End Get
        Set(ByVal value As String)
            descripcion_ = value
        End Set
    End Property

    Public Property fecha_registro() As String
        Get
            Return fecha_registro_
        End Get
        Set(ByVal value As String)
            fecha_registro_ = value
        End Set
    End Property

    Public Property fecha_evento() As String
        Get
            Return fecha_evento_
        End Get
        Set(ByVal value As String)
            fecha_evento_ = value
        End Set
    End Property

    Public Property todo_dia() As Boolean
        Get
            Return todo_dia_
        End Get
        Set(ByVal value As Boolean)
            todo_dia_ = value
        End Set
    End Property

    Public Property hora_inicio() As String
        Get
            Return hora_inicio_
        End Get
        Set(ByVal value As String)
            hora_inicio_ = value
        End Set
    End Property

    Public Property hora_inicio_time() As String
        Get
            Return hora_inicio_time_
        End Get
        Set(ByVal value As String)
            hora_inicio_time_ = value
        End Set
    End Property

    Public Property hora_fin() As String
        Get
            Return hora_fin_
        End Get
        Set(ByVal value As String)
            hora_fin_ = value
        End Set
    End Property

    Public Property hora_fin_time() As String
        Get
            Return hora_fin_time_
        End Get
        Set(ByVal value As String)
            hora_fin_time_ = value
        End Set
    End Property

    Public Property rango_dias() As Boolean
        Get
            Return rango_dias_
        End Get
        Set(ByVal value As Boolean)
            rango_dias_ = value
        End Set
    End Property

    Public Property fecha_ini() As String
        Get
            Return fecha_ini_
        End Get
        Set(ByVal value As String)
            fecha_ini_ = value
        End Set
    End Property

    Public Property fecha_fin() As String
        Get
            Return fecha_fin_
        End Get
        Set(ByVal value As String)
            fecha_fin_ = value
        End Set
    End Property


End Class
