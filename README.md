# Assignment 2 - UoW CCC 2020 Solutions
This is my attempts at the questions featured in the CCC 2020 Junior competition.

Test data for these questions can be found [here]().

## J1 - Dog Treats
Determine if Barley the Dog is happy with the treats get gets.

### Format
```bash
.../api/j1/DogTreats/{small}/{medium}/{large}
```

### Params
- small = Integer. # of small treats
- medium = Integer. # of medium treats
- large = Integer. # of large treats

### Returns
Boolean value representing if he is happy (true), or not (false)

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../Dogtreats/5/3/1` | true |
| GET | `../Dogtreats/1/2/1`| false |

---

## J2 - Epidemiology
Determines after how many days it takes until the disease infects more than P number of people.

### Format
```bash
.../api/j2/Epidemiology/{P}/{N}/{R}
```
### Params
- P = Integer. # maximum number of people infected
- N = Integer. # of people infected on Day 0
- R = Integer. Rate of infection (# of people infected by a single person the next dat)

### Returns
Integer. Days until Total Infected is exceeded.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../Epidemiology/750/1/5`| 4 |
| GET | `../Epidemiology/10/2/1` | 5 |

___

## J3 - Modern Art
Determines the coordinates of the smallest possible rectangular frame, such that each drop of paint lies inside the frame. 

### Format
```bash
.../api/j3/Art/{drops}/{* drop locations}
```

### Params
- drops = Integer. # maximum number of total drops
- \* drop locations = String. Location of individual drops. formatted as `xx,yy`. seperated by a `/`.

### Returns
String. lower left and upper right boundary locations. Formatted as `lowerX,lowerY | upperX,upperY`.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../Art/5/44,62/34,69/24,78/42,44/64,10`| 23,9 \| 65,79 |
___

## J4 - Cyclic Shift

Determines if a text contains a cyclic shift of a specified string

### Format
```bash
.../api/j4/Cyclic/{Sequence}/{Cyclic Shift}
```

### Params
- Sequence = String. Full String Sequence of characters.
- Cyclic Shift = String. Query sequence of characters.

### Returns
Boolean. Represents if the sequence contains a cyclic shift of the query sequence.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../cyclic/ABCCDEABAA/ABCDE` | true |
| GET | `../cyclic/ABCDDEBCAB/ABA` | false |

---

## J5 - Escape Room

Determine if it is possible to escape from a room. You start at top left (1,1), and need to move to bottom right (m,n). If you are in a cell of value x, then you can jump to any cell (a,b) such that a x b = x. 

### Format
```bash
.../api/j5/EscapeRoom/{m}/{n}/{* row data}
```

### Params
- m = Integer. # of rows.
- n = Integer. # of columns.
- \* row data = String. contents of all the rows. formated as `n(1) n(2) n(3) ... n(N)`. Sperated by a `/`.

### Returns
Boolean. Represents if it is possible to escape the room.

### Example
| Protocol | Input | Output |
| --- |---|---|
| GET | `../EscapeRoom/3/4/3 10 8 14/1 11 12 12/6 2 3 9` | true |
| GET | `../EscapeRoom/3/4/3 10 2 14/1 11 1 1/5 2 3 9` | false |
