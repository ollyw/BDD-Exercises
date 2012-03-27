Feature: Multiple rounds
	In order to play a game
	As a Paper Stone Scissors enthusiast
	I want to be able to play one or more rounds against multiple players

Scenario: Two players, one round game
	Given I have chosen a first to 1 game
	When I lose one round
	Then I should lose the game

Scenario: Two players, three round game
	Given I have chosen a first to 3 game
	When I lose one round
	Then the game should not be complete