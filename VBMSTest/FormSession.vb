Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium.Appium.Windows
Imports OpenQA.Selenium.Remote
Imports System
Imports System.IO

Namespace VBMSTest
    ' 初期設定と後処理を行う基底クラス
    Public Class FormSession
        Protected Const WindowsApplicationDriverUrl As String = "http://127.0.0.1:4723"

        ' テストのプロジェクト名を取得
        Private Shared ReadOnly testProjectName As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
        Private Shared ReadOnly solutionPath As String = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf(testProjectName))
        Private Shared ReadOnly NotepadAppId As String = Path.Combine(solutionPath + "\VBWinform\bin\Debug", "VBWinform.exe")
        Protected Shared session As WindowsDriver(Of WindowsElement)
        Protected Shared editBox As WindowsElement

        Public Shared Sub Setup()
            If session Is Nothing Then
                Dim appCapabilities As New DesiredCapabilities()
                appCapabilities.SetCapability("app", NotepadAppId)
                session = New WindowsDriver(Of WindowsElement)(New Uri(WindowsApplicationDriverUrl), appCapabilities)
                Assert.AreEqual("Form1", session.Title)
            End If
        End Sub

        ' セッションを終了し、アプリケーションを閉じる
        Public Shared Sub TearDown()
            If session IsNot Nothing Then
                session.Close()
                session.Quit()
                session = Nothing
            End If
        End Sub
    End Class
End Namespace
