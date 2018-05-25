{-# LANGUAGE FlexibleInstances #-}

module PolymorphicLiterals where

import           Control.Monad (replicateM_)

instance Num (String -> IO()) where
    fromInteger i s = replicateM_ (fromInteger i) $ putStrLn s

main :: IO ()
main = 42 "Hello"
