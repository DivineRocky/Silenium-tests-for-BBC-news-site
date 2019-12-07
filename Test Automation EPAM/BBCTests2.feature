Feature: BBCTests2
	In order to ask the BBC team a question
	As an avid BBC News reader
	I want to be able to send a Question Form

Scenario: Submission completed successfully
	When I submit the Question Form with all fields fulfilled
	Then I should see the Question Form sent confirmation

Scenario: Cannot submit the Question Form unless Question Field fulfilled
	When I submit the Question Form without Question Form fulfilled 
	Then I should see an error message telling me I must fulfill the Question Form field
	
Scenario: Cannot submit the Question Form unless Name Field fulfilled
	When I submit the Question Form without Name field fulfilled
	Then I should see an error message telling me I must fulfill the Name field
	
Scenario: Cannot submit the Question Form unless Email Field fulfilled
	When I submit the Question Form without Email field fulfilled
	Then I should see an error message telling me I must fulfill the Email field


	 