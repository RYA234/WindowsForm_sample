Imports System
Imports System.Threading
Imports TestStack.White
Imports TestStack.White.UIItems
Imports TestStack.White.UIItems.WindowItems
Imports TestStack.White.UIItems.Finders
Imports Xunit
Imports TestStack.White.Factory
Imports VBWinform
Imports System.IO
Imports System.Data.SqlClient


Public Class NotepadTestsAdvanced
    Implements IDisposable

    Private application As Application
    Private window As Window


    Private Shared ReadOnly testProjectName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
    Private Shared ReadOnly solutionPath As String = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(testProjectName))
    Private Shared ReadOnly NotepadAppId As String = Path.Combine(solutionPath + "\VBWinform\bin\Debug", "VBWinform.exe")

    Private connectionString As String = "Server=127.0.0.1,1432;Database=master;User Id=sa;Password=user@12345;"


    Public Sub New()

        ' データベース初期化
        InitializeDatabase()

        ' CSVファイルからデータを読み込んで、Insert
        Dim csvPath As String = Path.Combine(solutionPath + "\WhiteGUITest", "testdata.csv")
        LoadDataFromCsv(csvPath)

        ' アプリケーション起動
        application = Application.Launch(NotepadAppId)
        Thread.Sleep(500) ' ウィンドウが開くまで待機
        window = application.GetWindow("Form1", InitializeOption.NoCache)
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        ' テスト完了後のクリーンアップ
        CleanupDatabase()
        Try
            If window IsNot Nothing AndAlso Not window.IsClosed Then
                window.Close()
            End If
        Catch ex As Exception
            ' ウィンドウが既に閉じている場合のエラーを無視
        End Try

        If application IsNot Nothing Then
            application.Close()
            application.Dispose()
        End If

    End Sub

    ''' <summary>
    ''' データベースを初期化（テーブルの削除と再作成）
    ''' </summary>
    Private Sub InitializeDatabase()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' 既存テーブルを削除
            Dim dropTableSql As String = "DELETE FROM dbo.TestUsers;"

            Using cmd As New SqlCommand(dropTableSql, conn)
                cmd.ExecuteNonQuery()
            End Using

            Console.WriteLine("データベースを初期化しました。")
        End Using
    End Sub

    ''' <summary>
    ''' CSVファイルからデータを読み込んでInsert
    ''' </summary>
    ''' <param name="csvFilePath">CSVファイルのパス</param>
    Private Sub LoadDataFromCsv(csvFilePath As String)
        If Not File.Exists(csvFilePath) Then
            Console.WriteLine($"CSVファイルが見つかりません: {csvFilePath}")
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' CSVファイルを読み込み
            Dim lines As String() = File.ReadAllLines(csvFilePath)

            ' ヘッダー行をスキップ（最初の行がヘッダーの場合）
            For i As Integer = 1 To lines.Length - 1
                Dim values As String() = lines(i).Split(","c)

                If values.Length >= 3 Then
                    Dim insertSql As String = "
                            INSERT INTO dbo.TestUsers (Name, Email, Age)
                            VALUES (@Name, @Email, @Age);
                        "

                    Using cmd As New SqlCommand(insertSql, conn)
                        cmd.Parameters.AddWithValue("@Name", values(0).Trim())
                        cmd.Parameters.AddWithValue("@Email", values(1).Trim())

                        Dim age As Integer
                        If Integer.TryParse(values(2).Trim(), age) Then
                            cmd.Parameters.AddWithValue("@Age", age)
                        Else
                            cmd.Parameters.AddWithValue("@Age", 0)
                        End If

                        cmd.ExecuteNonQuery()
                    End Using
                End If
            Next

            Console.WriteLine($"CSVファイルからデータを読み込みました: {lines.Length - 1}件")
        End Using
    End Sub


    ''' <summary>
    ''' データが正しく挿入されたかを確認するヘルパーメソッド
    ''' </summary>
    Private Function GetRecordCount() As Integer
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim countSql As String = "SELECT COUNT(*) FROM dbo.TestUsers;"

            Using cmd As New SqlCommand(countSql, conn)
                Return CInt(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    ''' <summary>
    ''' データベースをクリーンアップ
    ''' </summary>
    Private Sub CleanupDatabase()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' テストデータを削除
            Dim deleteSql As String = "DELETE FROM dbo.TestUsers;"

            Using cmd As New SqlCommand(deleteSql, conn)
                cmd.ExecuteNonQuery()
            End Using

            Console.WriteLine("データベースをクリーンアップしました。")
        End Using
    End Sub


    <Fact>
    Public Sub レコードの件数が取得できていること()
        Dim textBox = window.Get(Of TextBox)("CountText")
        Assert.Equal("3", textBox.Text)
    End Sub


End Class