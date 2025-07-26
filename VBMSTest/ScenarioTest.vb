Imports System
Imports System.Threading
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium.Appium.Windows
Imports Xunit

Namespace VBMSTest
    'MSTestのアノテーションだがこれないとテストが実行されない（どういうことだよ.....?ｗ）
    <TestClass>
    Public Class ScenarioTest
        Inherits FormSession

        'MSTestのアノテーションで使えないのでコメントアウト
        '<ClassInitialize>
        Public Shared Sub ClassInitialize()
            Setup()
        End Sub

        ''MSTestのアノテーションで使えないのでコメントアウト
        '<ClassCleanup>
        Public Shared Sub ClassCleanup()
            TearDown()
        End Sub

        ' XUnitのアノテーションで使えるのでこちらを使用
        <Fact>
        Public Sub ボタンを押すとHelloWorldが表示される()
            Setup()
            Thread.Sleep(TimeSpan.FromSeconds(2))
            session.FindElementByName("Button1").Click()
            Dim result As String = session.FindElementByAccessibilityId("TextBox1").Text
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("HelloWorld!", result)
            TearDown()
        End Sub
    End Class

End Namespace
