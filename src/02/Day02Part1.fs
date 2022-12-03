namespace Aoc2022

open System
open System.IO
open System.Text.RegularExpressions
open FSharp.Collections.ParallelSeq
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core

module Day02Part1 =
    type Game =
        | Rock = 1
        | Paper = 2
        | Scissor = 3
    type Match = Game * Game
    type Result =
        | Lose = 0
        | Draw = 3
        | Win = 6
    let rockPaperScissor game1 game2 =
        match (game1,game2) with
        | (Game.Rock, Game.Rock) -> Result.Draw
        | (Game.Rock, Game.Paper) -> Result.Win
        | (Game.Rock, Game.Scissor) -> Result.Lose
        | (Game.Paper, Game.Rock) -> Result.Lose
        | (Game.Paper, Game.Paper) -> Result.Draw
        | (Game.Paper, Game.Scissor) -> Result.Win
        | (Game.Scissor, Game.Rock) -> Result.Win
        | (Game.Scissor, Game.Paper) -> Result.Lose
        | (Game.Scissor, Game.Scissor) -> Result.Draw
        | _ -> ArgumentOutOfRangeException() |> raise
    let parseGame game =
        match game with
        | 'A' | 'X' -> Game.Rock 
        | 'B' | 'Y' -> Game.Paper 
        | 'C' | 'Z' -> Game.Scissor
        | _ -> ArgumentOutOfRangeException() |> raise
    let parseLine line =
        let chars = line |> Array.ofSeq
        match chars with
        | [|game1;_;game2|] -> (parseGame game1, parseGame game2)
        | _ -> ArgumentOutOfRangeException() |> raise
        
    let calculatePoints (game: Match) =
        let (game1, game2) = game
        let resultGame = rockPaperScissor game1 game2
        let resultPoints = int resultGame
        let game2Point = int game2
        resultPoints + game2Point
        
    let calculateAllMatches (allGames:int) (game:Match) =
        let resultGame = calculatePoints game
        allGames + resultGame
        
    let result path =
        path
        |> File.ReadAllLines
        |> Seq.map parseLine
        |> Seq.fold calculateAllMatches 0
