Feature: 2ndTaskBBCTests
	In order to ask the BBC team a question
	As an avid BBC reader
	I want to be able to submit a question form

Scenario: Submitting Question Form without Text field
	When I fulfill a Question Form without Text field
	| Name  | Text      | Email             |
	| Maria |	        | random@random.com |

	Then an Empty Text Error occurs
	| ErrorMessage   |
	| can't be blank |

Scenario: Submitting Question Form without Name field
	When I fulfill a Question Form without Name field
	| Name  | Text      | Email             |
	|       | Some text | random@random.com |


	Then an Empty Name Error occurs
	| ErrorMessage		  |
	| Name can't be blank |

Scenario: Submitting Question Form without Email field
	When I fulfill a Question Form without Email field
	| Name  | Text      | Email |
	| Maria | Some text |		|

	Then an Empty Email Error occurs
	| ErrorMessage				   |
	| Email address can't be blank |