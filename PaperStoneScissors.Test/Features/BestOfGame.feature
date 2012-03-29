Feature: Best-Of Style Game Play
	In order to play a game that finishes in a fixed maximum number of rounds
	As a Paper Stone Scissors enthusiast
	I want to be able to play a game that finishes when a user wins the majority of a fixed number of rounds

Scenario: Two players, three round game
	Given I have chosen a best of 3 game
	When I win 2 rounds
	Then the game should be complete
