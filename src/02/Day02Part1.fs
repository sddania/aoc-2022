namespace Aoc2022

open System

module Day02Part1 =
    type Game =
        | Rock = 1
        | Paper = 2
        | Scissor = 3
    type Result =
        | Lose = 0
        | Draw = 3
        | Win = 6
    let rockCase game =
        match game with
        | Game.Rock -> Result.Draw
        | Game.Paper -> Result.Lose
        | Game.Scissor -> Result.Win
        | _ -> ArgumentOutOfRangeException() |> raise
    let paperCase game =
        match game with
        | Game.Rock -> Result.Win
        | Game.Paper -> Result.Draw
        | Game.Scissor -> Result.Lose
        | _ -> ArgumentOutOfRangeException() |> raise
    let scissorCase game =
        match game with
        | Game.Rock -> Result.Lose
        | Game.Paper -> Result.Win
        | Game.Scissor -> Result.Draw
        | _ -> ArgumentOutOfRangeException() |> raise
    let rockPaperScissor game1 game2 =
        match game1 with
        | Game.Rock -> rockCase game2
        | Game.Paper -> paperCase game2
        | Game.Scissor -> scissorCase game2
        | _ -> ArgumentOutOfRangeException() |> raise
        
