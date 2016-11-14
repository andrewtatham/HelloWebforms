Feature: Navigation
	As a developer
	In order to get dollar dollar bills y'all
	When I navigate to the home page
	It should all be awesome




@mytag
    Scenario: I can open the Home page
	Given I am on the Home page
	Then I am on the Home page

	Scenario: I can open the About Page
	Given I am on the About page
	Then I am on the About page

    Scenario: I can open the contact page
	Given I am on the Contact page
	Then I am on the Contact page
	




	Scenario: I can navigate from the Home page to the About page
	Given I am on the Home page
	When I navigate to the About page
	Then I am on the About page

	
	Scenario: I can navigate from the Home page to the Contact page
	Given I am on the Home page
	When I navigate to the Contact page
	Then I am on the Contact page
