Feature: Best-Of Style Game Play
	In order to play a game that finishes in a fixed maximum number of rounds
	As a Paper Stone Scissors enthusiast
	I want to be able to play a game that finishes when a user wins the majority of a fixed number of rounds

Scenario: Two players, three round game
	Given I have chosen a best of 3 game
	When I win 2 rounds
	Then the game should be complete

Scenario: Two players, five round game
	Given I have chosen a best of 5 game
	When I win 2 rounds
	Then the game should not be complete

Scenario: Three players, best of five
	Given a game with 3 players and best of 5
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | win      | lose     | lose     |
		| 2     | win      | lose     | lose     |
		| 3     | lose     | win      | lose     |
		| 4     | win      | lose     | lose     |
	Then player 1 should be the winner

Scenario: Three players, best of seven
	Given a game with 3 players and best of 5
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | win      | lose     | lose     |
		| 2     | lose     | win      | lose     |
		| 3     | lose     | lose     | win      |
		| 4     | draw     | draw     | draw     |
		| 5     | lose     | win      | lose     |
	Then player 2 should be the winner

Scenario: Three players, best of three with no winner
	Given a game with 3 players and best of 3
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | draw     | draw     | draw     |
		| 2     | draw     | draw     | draw     |
		| 3     | draw     | draw     | draw     |
	Then there should be no winner