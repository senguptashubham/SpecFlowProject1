Feature: DataTableDriven

A short summary of the feature

@tag1
Scenario: Search text from data table
	Given user is on landing page
	When user searches text from data table
	| searchKey |
	| Dell      |
	| Acer      |
	Then text should be displayed in title
