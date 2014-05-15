Feature: StringCalculator
	In order to x
	As a math idiot
	I want to be told the sum of two numbers

@AddTwoNumbers
Scenario: Add two numbers
	Given I have entered 1,2 into the calculator
	When I press add
	Then the result should be 3 on the screen
