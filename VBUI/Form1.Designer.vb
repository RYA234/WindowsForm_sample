<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.名前 = New System.Windows.Forms.TextBox()
        Me.申請日時 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        '名前
        '
        Me.名前.Location = New System.Drawing.Point(54, 163)
        Me.名前.Name = "名前"
        Me.名前.Size = New System.Drawing.Size(100, 19)
        Me.名前.TabIndex = 1
        '
        '申請日時
        '
        Me.申請日時.CustomFormat = "yyyy-MM-dd"
        Me.申請日時.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.申請日時.Location = New System.Drawing.Point(54, 95)
        Me.申請日時.Name = "申請日時"
        Me.申請日時.Size = New System.Drawing.Size(109, 19)
        Me.申請日時.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(557, 27)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "UIのプロパティのテストコードについてのサンプルページ"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.申請日時)
        Me.Controls.Add(Me.名前)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 名前 As TextBox
    Friend WithEvents 申請日時 As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
