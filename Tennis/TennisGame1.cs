namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string Player1 = "player1";
        private const string LoveAll = "Love-All";
        private const string FifteenAll = "Fifteen-All";
        private const string ThirtyAll = "Thirty-All";
        private const string Deuce = "Deuce";
        private const string AdvantagePlayer1 = "Advantage player1";
        private const string AdvantagePlayer2 = "Advantage player2";
        private const string WinForPlayer1 = "Win for player1";
        private const string WinForPlayer2 = "Win for player2";
        private const string Love = "Love";
        private const string Fifteen = "Fifteen";
        private const string Thirty = "Thirty";
        private const string Forty = "Forty";

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
                score = minusResult switch
                {
                    1 => AdvantagePlayer1,
                    -1 => AdvantagePlayer2,
                    >= 2 => WinForPlayer1,
                    _ => WinForPlayer2
                };
            }
            else
            {
                score = GetScoreAsString(_player1Score, score);
                score += "-";
                score = GetScoreAsString(_player2Score, score);
            }
            return score;
        }

        private static string GetScoreAsString(int tempScore, string score)
        {
            switch (tempScore)
            {
                case 0:
                    score += Love;
                    break;
                case 1:
                    score += Fifteen;
                    break;
                case 2:
                    score += Thirty;
                    break;
                case 3:
                    score += Forty;
                    break;
            }

            return score;
        }
    }
}

