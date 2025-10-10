Imports System.Drawing
Imports TestStack.White.UIItems
Imports VBUI
Imports Xunit

Public Class UIPropertyTest
    <Fact>
    Public Sub FormのコントロールTextBoxのプロパティ情報をテストする()
        Dim ctrlName As String = "名前"

        ' Arrange 
        Dim form As New VBUI.Form1()
        Dim textBox As New System.Windows.Forms.TextBox()

        ' Act
        Dim adapter As New TestUIAdapter(form)
        Dim targetTextBox = adapter.GetTextBox(ctrlName)

        ' Assert
        Assert.Equal("Window", targetTextBox.BackColor.Name) ' 背景色
        Assert.Equal("WindowText", targetTextBox.ForeColor.Name)        ' 前景色
        Assert.Equal("MS UI Gothic", targetTextBox.Font.Name)    ' フォント名
        Assert.Equal(9.0F, targetTextBox.Font.Size)             ' フォントサイズ
        Assert.Equal(19, targetTextBox.Size.Height)              ' 高さ
    End Sub
End Class

