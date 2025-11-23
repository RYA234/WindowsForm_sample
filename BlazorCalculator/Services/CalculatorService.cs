using System;

namespace BlazorCalculator.Services
{
    public class CalculatorService
    {
        private string _input = string.Empty;
        private string _operand1 = string.Empty;
        private string _operand2 = string.Empty;
        private char _operation;
        private double _result = 0.0;

        public string DisplayText { get; private set; } = "";

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AppendNumber(string number)
        {
            DisplayText = ""; // Clear display on new input start if needed, mimicking Form1 logic roughly but let's see.
            // Form1 logic: textBox1.Text = ""; input += "1"; textBox1.Text += input;
            // Actually Form1 clears textbox then appends input.
            
            _input += number;
            DisplayText = _input;
            NotifyStateChanged();
        }

        public void AppendDecimal()
        {
            if (!_input.Contains("."))
            {
                _input += ".";
                DisplayText = _input;
                NotifyStateChanged();
            }
        }

        public void SetOperation(char op)
        {
            _operand1 = _input;
            _operation = op;
            _input = string.Empty;
            // Form1 doesn't update display here, but usually calculators do. 
            // Form1 just clears input. Display remains showing operand1 until next number? 
            // Form1 code: 
            // operand1 = input; operation = '*'; input = string.Empty;
            // It doesn't touch textBox1.Text here. So it keeps showing the last input.
        }

        public void Calculate()
        {
            _operand2 = _input;
            double num1, num2;
            double.TryParse(_operand1, out num1);
            double.TryParse(_operand2, out num2);

            if (_operation == '+')
            {
                _result = num1 + num2;
            }
            else if (_operation == '-')
            {
                _result = num1 - num2;
            }
            else if (_operation == '*')
            {
                _result = num1 * num2;
            }
            else if (_operation == '/')
            {
                if (num2 != 0)
                {
                    _result = num1 / num2;
                }
                else
                {
                    DisplayText = "ERROR DIV BY ZERO";
                    NotifyStateChanged();
                    return;
                }
            }

            DisplayText = _result.ToString();
            // Reset for next calculation? Form1 doesn't explicitly reset input/operands after calc, 
            // but usually you'd want to use the result as next operand1.
            // Form1 just updates textBox1.Text.
            
            // To allow chaining, we might want to set input to result?
            // But sticking to Form1 logic strictly:
            // It just sets textBox1.Text.
            
            NotifyStateChanged();
        }

        public void Clear()
        {
            DisplayText = "";
            _input = string.Empty;
            _operand1 = string.Empty;
            _operand2 = string.Empty;
            _operation = '\0';
            _result = 0.0;
            NotifyStateChanged();
        }
    }
}
