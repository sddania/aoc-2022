namespace Aoc2022

open System.IO

module Input =
    let readAllLinesAsync path =
        async {
            return! path |> File.ReadAllLinesAsync |> Async.AwaitTask
        }
    let path folderName =
        Path.Combine(__SOURCE_DIRECTORY__, $"../asset/{folderName}/input")
    let testPath folderName =
        Path.Combine(__SOURCE_DIRECTORY__, $"../asset/{folderName}/example")