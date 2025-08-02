
Imports Microsoft.Data.SqlClient
Imports Testcontainers.MsSql
Imports Xunit
Imports Testcontainers.PostgreSql
Imports Npgsql
Imports System.Data


Public Class MsSqlContainerTest

    <Fact>
    <Obsolete>
    Public Async Function ConnectionStateReturnsOpen() As Task
        ' SQL Server コンテナを構築
        Dim container = New MsSqlBuilder().
            WithPassword("yourStrong(!)Password").Build

        ' コンテナ起動
        Await container.StartAsync()

        ' 接続文字列取得
        Dim connectionString As String = container.GetConnectionString()

        ' 接続確認（リトライ付き）
        Dim connected As Boolean = False
        Dim retryCount As Integer = 5
        Dim delayMs As Integer = 2000

        For i As Integer = 1 To retryCount
            Try
                Dim connection As New System.Data.SqlClient.SqlConnection(connectionString)
                connection.Open()
                Assert.Equal(ConnectionState.Open, connection.State)
                connected = True
                Exit For

            Catch ex As Exception
                If i = retryCount Then
                    Throw New Exception("接続に失敗しました", ex)
                End If
                Task.Delay(delayMs)
            End Try
        Next

        Assert.True(connected, "SQL Server コンテナに接続できませんでした。")

        ' コンテナ停止・破棄
        Await container.DisposeAsync()
    End Function


    <Fact>
    Public Async Function ConnectionStateReturnpsql() As Task
        ' SQL Server コンテナを構築
        Dim container = New PostgreSqlBuilder().
                           Build()

        ' コンテナ起動
        Await container.StartAsync()

        ' 接続文字列取得
        Dim connectionString As String = container.GetConnectionString()

        ' 接続確認（リトライ付き）
        Dim connected As Boolean = False
        Dim retryCount As Integer = 5
        Dim delayMs As Integer = 2000

        For i As Integer = 1 To retryCount
            Try
                Using connection As New NpgsqlConnection(connectionString)
                    Await connection.OpenAsync()
                    Assert.Equal(ConnectionState.Open, connection.State)
                    connected = True
                    Exit For
                End Using
            Catch ex As Exception
                If i = retryCount Then
                    Throw New Exception("接続に失敗しました", ex)
                End If
                Task.Delay(delayMs)
            End Try
        Next

        Assert.True(connected, "SQL Server コンテナに接続できませんでした。")

        ' コンテナ停止・破棄
        Await container.DisposeAsync()
    End Function

End Class
