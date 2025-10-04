Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = "HelloWorld!"
    End Sub
    Private connectionString As String = "Server=127.0.0.1,1432;Database=master;User Id=sa;Password=user@12345;"

    Public ReadOnly Property GetFolderPath As String
        Get
            Return Environment.CurrentDirectory
        End Get
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim countSql As String = "SELECT COUNT(*) FROM dbo.TestUsers;"

            Using cmd As New SqlCommand(countSql, conn)
                CountText.Text = CInt(cmd.ExecuteScalar())
            End Using
        End Using

    End Sub
End Class
