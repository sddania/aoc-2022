namespace Aoc2022

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
    
    let rockPaperScissor game1 game2 =
        match game1 with
        | Game.Rock -> rockCase game2
        
