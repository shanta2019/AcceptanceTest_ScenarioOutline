Feature: AddSkills
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: check if user is able to Add multiple skills
	Given I have cliked on profoel tab and add new skill tab
	When I enter skill details < Skill > and < Level >
	And I click add button
	Then skill should be added to profiel
Examples: 
         | Skill    | Level    |
         | C#       | Beginner |
         | Selenium | Beginner |
         | Java     | Beginner |
