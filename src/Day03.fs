namespace Aoc2022

open System.IO

module Day03 =

    let presentIn2Parts char (part1, part2) =
        (part1 |> Seq.contains char)
        && (part2 |> Seq.contains char)

    let getKey (row: string) =
        let allChars = row |> Seq.distinct
        let halfLenght = row.Length / 2
        let part1 = row |> Seq.truncate halfLenght
        let part2 = row |> Seq.skip halfLenght

        allChars
        |> Seq.find (fun a -> presentIn2Parts a (part1, part2))

    let inline charToInt c =
        let firstStep = int c

        if firstStep - 96 > 0 then
            firstStep - 96
        else
            firstStep - 38

    let rec groupBy3Lines (lines: seq<string>) =
        seq {
            yield lines |> Seq.truncate 3
            let next3 = lines |> Seq.skip 3

            if ((next3 |> Seq.length) >= 3) then
                yield! groupBy3Lines next3
        }

    let getKeyFor3Lines (rows: seq<string>) =
        let allChars =
            rows |> Seq.concat |> Seq.distinct

        allChars
        |> Seq.find (fun c -> (rows |> Seq.forall (fun row -> row.Contains c)))

    let result path =
        path
        |> File.ReadAllLines
        |> Seq.map getKey
        |> Seq.fold (fun old s -> old + charToInt s) 0

    let result2 path =
        path
        |> File.ReadAllLines
        |> groupBy3Lines
        |> Seq.map getKeyFor3Lines
        |> Seq.fold (fun old s -> old + charToInt s) 0
