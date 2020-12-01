Feature: Question

@mytag
Scenario: A question can't be registered with less than two choices
	Given A question with only one choice
	When is tried to register
	Then should gives an exception