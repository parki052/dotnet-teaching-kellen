using RPS_Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPS_Interfaces
{
    public class Game
    {
        public void Play(IChoiceGetter player1, IChoiceGetter player2)
        {
            Choice p1choice = player1.GetChoice();
            Choice p2choice = player2.GetChoice();

            GameResult result = GetGameResult(p1choice, p2choice);
            string resultMessage = GetResultMessage(result, p1choice, p2choice);
            
            Console.WriteLine(resultMessage);
        }

        public GameResult GetGameResult(Choice p1Choice, Choice p2choice)
        {
            GameResult result;
            
            if(p1Choice == p2choice)
            {
                result = GameResult.Tie;
            }
            else if(
                    (p1Choice == Choice.Rock && p2choice == Choice.Scissors) ||
                    (p1Choice == Choice.Paper && p2choice == Choice.Rock) ||
                    (p1Choice == Choice.Scissors && p2choice == Choice.Paper)
                )
            {
                result = GameResult.Player1Win;
            }
            else
            {
                result = GameResult.Player2Win;
            }

            return result;
        }

        public string GetResultMessage(GameResult result, Choice p1choice, Choice p2choice)
        {
            string message = $"(P1: {p1choice} P2: {p2choice})\n";

            switch (result)
            {
                case GameResult.Player1Win:
                    message += $"{p1choice} beats {p2choice}. Player 1 Wins!";
                    break;

                case GameResult.Player2Win:
                    message += $"{p2choice} beats {p1choice}. Player 2 Wins!";
                    break;

                case GameResult.Tie:
                    message += $"Tie!";
                    break;

                default:
                    throw new Exception("Error in AnnounceResult: didn't hit a known GameResult case.");            
            }

            return message;
        }
    }
}
