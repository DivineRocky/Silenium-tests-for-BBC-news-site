Feature: BBCTests2
	In order to ask the BBC team a question
	As an avid BBC News reader
	I want to be able to send Question Form

Scenario: Submission completed successfully
	Given I want to ask a question to BBC Team
	When I submit the Question Form with all fields fulfilled
	Then I should see the Question Form sent confirmation

Scenario: Cannot submit the Question Form unless Question Field fulfilled
	Given I want to ask a question to BBC Team
	When I submit the Question Form without Question Form fulfilled 
	Then I should see an error message telling me I must fulfill the Question Form field
	
Scenario: Cannot submit the Question Form unless Name Field fulfilled
	Given I want to ask a question to BBC Team
	When I submit the Question Form without Name field fulfilled
	Then I should see an error message telling me I must fulfill the Name field
	
Scenario: Cannot submit the Question Form unless Email Field fulfilled
	Given I want to ask a question to BBC Team
	When I submit the Question Form without Email field fulfilled
	Then I should see an error message telling me I must fulfill the Email field


	 