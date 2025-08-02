Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient

Public NotInheritable Class DbConnectionProvider

    Private ReadOnly _connectionString As String

    Public Sub New(connectionString As String)
        _connectionString = connectionString
    End Sub

    Public Function GetConnection() As DbConnection
        ' SqlConnection は IDbConnection を実装しているので、このまま返せる
        Return New SqlConnection(_connectionString)
    End Function

End Class
