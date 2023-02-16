Feature: Load From File

The starting grid for the game of life should be loadable from plain text and RLE files.

Scenario: Load an RLE file
	Given the glider.rle file
	Then the grid is
	| plainText |
	| .O. |
	| ..O |
	| OOO |

Scenario: Load a TXT file
	Given the glider.txt file
	Then the grid is
	| plainText |
	| ..... |
	| ..O.. |
	| ...O. |
	| .OOO. |
	| ..... |
