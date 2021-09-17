using System;

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
            if (IsGameTied())
            {
                return  DisplayTiedScore();
            }
            if (IsAdvantageScore())
            {
                return DisplayAdvantageScore();
            }
            if (IsWinScore())
            {
                return DisplayMaxScore();
            }
            
            return DisplayRegularScore();
        }

        private string DisplayRegularScore()
        {
            return $"{GetScoreAsString(_player1Score)}-{GetScoreAsString(_player2Score)}";
        }

        private string DisplayAdvantageScore()
        {
            var minusResult = _player1Score - _player2Score;

            return minusResult switch
            {
                1 => AdvantagePlayer1,
                _ => AdvantagePlayer2
            };
        }       
        
        private string DisplayMaxScore()
        {
            var minusResult = _player1Score - _player2Score;

            return minusResult switch
            {
                >= 2 => WinForPlayer1,
                _ => WinForPlayer2
            };
        }

        private string DisplayTiedScore()
        {
            return _player1Score switch
            {
                0 => LoveAll,
                1 => FifteenAll,
                2 => ThirtyAll,
                _ => Deuce
            };
        }

        private bool IsGameTied()
        {
            return _player1Score == _player2Score;
        }

        private bool IsAdvantageScore()
        {
            return (_player1Score >= 4 || _player2Score >= 4) && (Math.Abs(_player1Score - _player2Score) == 1);
        }
        
        private bool IsWinScore()
        {
            return (_player1Score >= 4 || _player2Score >= 4) && (Math.Abs(_player1Score - _player2Score) > 1);
        }

        private static string GetScoreAsString(int tempScore)
        {
            return tempScore switch
            {
                0 => Love,
                1 => Fifteen,
                2 => Thirty,
                _ => Forty
            };
        }
    }
}

