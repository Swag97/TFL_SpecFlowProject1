Feature: Feature 2 : Plan a Invalid Journey

Plan a journey from Invalid Station(s) to verify error message
@Scenario4
Scenario: Scenario4_InvalidJourney
	Given Navigate to 'https://tfl.gov.uk/plan-a-journey'
	When From and To station fields are displayed
	Then Enter Invalid From station - '!£$'
	And Enter Invalid To station - '@£$'
	Then CLick on Plan Journey Button
	Then Error message should be Displayed
