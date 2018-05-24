module Robot.Interpreters.Console
    ( run
    ) where

import           Control.Concurrent (threadDelay)

import           MyFreeMonad
import           Robot.DSL          (Angle, Color, RobotM, RobotOperation (..))

run :: RobotM() -> IO()

run (Free (Turn angle next)) = do
    putStrLn $ "Rotating on "++show angle++" degrees.."
    run next

run (Free (Move dst next)) = do
    putStrLn $ "Moving on "++show dst++" points forward.."
    run next

run (Free (Idle timeout next)) = do
    putStrLn $ "Idling for "++show timeout++" seconds.."
    threadDelay $ timeout * 1000 * 1000
    run next

run (Free (ReportStatus msg next)) = do
    putStrLn "Robot is sending msg to you:"
    putStrLn "\n"
    putStrLn msg
    putStrLn "\n"
    run next

run (Free (PenDown next)) = do
    putStrLn "Robot has started writing on the canvas."
    run next

run (Free (PenUp next)) = do
    putStrLn "Robot has finished writing on the canvas."
    run next

run (Free (SetColor clr next)) = do
    putStrLn $ "Robot's pen color has been set to "++show clr++" ."
    run next

run (Pure ())                = return ()
