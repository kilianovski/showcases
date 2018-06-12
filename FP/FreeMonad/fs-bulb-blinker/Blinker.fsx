type BulbId = int

type TimeSlice = int

type BulbSwitcherInstruction<'a> = 
| TurnOn of BulbId * 'a
| TurnOff of  BulbId * 'a
| Delay of TimeSlice * 'a

type BulbSwitcherProgram<'a> =
| Free of BulbSwitcherInstruction<BulbSwitcherProgram<'a>>
| Pure of 'a

let private mapI f = function
    | TurnOn (id, next) -> TurnOn (id, f next)
    | TurnOff (id, next) -> TurnOff (id, f next)
    | Delay (time, next) -> Delay (time, f next)

let rec bind f = function
    | Free instruction -> instruction |> mapI (bind f) |> Free
    | Pure x -> f x

let map f = bind (f >> Pure)

type BulbSwitcherBuilder () = 
    member __.Bind (m, k) = bind k m
    member __.Return x = Pure x
    // member __.ReturnFrom x = x
    // member __.Zero () = Pure ()


let bulb = BulbSwitcherBuilder ()

let turnOn id = Free (TurnOn (id, Pure ()))
let turnOff id = Free (TurnOff (id, Pure ()))
let sleep time = Free (Delay (time, Pure ()))


let sampleProgram = bulb {
        do! turnOn 2
        do! turnOn 1
        do! sleep 2
        do! turnOff 1
        do! turnOff 2
    }

let rec interpret = function
    | Pure x -> x
    | Free (TurnOn (id, next)) -> 
        printfn "The bulb with id %i is turned on" id
        interpret next
    | Free (TurnOff (id, next)) -> 
        printfn "The bulb with id %i is turned off" id
        interpret next
    | Free (Delay (time, next)) -> 
        System.Threading.Thread.Sleep(time * 1000)
        interpret next

interpret sampleProgram