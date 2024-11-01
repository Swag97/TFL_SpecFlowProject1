Feature:Feature 1 : Plan a Journey with Valid and Invalid Inputs

Scenario 1: Plan a journey from Leicester Square Underground Station to Covent Garden Underground station
Scenario 2: Click on Edit preferences button and select least walking time option. Update the journey and validate journey time.
Scenario 3: Click on view details button and verify steps displayed below 

@Scenario1
Scenario: Scenario1_Plan a journey
	Given Open the browser	
	When  Navigate to 'https://tfl.gov.uk/plan-a-journey'
	Then Enter partial text 'Lei' from FROM station in from field
     And Select 'Leicester Square Underground Station' from the dropdown
	Then Enter partial text 'Cov' from TO station in To field
	And Select 'Covent Garden Underground Station' from the dropdown.
	When Click on Plan Journey button
	Then the journey details should be displayed
@Scenario2
 Scenario: Scenario2_Edit Preferences
	Given We are on Journey Results page
	Then Click on Edit Preferences button
	And Select Routes with least walking
	When Click on Update Journey Button
	Then Updated journey Details should be present
@Scenario3
Scenario: Scenario3_View Details
	Given Updated journey details are displayed
	Then Click on View Details button
	When Details are displayed
	Then Verify steps to be followed at 'Covent Garden Underground Station'
   