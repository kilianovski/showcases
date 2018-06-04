module Robot.DSL where

import           MyFreeMonad

type Angle = Float
type Color = String

data RobotOperation next =
      Turn Angle next
    | Move Int next
    | Idle Int next
    | ReportStatus String next
    | PenDown next
    | PenUp next
    | SetColor Color next

instance Functor RobotOperation where
    fmap f (Turn angle next)       = Turn angle $ f next
    fmap f (Move dist next)        = Move dist $ f next
    fmap f (Idle time next)        = Idle time $ f next
    fmap f (ReportStatus msg next) = ReportStatus msg $ f next
    fmap f (PenDown next)          = PenDown $ f next
    fmap f (PenUp next)            = PenUp $ f next
    fmap f (SetColor color next)   = SetColor color $ f next


-- Operation functions

type RobotM = Free RobotOperation

turn :: Angle -> RobotM ()
turn side = Free (Turn side (Pure ()))

turnLeft :: RobotM ()
turnLeft = turn (-90)

turnRight :: RobotM ()
turnRight = turn (90)

move :: Int -> RobotM ()
move dist = Free (Move dist (Pure ()))

step :: RobotM ()
step = move 1

idle :: Int -> RobotM ()
idle dur = Free (Idle dur (Pure ()))

reportStatus :: String -> RobotM ()
reportStatus msg = Free (ReportStatus msg (Pure ()))

penDown :: RobotM ()
penDown = Free (PenDown (Pure()))

penUp :: RobotM ()
penUp = Free (PenUp (Pure()))

setColor :: Color -> RobotM ()
setColor clr = Free (SetColor clr (Pure()))
