Feature: Calculator
Simple calculator 

Scenario: Add two numbers
	Given the first number is 50
	And the first word is toto
	And the second number is 70
	And the number is 50 and the second number is 70
	When numbers are added
	Then the result should be 120

Scenario: Substract two numbers
	Given the first number is 50
	And the second number is 70
	When numbers are substracted
	Then the result should be -20

Scenario: Multiply two numbers
	Given the first number is 4
	And the second number is 2
	When numbers are multiplied
	Then the result should be 8

Scenario Outline: Divide two numbers
	Given the first number is <number1>
	And the second number is <number2>
	When numbers are divided
	Then the result should be <result>
	Examples: 
	| number1 | number2 | result                |
	| 10      | 2       | 5                     |
	| 10      | 0       | Cannot divide by zero |

Scenario: Divide two numbers with throw exception on divide by zero
	Given the first number is 10
	And the second number is 0
	When numbers are divided bis
	Then the operation should throw an exception, with the message Cannot divide by zero


# Scenario with N numbers

Scenario: Add N numbers
	Given numbers are 
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When numbers are added
	Then the result should be 37

Scenario: Substract N numbers
	Given numbers are 
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When numbers are substracted
	Then the result should be 13

Scenario: Multiply N numbers
	Given numbers are 
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When numbers are multiplied
	Then the result should be 500

Scenario: Divide N numbers
	Given numbers are 
	| Numbers |
	| 20      |
	| 2       |
	| 2       |
	When numbers are divided
	Then the result should be 5

Scenario: Divide N numbers - with divide by zero
	Given numbers are 
	| Numbers |
	| 20      |
	| 0       |
	| 2       |
	When numbers are divided
	Then the result should be Cannot divide by zero

# Scenario with formula

Scenario: Calculate Formula with N numbers and N operators without priority, ex: 10*2+5-4=21
Given formula is 
	| Operator | Numbers |
	|          | 10      |
	| *        | 2       |
	| +        | 5       |
	| -        | 4       |
	When formula is computed
	Then the result should be 21

Scenario: Calculate Formula with N numbers and N operators without priority and with divide by zero, ex: 10*2/0-4=Cannot divide by zero
Given formula is 
	| Operator | Numbers |
	|          | 10      |
	| *        | 2       |
	| /        | 0       |
	| -        | 4       |
	When formula is computed
	Then the result should be Cannot divide by zero

Scenario: Calcuate a formula with another startegy, and priority handled
	Given formula is 1+3-4*8
	When formula with priority is computed
	Then the result should be -28
