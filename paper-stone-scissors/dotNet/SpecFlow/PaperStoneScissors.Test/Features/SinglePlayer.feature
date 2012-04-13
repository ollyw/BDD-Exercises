# This might require a backboor/shim to force the computer decisions to be deterministic for testing purposes
# Not happy with a back door in production code.

Feature: Single Player against the computer
	In order enjoy a game of paper stone scissors
	As a loner
	I want to be able to play against the computer

@web
Scenario: Single player game
	Given I choose a single player first to 3 game
	When I make 3 choices
	Then the web game should be complete
	And I should see the winner of the game