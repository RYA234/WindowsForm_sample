' FormのUI要素のプロパティを取得するためのアダプタークラス
' UIはデフォルトでFormのインスタンスを渡す
Public Class TestUIAdapter
    Private ReadOnly _form As Form

    ' コンストラクタでFormインスタンスを受け取る
    Public Sub New(form As Form)
        _form = form
    End Sub

    ' FormのDatePickerの値を取得する
    Public Function GetDatePickerValue(datePickerName As String) As DateTime
        Dim picker = TryCast(_form.Controls(datePickerName), DateTimePicker)
        If picker IsNot Nothing Then
            Return picker.Value
        Else
            Throw New ArgumentException("指定されたDatePickerが見つかりません: " & datePickerName)
        End If
    End Function

    ' FormのTextBoxのテキストを取得する
    Public Function GetTextBox(textBoxName As String) As TextBox
        Dim textBox = TryCast(_form.Controls(textBoxName), TextBox)
        If textBox IsNot Nothing Then
            Return textBox
        Else
            Throw New ArgumentException("指定されたTextBoxが見つかりません: " & textBoxName)
        End If
    End Function

    ' 使い方例:
    ' Dim adapter As New TestUIAdapter(Me)
    ' Dim dateValue As DateTime = adapter.GetDatePickerValue("dateTimePicker1")
    ' Dim textValue As String = adapter.GetTextBoxText("textBox1")
End Class
