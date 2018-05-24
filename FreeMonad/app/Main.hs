module Main where

import           Robot.Programs

import qualified Robot.Interpreters.Console as Console

main :: IO ()
main = do
    Console.run drawSquare
