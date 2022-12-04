namespace Aoc2022

open System
open System.IO

module Day04 =
    
    let splitStringWithChar (char: char) (line: string) =
        match (line.Split char |> Array.ofSeq) with
        | [| section1; section2 |] -> (section1, section2)
        | _ -> ArgumentOutOfRangeException() |> raise

    let getSeqFromFirst (section1: string) =
        let limit1, limit2 =
            splitStringWithChar '-' section1

        if (limit1 <> limit2) then
            seq { (int limit1) .. (int limit2) }
        else
            seq { (int limit1) }

    let getLimitsToSecond (section2: string) =
        let (limit1), (limit2) =
            splitStringWithChar '-' section2

        ((int limit1), (int limit2))

    let getSeqFromFirstPartAndLimitsToSecond (section1: string, section2: string) =
        (getSeqFromFirst section1, getLimitsToSecond section2),
        (getSeqFromFirst section2, getLimitsToSecond section1)

    let limitIsIntoRange (range: seq<int>, (limit1: int, limit2: int)) =
        (range |> Seq.contains limit1
        && range |> Seq.contains limit2)
    let checkAllSectionIsIntoOtherSection funCheck (check1, check2) = 
        funCheck check1 || funCheck check2
        
    let limitIsPartiallyIntoRange (range: seq<int>, (limit1: int, limit2: int)) =
        (range |> Seq.contains limit1
        || range |> Seq.contains limit2)
        
    let result path =
        path
        |> File.ReadAllLines
        |> Seq.map (splitStringWithChar ',')
        |> Seq.map getSeqFromFirstPartAndLimitsToSecond
        |> Seq.filter (checkAllSectionIsIntoOtherSection limitIsIntoRange)
        |> Seq.length
        
    let result2 path =
        path
        |> File.ReadAllLines
        |> Seq.map (splitStringWithChar ',')
        |> Seq.map getSeqFromFirstPartAndLimitsToSecond
        |> Seq.filter (checkAllSectionIsIntoOtherSection limitIsPartiallyIntoRange) 
        |> Seq.length
