open System


exception Error1 of string
exception Error2 of string * string[] * int

let rec first_Test() =
    printfn "%*s" 50 "Enter Number"

    let n1 = Console.ReadLine()

    let result = n1.Split([| ",";";";"\\n";"//";"[]";"[%]";"*";"%" |], StringSplitOptions.None)

    let mutable newRes = 0

    //find the sum for the two string numbers
    let get_sum (x:int, y:int) : int = x+y

    let mutable emList = []

    let mutable j = 0

    let mutable moreThanOneNegative = 0

    let cons = 0


    for c in result do
        if Int32.TryParse(c, &newRes) then
            j <- int c

            // to handle negative value
            try
                //printfn "%i" moreThanOneNegative
                if j < 0 && moreThanOneNegative < 1 then 
                    moreThanOneNegative <- cons + 1
                    //raise (Error1("negatives not allowed")) 
                   // raise (Error2("negatives not allowed",result,moreThanOneNegative)) 
                elif j < 0 && moreThanOneNegative >= 1 then
                    raise (Error2("negatives not allowed",result,moreThanOneNegative)) 
                elif j > 0 && moreThanOneNegative >= 1 then
                    moreThanOneNegative <- cons + 1
                    raise (Error1("negatives not allowed")) 
                else 
                //to hanlde the numbers that bigger than 1000
                 if int j > 1000 then
                     j <- 0
                 emList <- [j] |> List.append emList
            with
                | Error1(str) -> printfn "Exception %s" str 
                | Error2(str, res,i) -> printfn "Exception %s %A" str res
                
    
    // to handle unknown amount of numbers
    if emList.Length > 3 then
        printfn"%s" "Method handle just 3 numbers" 
        first_Test()
    else

    

    let mutable sumValue = List.sumBy (fun elem -> elem) emList

    printfn "%A" sumValue
    first_Test()






first_Test()

Console.ReadKey() |> ignore