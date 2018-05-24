module MyFreeMonad where

data Free f r = Free (f (Free f r)) | Pure r

instance (Functor f) => Functor (Free f)

instance (Functor f) => Applicative (Free f)

instance (Functor f) => Monad (Free f) where
    return = Pure
    (Free x) >>= kl = Free (fmap (>>= kl) x)
    (Pure r) >>= kl = kl r

data MyLang =
        Print String MyLang
    | Read String MyLang
    | Pause Int MyLang

