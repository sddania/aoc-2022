namespace Aoc2022

module Day01Part2 =
    let result path =
        path
        |> Day01Part1.readFileSplitAndSum
        |> Seq.sortByDescending id
        |> Seq.take 3
        |> Seq.sum

