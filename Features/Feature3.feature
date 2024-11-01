Feature: Feature 3: Plan a journey with blank TO and From Stations

Plan a journey with blank TO and From Stations and verify error messages
@Scenario4
Scenario: Scenario4_InvalidJourney
Given we are on PLan Journey page
When Plan dourney page is displayed
	Then leave FROM station blank
	And leave TO station blank
	Then CLick on Plan Journey button
	Then Error message should be displayed