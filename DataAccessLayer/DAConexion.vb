Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DAConexion

    Private _DataBase As String

    Sub New()
        _DataBase = ConfigurationManager.ConnectionStrings("laconexion").ConnectionString
    End Sub


    'PORTAL
    Public Function ConnecionStringPortal() As String
        Try
            Return DataBasePORTAL()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Function

    Public Property DataBasePORTAL() As String
        Get
            Return _DataBase
        End Get
        Set(ByVal value As String)
            _DataBase = value
        End Set
    End Property

End Class

