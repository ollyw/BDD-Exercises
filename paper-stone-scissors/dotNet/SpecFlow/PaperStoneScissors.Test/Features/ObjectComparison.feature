Feature: Play a single round of Paper-Stone-Scissors
	In order to be able to score the game
	As a game player
	I must be able to compare objects to derive a winner

Scenario Outline: Compare two Paper, Stone and Scissors objects
	When player 1 choses <object 1>
	And player 2 choses <object 2>
	Then the result for player 1 is <result 1>
	And the result for player 2 is <result 2>

Scenarios:
	| object 1 | object 2 | result 1 | result 2 |
	| paper    | stone    | win      | lose     |
	| scissors | paper    | win      | lose     |
	| stone    | scissors | win      | lose     |
	| stone    | paper    | lose     | win      |
	| paper    | scissors | lose     | win      |
	| scissors | stone    | lose     | win      |
	| paper    | paper    | draw     | draw     |
	| scissors | scissors | draw     | draw     |
	| stone    | stone    | draw     | draw     |

Scenario Outline: Compare three Paper, Stone and Scissors objects
	When player 1 choses <object 1>
	And player 2 choses <object 2>
	And player 3 choses <object 3>
	Then the result for player 1 is <result 1>
	And the result for player 2 is <result 2>
	And the result for player 2 is <result 2>

Scenarios:
	| object 1 | object 2 | object 3 | result 1 | result 2 | result 3 |
	| paper    | stone    | stone    | win      | lose     | lose     |
	| stone    | paper    | scissors | draw     | draw     | draw     |
