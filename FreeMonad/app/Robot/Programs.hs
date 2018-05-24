module Robot.Programs
    ( drawSquare
    ) where

import           Robot.DSL (Angle, Color, RobotM, idle, move, penDown, penUp,
                            reportStatus, setColor, step, turn, turnLeft,
                            turnRight)


moveForwardAndTurnRight :: Int -> RobotM ()
moveForwardAndTurnRight dst = do
    move dst
    turnRight
    idle 5

drawSquare :: RobotM ()
drawSquare = do
    reportStatus "Starting the square drawing.."
    setColor "black"
    penDown

    move 12
    turnRight
    idle 3

    move 12
    turnRight
    idle 3

    move 12
    turnRight
    idle 3

    penUp
    reportStatus "Finished the square drawing."
