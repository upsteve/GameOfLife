Feature: Game of Life Rules
![GameOfLifeRules](./Game_of_life_glider_gun.svg)

Determine whather a cell is alive or dead after each iteration,
based on the cell's current state and the count of its living neighbours.

***Further read***: **[Learn more about Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)**


@rules
Scenario: The rules of game of life
	Given a <status> cell with <neighours> neighbours
	When the next generation is calculated
	Then the cell is <now>

	Examples:
	| status | neighours | now  | notes                    |
	| live   | 0         | dead | lower limit              |
	| live   | 1         | dead | below threshold for life |
	| live   | 2         | live | stable population        |
	| live   | 3         | live | stable population        |
	| live   | 4         | dead | above threshold for life |
	| live   | 8         | dead | upper limit              |
	| dead   | 0         | dead | lower limit              |
	| dead   | 2         | dead | below threshold for life |
	| dead   | 3         | live | perfect for new life     |
	| dead   | 4         | dead | above threshold for life |
	| dead   | 8         | dead | upper limit              |
