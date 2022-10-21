# Assignment 2 - UoW CCC 2020 Solutions
These are my attempts at the questions featured in the CCC 2020 Junior competition.

Test data for these questions can be found [here](https://www.cemc.uwaterloo.ca/contests/computing/past_ccc_contests/2020/index.html).

## J1 - Dog Treats
Barley the dog loves treats. At the end of the day he is either happy or sad depending on the number and size of treats he receives throughout the day. The treats come in three sizes: small, medium, and large. His happiness score can be measured using the following formula: 

    1 × S + 2 × M + 3 × L
### Format
```bash
.../api/CCC/DogTreats/{small}/{medium}/{large}
```

### Params
Assume each param is non-negative, and less than 10.
- small = Integer. # of small treats
- medium = Integer. # of medium treats
- large = Integer. # of large treats

### Returns
Boolean value representing if he is happy (true), or not (false)

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../Dogtreats/3/1/0` | false |
| GET | `../Dogtreats/3/2/1`| true |

---

## J2 - Epidemiology
People who study epidemiology use models to analyze the spread of disease. In this problem, we
use a simple model. When a person has a disease, they infect exactly R other people but only on the very next day. No person is infected more than once. We want to determine when a total of more than P people have
had the disease.
### Format
```bash
.../api/CCC/Epidemiology/{P}/{N}/{R}
```
### Params
- P = Integer. # maximum number of people infected. Assume P <= 10<sup>7</sup>
- N = Integer. # of people infected on Day 0. Assume N <= P
- R = Integer. # of people infected by a single person the next day. Assume R <= 10.

### Returns
Integer. Days until Total Infected is exceeded.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../Epidemiology/750/1/5`| 4 |
| GET | `../Epidemiology/10/2/1` | 5 |

___

## J3 - Modern Art
Mahima has been experimenting with a new style of art. She stands in front of a canvas and, using
her brush, flicks drops of paint onto the canvas. When she thinks she has created a masterpiece,
she uses her 3D printer to print a frame to surround the canvas.
Your job is to help Mahima by determining the coordinates of the smallest possible rectangular
frame such that each drop of paint lies inside the frame. Points on the frame are not considered
inside the frame. 

### Format
```bash
.../api/CCC/ModernArt/{N}/{* drop locations}
```

### Params
- drops = Integer. # maximum number of total drops. Assume 2 <= N <= 100
- \* drop locations = String. Location of individual drops. formatted as `X,Y`. seperated by a `/`. Assume
0 <= X < 100 and 0 <= Y < 100.

### Returns
String. lower left and upper right boundary locations. Formatted as `lowerX,lowerY | upperX,upperY`.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../ModernArt/5/44,62/34,69/24,78/42,44/64,10`| 23,9 \| 65,79 |
___

## J4 - Cyclic Shift

Thuc likes finding cyclic shifts of strings. A cyclic shift of a string is obtained by moving characters
from the beginning of the string to the end of the string. We also consider a string to be a cyclic
shift of itself. For example, the cyclic shifts of `ABCDE` are: `ABCDE, BCDEA, CDEAB, DEABC, and EABCD`.
### Format
```bash
.../api/CCC/CyclicShift/{Sequence}/{Cyclic Shift}
```

### Params
Assume each param will contain at most 1000 characters.
- Sequence = String. Full String Sequence of characters. 
- Cyclic Shift = String. Query sequence of characters.

### Returns
Boolean. Represents if the sequence contains a cyclic shift of the query sequence.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../CyclicShift/ABCCDEABAA/ABCDE` | true |
| GET | `../CyclicShift/ABCDDEBCAB/ABA` | false |

---

## J5 - Escape Room

You have to determine if it is possible to escape from a room. The room is an M -by-N grid with
each position (cell) containing a positive integer. The rows are numbered 1, 2, . . . , M and the
columns are numbered 1, 2, . . . , N . We use (r, c) to refer to the cell in row r and column c.

You start in the top-left corner at (1, 1) and exit from the bottom-right corner at (M, N ). If you
are in a cell containing the value x, then you can jump to any cell (a, b) satisfying a × b = x. For
example, if you are in a cell containing a 6, you can jump to cell (2, 3).

Note that from a cell containing a 6, there are up to four cells you can jump to: (2, 3), (3, 2), (1, 6),
or (6, 1). If the room is a 5-by-6 grid, there isn’t a row 6 so only the first three jumps would be
possible.

### Format
```bash
.../api/CCC/EscapeRoom/{m}/{n}/{* row data}
```

### Params
- m = Integer. # of rows. Assume 1 <= m <= 1000.
- n = Integer. # of columns. Assume 1 <= n <= 1000.
- \* row data = String. contents of all the rows. formated as `n(1) n(2) n(3) ... n(N)`. Sperated by a `/`. Assume positive integers.

### Returns
Boolean. Represents if it is possible to escape the room.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../EscapeRoom/3/4/3 10 8 14/1 11 12 12/6 2 3 9` | true |
| GET | `../EscapeRoom/3/4/3 10 2 14/1 11 1 1/5 2 3 9` | false |
