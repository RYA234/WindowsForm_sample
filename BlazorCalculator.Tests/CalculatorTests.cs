using Bunit;
using Xunit;
using BlazorCalculator.Components.Pages;
using Microsoft.Extensions.DependencyInjection;
using BlazorCalculator.Services;

namespace BlazorCalculator.Tests
{
    public class CalculatorTests : TestContext
    {
        public CalculatorTests()
        {
            // Register the CalculatorService
            Services.AddSingleton<CalculatorService>();
        }

        [Fact]
        public void Test_ButtonClick_WorksCorrectly()
        {
            // Arrange
            var cut = Render<Calculator>();

            // Act
            cut.Find("#Button1").Click();

            // Assert
            var display = cut.Find("#DisplayTextBox");
            Assert.Equal("1", display.GetAttribute("value"));
        }

        [Fact]
        public void Test_Addition_1Plus1Equals2()
        {
            // Arrange
            var cut = Render<Calculator>();

            // Act
            cut.Find("#Button1").Click();
            cut.Find("#ButtonAdd").Click();
            cut.Find("#Button1").Click();
            cut.Find("#ButtonEquals").Click();

            // Assert
            var display = cut.Find("#DisplayTextBox");
            Assert.Equal("2", display.GetAttribute("value"));
        }

        [Fact]
        public void Test_Division_100Divide10Equals10()
        {
            // Arrange
            var cut = Render<Calculator>();

            // Act
            cut.Find("#Button1").Click();
            cut.Find("#Button0").Click();
            cut.Find("#Button0").Click();
            
            cut.Find("#ButtonDivide").Click();
            
            cut.Find("#Button1").Click();
            cut.Find("#Button0").Click();
            
            cut.Find("#ButtonEquals").Click();

            // Assert
            var display = cut.Find("#DisplayTextBox");
            Assert.Equal("10", display.GetAttribute("value"));
        }

        [Fact]
        public void Test_Multiplication_100Times10Equals1000()
        {
            // Arrange
            var cut = Render<Calculator>();

            // Act
            cut.Find("#Button1").Click();
            cut.Find("#Button0").Click();
            cut.Find("#Button0").Click();
            
            cut.Find("#ButtonMultiply").Click();
            
            cut.Find("#Button1").Click();
            cut.Find("#Button0").Click();
            
            cut.Find("#ButtonEquals").Click();

            // Assert
            var display = cut.Find("#DisplayTextBox");
            Assert.Equal("1000", display.GetAttribute("value"));
        }

        [Fact]
        public void Test_ClearButton_ClearsDisplay()
        {
            // Arrange
            var cut = Render<Calculator>();

            // Act
            cut.Find("#Button5").Click();
            var displayBefore = cut.Find("#DisplayTextBox");
            Assert.Equal("5", displayBefore.GetAttribute("value"));

            cut.Find("#ButtonClear").Click();

            // Assert
            var displayAfter = cut.Find("#DisplayTextBox");
            Assert.Equal("", displayAfter.GetAttribute("value"));
        }
    }
}
