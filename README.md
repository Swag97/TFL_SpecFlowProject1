TFL Coding Challenge:
The below sections highlights of the process of creation of TFL coding challenge using
SpecFlow C# framework and follows behavior driver development approach and ensuring data protection by implementing concepts like encapsulation, inheritance etc.
:
-	Added SpecFlow Extension to Visual Studio 
-	Created new project
-	Added all necessary packages from Manage NuGet package manager.
-	Create 3 feature files:
1.	Feature1 – Plan a Journey – covering the first 3 scenarios from coding challenge
2.	Feature 2 – Plan a journey with invalid data
3.	Feature 3 – Plan a journey with blank From and To stations.
                         
-	Created corresponding StepDefinition files
-	Feature1StepDefinition File consist of 3 testcases.
-	Implemented Hooks.cs class in Hooks folder which handles all hooks in framework
-	[BeforeFixtures],[AfterFixture] contains driver trigger, report trigger.
-	[AfterScenario] contains container instance
-	 
-	This approach helped me run 
1.	3 cases from Feature 1 on single instance and achieved continuous execution.
2.	Feature 2 has 1 case – independent case with new instance
3.	Feature 3 has 1 case – independent case with ne instance.
 
-	Achieved report generation by using implementing Extent Reports
-	Created a folder called PageObjects which has a class called PageObject.cs
Which contains all the element locators achieving encapsulation.
 
-	Created Utility folder which contains:
 	Base.cs – user defined reusable methods
ExtentReport – handles reports setup
 
-	Html report will be generated in TestResults – index.html
 

 
