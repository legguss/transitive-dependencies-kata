# Transitive Dependencies Kata

## Part 1

*Note: Please complete the first page before reading part 2 on the following page.*

- If A depends on B and B depends on C, then A also depends on C. This is called a transitive dependency.
- Given an input (could either be a direct function call, file input or read from console) with lists of dependencies, write a program that outputs the full set of distinct dependencies, alphabetically ordered.
- The first token of each input line is the name of the item. The remaining tokens are the names of the things the first item depends on.

- As an example, given the input:

```
A B C
B C E
C G
D A F
E F
F H
```

- The program should output:

```
A B C E F G H
B C E F G H
C G
D A B C E F G H
E F H
F H
```

- The program can be written in any language you like, and should be written to a production-ready level of quality (we aren't looking for the quickest solution, nor the most over-engineered solution to show off every code pattern you may know).
- As you write the program, please write a few bullet point notes describing your approach and any changes in design you make along the way - we aren't expecting an essay, it's just interesting to see how people arrive at the solution without having to have the pressure of a live code challenge in an interview.
- Please stop here, and only continue to part 2 once you have working code for the example inputs above.
