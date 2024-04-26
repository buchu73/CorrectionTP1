using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public string Add(List<int> numbers)
        {
            int result = 0;
            foreach (int number in numbers)
            {
                result += number;
            }

            return result.ToString();
        }

        public string Substract(List<int> numbers)
        {
            int result = numbers[0];
            for (int i = 1; i != numbers.Count; ++i)
            {
                result -= numbers[i];
            }

            return result.ToString();
        }

        public string Multiply(List<int> numbers)
        {
            int result = numbers[0];
            for (int i = 1; i != numbers.Count; ++i)
            {
                result *= numbers[i];
            }

            return result.ToString();
        }

        public string Divide(List<int> numbers)
        {
            try
            {
                int result = numbers[0];
                for (int i = 1; i != numbers.Count; ++i)
                {
                    result /= numbers[i];
                }

                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Cannot divide by zero";
            }
        }

        public string DivideWithThrow(List<int> numbers)
        {
            try
            {
                int result = numbers[0];
                for (int i = 1; i != numbers.Count; ++i)
                {
                    result /= numbers[i];
                }

                return result.ToString();
            }
            catch (Exception)
            {
                throw new Exception("Cannot divide by zero");
            }
        }

        public string ComputeFormula(List<int> inputNumbers, List<string> operators)
        {
            // 10*2+5-4=21
            // result = 10*2
            // result = result + 5
            // result = result - 4

            int left = inputNumbers[0];
            string result = "";
            for (int i = 1; i != inputNumbers.Count; ++i)
            {
                string ope = operators[i-1];
                int right = inputNumbers[i];

                List<int> operands = new List<int>()
                {
                    left, right
                };

                switch (ope)
                {
                    case "+":
                        result = this.Add(operands);
                        break;

                    case "-":
                        result = this.Substract(operands);
                        break;

                    case "*":
                        result = this.Multiply(operands);
                        break;

                    case "/":
                        result = this.Divide(operands);
                        break;

                    default:
                        break;
                }

                if (!int.TryParse(result, out left))
                {
                    return result;
                }
            }

            return result;
        }

        public string ComputePriorityFormula(string formulaToCompute)
        {
            try
            {
                var script = CSharpScript.Create<double>(formulaToCompute);
                var compilation = script.RunAsync().Result;
                return compilation.ReturnValue.ToString();
            }
            catch (CompilationErrorException ex)
            {
                Console.WriteLine($"Error compiling expression: {ex.Message}");
                return double.NaN.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error evaluating expression: {ex.Message}");
                return double.NaN.ToString();
            }
        }
    }
}
