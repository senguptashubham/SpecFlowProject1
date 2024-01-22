Feature: Data Driven

A short summary of the feature

@tag1
Scenario Outline: search with any text in flipkart
	Given user is on landing page
	When user search with <searchText>
	Then result displays <searchText>
	Examples: 
	| searchText |
	| Apple      |
	| Samsung    |
	| Lenovo     |


