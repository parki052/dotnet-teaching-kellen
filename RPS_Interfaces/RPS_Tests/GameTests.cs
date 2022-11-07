using RPS_Interfaces;
using RPS_Interfaces.Models;
using System;
using Xunit;

namespace RPS_Tests
{
    public class GameTests
    {
        [Theory]
        [InlineData(Choice.Paper, Choice.Paper, GameResult.Tie)]
        [InlineData(Choice.Paper, Choice.Rock, GameResult.Player1Win)]
        [InlineData(Choice.Paper, Choice.Scissors, GameResult.Player2Win)]
        [InlineData(Choice.Rock, Choice.Paper, GameResult.Player2Win)]
        [InlineData(Choice.Rock, Choice.Rock, GameResult.Tie)]
        [InlineData(Choice.Rock, Choice.Scissors, GameResult.Player1Win)]
        [InlineData(Choice.Scissors, Choice.Paper, GameResult.Player1Win)]
        [InlineData(Choice.Scissors, Choice.Rock, GameResult.Player2Win)]
        [InlineData(Choice.Scissors, Choice.Scissors, GameResult.Tie)]
        public void Game_GetGameResult_CanGetCorrectResult(Choice p1choice, Choice p2choice, GameResult expectedResult)
        {
            Game game = new Game();
            GameResult actualResult = game.GetGameResult(p1choice, p2choice);

            Assert.Equal(expectedResult, actualResult);
        }

        public void Game_GetResultMessage_CanGetCorrectMessage()
        {
            throw new NotImplementedException();
        }
    }
}
