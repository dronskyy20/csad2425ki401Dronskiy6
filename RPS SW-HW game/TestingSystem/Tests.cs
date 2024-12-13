using System;
using Xunit;

namespace TestingSystem
{
    public class Game
{
    private readonly Random _random = new Random();
    private readonly string[] _moves = { "rock", "paper", "scissors" };

    public string Play(string playerMove)
    {
       
        if (!Array.Exists(_moves, move => move.Equals(playerMove, StringComparison.OrdinalIgnoreCase)))
        {
            return "Invalid move";
        }

        
        string serverMove = _moves[_random.Next(_moves.Length)];

        return DetermineWinner(playerMove.ToLower(), serverMove);
    }

    private string DetermineWinner(string playerMove, string serverMove)
    {
        if (playerMove == serverMove)
            return "Draw";

        if ((playerMove == "rock" && serverMove == "scissors") ||
            (playerMove == "scissors" && serverMove == "paper") ||
            (playerMove == "paper" && serverMove == "rock"))
        {
            return "Player Wins";
        }
        else
        {
            return "Server Wins";
        }
    }
}




    public class Tests
    {
        private Game _game;

        public Tests()
        {
            _game = new Game();
        }

        [Fact]
        public void PlayerWinsWithRockAgainstScissors()
        {
            
            string result = _game.Play("rock");
            Assert.True(result == "Player Wins" || result == "Draw");
        }

        [Fact]
        public void PlayerWinsWithPaperAgainstRock()
        {
            string result = _game.Play("paper");
            Assert.True(result == "Player Wins" || result == "Draw");
        }

        [Fact]
        public void PlayerWinsWithScissorsAgainstPaper()
        {
            string result = _game.Play("scissors");
            Assert.True(result == "Player Wins" || result == "Draw");
        }

        [Fact]
        public void ServerWinsWithRockAgainstScissors()
        {
            string result = _game.Play("scissors");
            Assert.True(result == "Server Wins" || result == "Draw");
        }

        [Fact]
        public void ServerWinsWithPaperAgainstRock()
        {
            string result = _game.Play("rock");
            Assert.False(result == "Server Wins" || result == "Draw");
        }

        [Fact]
        public void ServerWinsWithScissorsAgainstPaper()
        {
            string result = _game.Play("paper");
            Assert.True(result == "Server Wins" || result == "Draw");
        }

        [Fact]
        public void DrawWithSameMoveRock()
        {
            
            string result = _game.Play("rock");
            Assert.False(result == "Draw");
        }

        [Fact]
        public void DrawWithSameMovePaper()
        {
            string result = _game.Play("paper");
            Assert.False(result == "Draw");
        }

        [Fact]
        public void DrawWithSameMoveScissors()
        {
            string result = _game.Play("scissors");
            Assert.False(result == "Draw");
        }

        [Fact]
        public void InvalidMoveReturnsErrorMessage()
        {
            string result = _game.Play("invalid");
            Assert.Equal("Invalid move", result);
        }
    }
}
