using System;
using System.Collections.Generic;

namespace Tennis.Logic
{
    public class Scorer
    {
        private readonly Dictionary<int, string> _pointsToScoreDictionary;
        public Boolean GameIsComplete;

        public Scorer()
        {
            GameIsComplete = false;

            _pointsToScoreDictionary = new Dictionary<int, string>()
            {
                { 0, "love"},
                { 1, "fifteen"},
                { 2, "thirty"},
                { 3, "forty"}
            };
        }
 
        public string GetScore(int player1Points, int player2Points)
        {
            string score;

            if (player1Points >= 4 && player1Points == player2Points + 2)
            {
                score = "winner player 1";
                GameIsComplete = true;
            }
            else if (player2Points >= 4 && player2Points == player1Points + 2)
            {
                score = "winner player 2";
                GameIsComplete = true;
            }
            else if (player1Points >= 3 && player1Points == player2Points)
            {
                score = "deuce";
            }
            else if (player1Points >=3 && player1Points == player2Points + 1)
            {
                score = "advantage player 1";
            }
            else if (player1Points >= 3 && player2Points == player1Points + 1)
            {
                score = "advantage player 2";
            }
            else
            {
                score = GetPlayerScore(player1Points) + " - " + GetPlayerScore(player2Points);
            }

            return score;
        }

        public string GetPlayerScore(int playerPoints)
        {
            return _pointsToScoreDictionary[playerPoints];
        }
    }
}