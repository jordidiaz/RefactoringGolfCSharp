using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string Player1 = "player1";
        private const string LoveAll = "Love-All";
        private const string FifteenAll = "Fifteen-All";
        private const string ThirtyAll = "Thirty-All";
        private const string Deuce = "Deuce";

        private int _player1Score;
        private int _player2Score;

        public void WonPoint(string playerName)
        {
            if (playerName == Player1)
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (_player1Score == _player2Score)
            {
                score = _player1Score switch
                {
                    0 => LoveAll,
                    1 => FifteenAll,
                    2 => ThirtyAll,
                    _ => Deuce
                };
            }
            else if (_player1Score >= 4 || _player2Score >= 4)
            {
                var minusResult = _player1Score - _player2Score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = _player1Score;
                    else { score += "-"; tempScore = _player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

