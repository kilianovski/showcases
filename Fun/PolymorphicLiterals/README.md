# Polymorphism on the value level

### Built-in type of the literal?

The type of the numeric literal in languages like Java is built-in into the compiler. Maybe, you use the value `42` in the context where `byte` type is expected, and where `int` is expected and everything goes fine. But, anyway, all possible types of the literal `42` is hardcoded into the compiler.

### But not in Haskell!

In Haskell, if you pass `42` to a function that requires `Float` , you don't have to add silly dots or whatever ( like `42.` or `42.0`) to indicate that you want float.

That's it! Each type, that has `Num` instance is the candidate to be the type of the literal. `Float` has it, and a lot of other types too.

### We can do a crazy stuff with it!

If you provide the `Num` instance for the custom type, this custom type could be implicitly inferred from the numerical literal like `42` . That means, that `42` could mean whatever you want in the right context. For example, `42` could act like a function that prints given string `42` times. 

Firstly, the `Num` instance:

``` haskell
instance Num (String -> IO()) where
    fromInteger i s = replicateM_ (fromInteger i) $ putStrLn s
```

And the usage:

``` haskell
main :: IO ()
main = 42 "Hello"
```



Concept first found in [embedded into Haskell the BASIC language](http://augustss.blogspot.com/2009/02/more-basic-not-that-anybody-should-care.html)