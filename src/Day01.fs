namespace Aoc2022

open System
open System.IO

module Day01 =
    let isNotEmpty row = row |> String.IsNullOrWhiteSpace |> not
    let convertAndSum r = r |> Seq.map int32 |> Seq.sum
    let rec splitRowsWhen cond s =
        seq {
            yield s |> Seq.takeWhile cond
            let r = s |> Seq.skipWhile cond

            if (Seq.isEmpty r) = false then
                yield! splitRowsWhen cond (Seq.tail r)
        }

    let readFileSplitAndSum path =
        path
        |> File.ReadLines
        |> splitRowsWhen isNotEmpty
        |> Seq.map convertAndSum
    
    let part1 path =
        path
        |> readFileSplitAndSum
        |> Seq.max
        
    let part2 path =
        path
        |> readFileSplitAndSum
        |> Seq.sortByDescending id
        |> Seq.take 3
        |> Seq.sum
