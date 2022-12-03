namespace Aoc2022

open System
open System.IO
open FSharp.Collections.ParallelSeq
open Microsoft.FSharp.Collections
open Microsoft.FSharp.Core

module Day02 =
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
        
    let rockPaperScissorPart2 game1 game2 =
        match (game2,game1) with
        | (Game.Rock, Game.Rock) -> Result.Lose
        | (Game.Rock, Game.Paper) -> Result.Lose
        | (Game.Rock, Game.Scissor) -> Result.Lose
        | (Game.Paper, Game.Rock) -> Result.Draw
        | (Game.Paper, Game.Paper) -> Result.Draw
        | (Game.Paper, Game.Scissor) -> Result.Draw
        | (Game.Scissor, Game.Rock) -> Result.Win
        | (Game.Scissor, Game.Paper) -> Result.Win
        | (Game.Scissor, Game.Scissor) -> Result.Win
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
        let gamePoint = int game2
        resultPoints + gamePoint        
    let gamePointFromResult (game,result) =
        match (result, game) with
        | (Result.Win, Game.Rock) -> Game.Paper
        | (Result.Win, Game.Paper) -> Game.Scissor
        | (Result.Win, Game.Scissor) -> Game.Rock
        | (Result.Draw, Game.Rock) -> Game.Rock
        | (Result.Draw, Game.Paper) -> Game.Paper
        | (Result.Draw, Game.Scissor) -> Game.Scissor
        | (Result.Lose, Game.Rock) -> Game.Scissor
        | (Result.Lose, Game.Paper) -> Game.Rock
        | (Result.Lose, Game.Scissor) -> Game.Paper
        | _ -> ArgumentOutOfRangeException() |> raise
    
    let calculatePoints2 (game: Match) =
        let (game1, game2) = game
        let resultGame = rockPaperScissorPart2 game1 game2
        let gamePoint = int (gamePointFromResult (game1,resultGame))
        let resultPoints = int resultGame
        resultPoints + gamePoint
        
    let calculateAllMatches calculatePoints (allGames:int) (game:Match) =
        let resultGame = calculatePoints game
        allGames + resultGame
        
    let result path =
        path
        |> File.ReadAllLines
        |> PSeq.map parseLine
        |> PSeq.fold (calculateAllMatches calculatePoints) 0
        
    let result2 path =
        path
        |> File.ReadAllLines
        |> PSeq.map parseLine
        |> PSeq.fold (calculateAllMatches calculatePoints2) 0
