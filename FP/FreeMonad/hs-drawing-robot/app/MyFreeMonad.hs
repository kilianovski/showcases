
module MyFreeMonad where

import           Control.Monad (ap, liftM)

data Free f r = Free (f (Free f r)) | Pure r

instance (Functor f) => Functor (Free f) where
    fmap = liftM

instance (Functor f) => Applicative (Free f) where
    pure = return
    (<*>) = ap

instance (Functor f) => Monad (Free f) where
    return = Pure
    (Free x) >>= kl = Free (fmap (>>= kl) x)
    (Pure r) >>= kl = kl r
