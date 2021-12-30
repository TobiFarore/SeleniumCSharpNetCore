Feature: Login
	Check if login functionality works

@smoke 
Scenario: Login user as Administrator
	Given I have navigated to the application
	And I click the login Link
	And I enter Username and Password
	| Username | Password |
	| admin    | password |
	Then I click login button
	Then I should see user logged in to the application