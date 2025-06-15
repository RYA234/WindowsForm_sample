using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Microsoft.ServiceBus.Configuration;
using System;
using System.IO;

namespace UITestSample.Test
{
    // 初期設定、最後の後処理をするクラス  
    // シナリオテストの継承元のクラス  
    public class FormSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private static readonly string NotepadAppId = Path.Combine(Environment.CurrentDirectory, "WindowsForm_sample.exe");
        protected static WindowsDriver<OpenQA.Selenium.Appium.Windows.WindowsElement> session;
        protected static OpenQA.Selenium.Appium.Windows.WindowsElement editBox;

        public static void Setup(TestContext context)
        {
            if (session == null)
            {
                DesiredCapabilities appCapabilities = new OpenQA.Selenium.Remote.DesiredCapabilities();
                appCapabilities.SetCapability("app", NotepadAppId);
                session = new WindowsDriver<OpenQA.Selenium.Appium.Windows.WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
                Assert.AreEqual("Form1", session.Title);
            }
        }

        // セッションを切って　アプリケーションを閉じる  
        public static void TearDown()
        {
            // Close the application and delete the session  
            if (session != null)
            {
                session.Close();
                session.Quit();
                session = null;
            }
        }
    }
}
