namespace Aoc2022

open System
open System.Collections
open System.IO

module Day05 =
    let zip seq =
        seq
        |> Seq.collect(fun s -> s |> Seq.mapi(fun i e -> (i, e))) //wrap with index
        |> Seq.groupBy(fst) //group by index
        |> Seq.map(fun (i, s) -> s |> Seq.map snd) //unwrap
    let getStack (lines: seq<string>) =
        lines
            |> zip
            |> Seq.filter (fun s -> s |> Seq.head |> Char.IsWhiteSpace |> not )
            |> Seq.map (fun value -> (value |> Seq.tail |> Array.ofSeq |> Stack))
            |> Array.ofSeq
            
    let parseCommand (line:string) =
        let split = line.Split ' '
        int split[1], int split[3], int split[5]
        
    let getStacksAndCommands (lines: seq<string>[]) =
        let stacks = getStack (lines[0] |> Seq.rev |> Seq.tail |> Seq.rev)
        let commands =
            lines[1]
            |> Seq.tail
            |> Seq.map parseCommand
            
        stacks, commands
        
    let moveCrates (stacks: Stack[], commands: seq<int*int*int>) =
        for (numOfCrates, start, destination) in commands do
            for _ in 0 .. numOfCrates do
                let crate = stacks[start].Pop()
                stacks[destination].Push crate
        stacks
            
    let part1 path =
        path
        |> File.ReadAllLines
        |> Day01.splitRowsWhen (fun s -> s |> String.IsNullOrWhiteSpace |> not)
        |> Array.ofSeq
        |> getStacksAndCommands
        // |> moveCrates
        // |> Seq.map (fun s-> s.Pop() |> string)
        // |> String.concat ","
        