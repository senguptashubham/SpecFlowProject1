Feature: Flipkart Test

A short summary of the feature

@flipkartSearchTest
Scenario: Search for product in Flipkart
	Given user is on landing page
	When user search with a keyword
	Then result is shown

@flipkartLoginTest
Scenario: Login to Flipkart
	Given user is on landing page
	When user enters phone number
	Then user requests otp