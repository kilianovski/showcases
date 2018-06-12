# FreeMonad

 - `Free` monad allows you to make a monad from any functor.
 - `Free` monad allows you to write a program (set of instructions) in an imperative style while getting pure AST-like structure
    - Imperative style is achieved through sugar constructs like `do` notation in Haskell or computation expressions in F#
    - Return value of such program (AST) could be interpreted with different interpreters
    - As Mark Seeman says, _object-oriented interfaces and AST-based free monads are isomorphic._