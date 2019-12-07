Feature: BBCTest1
	In order to read News on BBC
	As an avid News reader
	I want to be able to read News and look for them on BBC Website 

Scenario: First articles block found
	When I go to BBC News tab
	|ArticleName|
	 |US and Iranian men released in prisoner swap|
	 |Oceans running out of oxygen say scientists|
	 |Woman set on fire on way to rape hearing dies|
	 |Divisive UK election campaign reaches climax|
	 |Bosnia's 'inhumane' conditions put migrants at risk|
	 |Ronaldo and Buffon meet boys who survived quake|
	Then I should see top articles block

Scenario: Keyword search completed successfully
	When I search for some news using top article keyword
	Then I should see keyword results

	