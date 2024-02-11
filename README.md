# MineSweeper
## Game play

### Sucess example
```
Welcome to Minesweeper!

Enter the size of the grid (e.g. 4 for a 4x4 grid): 
4
Enter the number of mines to place on the grid (maximum is 35% of the total squares): 
3

Here is your minefield:
  1 2 3 4
A _ _ _ _
B _ _ _ _
C _ _ _ _
D _ _ _ _

Select a square to reveal (e.g. A1): D4
This square contains 0 adjacent mines. 

Here is your updated minefield:
  1 2 3 4
A _ _ 2 0
B _ _ 2 0
C _ 2 1 0
D _ 1 0 0

Select a square to reveal (e.g. A1): B1
This square contains 3 adjacent mines. 

Here is your updated minefield:
  1 2 3 4
A _ _ 2 0
B 3 _ 2 0
C _ 2 1 0
D _ 1 0 0

Select a square to reveal (e.g. A1): A1
This square contains 2 adjacent mines. 

Here is your updated minefield:
  1 2 3 4
A 2 _ 2 0
B 3 _ 2 0
C _ 2 1 0
D _ 1 0 0

Select a square to reveal (e.g. A1): D1
This square contains 1 adjacent mines. 

Here is your updated minefield:
  1 2 3 4
A 2 _ 2 0
B 3 _ 2 0
C _ 2 1 0
D 1 1 0 0

Congratulations, you have won the game!
Press any key to play again...
```
Failure example
```
Welcome to Minesweeper!

Enter the size of the grid (e.g. 4 for a 4x4 grid): 
3
Enter the number of mines to place on the grid (maximum is 35% of the total squares): 
3

Here is your minefield:
  1 2 3
A _ _ _
B _ _ _
C _ _ _

Select a square to reveal (e.g. A1): C3
Oh no, you detonated a mine! Game over.
Press any key to play again...
```

Incorect input example
Failure example
```
Welcome to Minesweeper!

Enter the size of the grid (e.g. 4 for a 4x4 grid): 
2
Minimum size of grid is 2.
Enter the size of the grid (e.g. 4 for a 4x4 grid): 
11
Maximum size of grid is 10.
Enter the size of the grid (e.g. 4 for a 4x4 grid): 
A
Incorect input.
Enter the size of the grid (e.g. 4 for a 4x4 grid): 
3
Enter the number of mines to place on the grid (maximum is 35% of the total squares):
4
Maximum number is 35% of total sqaures.
Enter the number of mines to place on the grid (maximum is 35% of the total squares):
0
There must be at least 1 mine.
Enter the number of mines to place on the grid (maximum is 35% of the total squares):
A
Incorrect input.
Enter the number of mines to place on the grid (maximum is 35% of the total squares):
3
Here is your minefield:
  1 2 3
A _ _ _
B _ _ _
C _ _ _

Select a square to reveal (e.g. A1): A
Incorrect input.
Select a square to reveal (e.g. A1):
```
