namespace Aoc2022

open System
open System.IO

module Day01Part1 =
    let readLines filePath = File.ReadLines(filePath)
    let isNotEmpty row = String.IsNullOrWhiteSpace row = false
    let rec splitRowsWhen cond s =
      seq {
        yield s |> Seq.takeWhile cond
        let r = s |> Seq.skipWhile cond
        if (Seq.isEmpty r) = false then
          yield! splitRowsWhen cond (Seq.tail r)
      }
    let convertAndSum r = r |> Seq.map int32 |> Seq.sum

    let basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName
    let path = Path.Combine (basePath, "asset/Calories")

    let result = path
                 |> readLines 
                 |> splitRowsWhen isNotEmpty 
                 |> Seq.map convertAndSum
                 |> Seq.max