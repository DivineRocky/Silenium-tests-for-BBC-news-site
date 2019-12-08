Feature: 1stTaskBBCTests
	In order to read News on BBC
	As an avid News reader
	I want to be able to read News and look for them on BBC Website 

Scenario: First articles block found
	When I go to BBC News tab
	Then I should see listed articles on page
	 |Title                                             |
	 |US navy base gunman 'watched mass-shooting videos'|
	 |Oceans running out of oxygen, say scientists      |
	 |UK wants to find how US trade document leaked     |
	 |Joshua reclaims heavyweight world titles          |
	 |Woman set on fire on way to rape hearing dies     |
	 |Ronaldo and Buffon meet boys who survived quake   |

Scenario: Keyword search completed successfully
	When I search for some news using top article keyword
	Then I should see keyword results

	