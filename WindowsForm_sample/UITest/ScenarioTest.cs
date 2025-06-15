using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITestSample.Test
{
    [TestClass]
    public class ScenarioTest : FormSession
    {
        [TestMethod]
        public void ボタンを押すとHelloWorlが表示される()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            session.FindElementByName("button1").Click();
            string result = session.FindElementByAccessibilityId("textBox1").Text;
            Assert.AreEqual("Hello World", result);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

    }
}
