Feature: Login
	I can log in and out
	I can register a new account




Scenario: I can log in
	Given I am on the Home page
	And I am logged out
	When I navigate to the Log In page
	And I enter my account details
		|email|password|
		|andrewtatham@gmail.com|P@ssw0rd|
	Then I am logged in

Scenario: I can log out
	Given I am on the Home page
	And I am logged in with
		|email|password|
		|andrewtatham@gmail.com|P@ssw0rd|
	When I log out
	Then I am logged out

@ignore
Scenario:I can register a new account
	Given I am on the Register page
	When I enter my account details
		|email|password|
		|andrewtatham@gmail.com|P@ssw0rd|
	Then I am logged in


