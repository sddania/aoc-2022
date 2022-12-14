namespace Aoc2022

open System.IO

module Input =
    let readAllLinesAsync path =
        async {
            return! path |> File.ReadAllLinesAsync |> Async.AwaitTask
        }
    let path01 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/01/input")
    let testPath01 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/01/example")
        
    let path02 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/02/input")
    let testPath02 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/02/example")
        
    let path03 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/03/input")
    let testPath03 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/03/example")
    
    let path04 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/04/input")
    let testPath04 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/04/example")
        
    let path05 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/05/input")
    let testPath05 =
        Path.Combine(__SOURCE_DIRECTORY__, "../asset/05/example")
