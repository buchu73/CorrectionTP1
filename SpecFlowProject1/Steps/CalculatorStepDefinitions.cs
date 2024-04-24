using TechTalk.SpecFlow;
using CalculatorLibrary;
using FluentAssertions;
using System.Collections.Generic;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly List<int> _inputNumbers = new List<int>();
        private readonly List<string> _operators = new List<string>();
        private string _result;

        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            this._inputNumbers.Insert(0, number);
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this._inputNumbers.Add(number);
        }

        [Given(@"numbers are")]
        public void GivenNumbersAre(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                int value = int.Parse(row[0]);
                this._inputNumbers.Add(value);
            }
        }

        [Given(@"formula is")]
        public void GivenFormulaIs(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string ope = row[0];
                if (!string.IsNullOrWhiteSpace(ope))
                {
                    this._operators.Add(ope);
                }

                int value = int.Parse(row[1]);
                this._inputNumbers.Add(value);
            }
        }


        [When("numbers are added")]
        public void WhenNumbersAreAdded()
        {            
            Calculator calculator = new Calculator();
            this._result = calculator.Add(this._inputNumbers);
        }

        [When("numbers are substracted")]
        public void WhenNumbersAreSubstracted()
        {
            Calculator calculator = new Calculator();
            this._result = calculator.Substract(this._inputNumbers);
        }

        [When("numbers are multiplied")]
        public void WhenNumbersAreMultiplied()
        {
            Calculator calculator = new Calculator();
            this._result = calculator.Multiply(this._inputNumbers);
        }

        [When(@"numbers are divided")]
        public void WhenNumbersAreDivided()
        {
            Calculator calculator = new Calculator();
            this._result = calculator.Divide(this._inputNumbers);
        }

        [When(@"formula is computed")]
        public void WhenFormulaIsComputed()
        {
            Calculator calculator = new Calculator();
            this._result = calculator.ComputeFormula(this._inputNumbers, this._operators);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            this._result.Should().Be(result);
        }      
    }
}
