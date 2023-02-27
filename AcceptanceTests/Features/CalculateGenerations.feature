Feature: Calculate Generations

Calculate subsequent generations of the grid using known examples.

Scenario: A south east facing glider moves as expected
	Given an initial grid of 
	| plainText |
	| ..... |
	| ..O.. |
	| ...O. |
	| .OOO. |
	| ..... |
	When the next 4 generations are calculated
	Then the grid is
	| plainText |
	| ..... |
	| ..... |
	| ...O. |
	| ....O |
	| ..OOO |

Scenario: A block of 4 cells is stable
	Given an initial grid of 
	| plainText |
	| ... |
	| OO. |
	| OO. |
	| ... |
	When the next 1 generations are calculated
	Then the grid is
	| plainText |
	| ... |
	| OO. |
	| OO. |
	| ... |

Scenario: A Gosper glider gun has a period of 30 generations
	Given the examples\gosper.rle file
	When the next 30 generations are calculated
	Then the grid is
	| plainText                            |
	| ........................O........... |
	| ......................O.O........... |
	| ............OO......OO............OO |
	| ...........O...O....OO............OO |
	| OO........O.....O...OO.............. |
	| OO........O...O.OO....O.O........... |
	| ..........O.....O.......O........... |
	| ...........O...O.................... |
	| ............OO...................... |
	| .......................O............ |
	| ........................OO.......... |
	| .......................OO........... |
