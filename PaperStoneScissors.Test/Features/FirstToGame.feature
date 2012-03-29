Feature: First-To Style Game Play
	In order to play a game that results in a single winner
	As a Paper Stone Scissors enthusiast
	I want to be able to play a game that finishes when the first player reaches a given number of wins

Scenario: Two players, one round game
	Given I have chosen a first to 1 game
	When I lose 1 round
	Then I should lose the game

Scenario: Two players, best of three not completed
	Given I have chosen a first to 3 game
	When I lose 1 round
	Then the game should not be complete

Scenario: Three players, first to three
	Given a game with 3 players and first to 3
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | win      | lose     | lose     |
		| 2     | win      | lose     | lose     |
		| 3     | lose     | lose     | win      |
		| 4     | win      | lose     | lose     |
	Then the following results are expected
		| Rank | Player |
		| 1    | 1      |
		| 2    | 3      |
		| 3    | 2      |

Scenario: Three players, first to three with a draw
	Given a game with 3 players and first to 3
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | win      | lose     | lose     |
		| 2     | draw     | draw     | draw     |
		| 3     | lose     | lose     | win      |
		| 4     | win      | lose     | lose     |
		| 5     | win      | lose     | lose     |
	Then the following results are expected
		| Rank | Player |
		| 1    | 1      |
		| 2    | 3      |
		| 3    | 2      |

Scenario: Three players, first to three with a joint second place
	Given a game with 3 players and first to 3
	When the following rounds are played
		| Round | Player 1 | Player 2 | Player 3 |
		| 1     | win      | lose     | lose     |
		| 2     | lose     | win      | lose     |
		| 3     | lose     | lose     | win      |
		| 4     | win      | lose     | lose     |
		| 5     | win      | lose     | lose     |
	Then the following results are expected
		| Rank | Player |
		| 1    | 1      |
		| 2    | 2      |
		| 2    | 3      |