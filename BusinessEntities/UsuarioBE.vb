﻿Public Class UsuarioBE
    Dim id_usuario_ As Integer
    Dim administrador_ As Boolean
    Dim usuario_ As String
    Dim password_ As String

    Dim apellido_paterno_ As String
    Dim apellido_materno_ As String
    Dim nombres_ As String
    Dim email_ As String

    Public Property id_usuario() As Integer
        Get
            Return id_usuario_
        End Get
        Set(ByVal value As Integer)
            id_usuario_ = value
        End Set
    End Property

    Public Property administrador() As Boolean
        Get
            Return administrador_
        End Get
        Set(ByVal value As Boolean)
            administrador_ = value
        End Set
    End Property

    Public Property usuario() As String
        Get
            Return usuario_
        End Get
        Set(ByVal value As String)
            usuario_ = value
        End Set
    End Property

    Public Property password() As String
        Get
            Return password_
        End Get
        Set(ByVal value As String)
            password_ = value
        End Set
    End Property

    Public Property apellido_paterno() As String
        Get
            Return apellido_paterno_
        End Get
        Set(ByVal value As String)
            apellido_paterno_ = value
        End Set
    End Property

    Public Property apellido_materno() As String
        Get
            Return apellido_materno_
        End Get
        Set(ByVal value As String)
            apellido_materno_ = value
        End Set
    End Property
    Public Property nombres() As String
        Get
            Return nombres_
        End Get
        Set(ByVal value As String)
            nombres_ = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return email_
        End Get
        Set(ByVal value As String)
            email_ = value
        End Set
    End Property

End Class
