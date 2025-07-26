Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = "HelloWorld!"
    End Sub

    Public ReadOnly Property GetFolderPath As String
        Get
            Return Environment.CurrentDirectory
        End Get
    End Property
End Class
