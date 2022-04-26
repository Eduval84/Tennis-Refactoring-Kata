namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;
        private string _score = "";

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            if (_player1Score == _player2Score)
            {
                switch (_player1Score)
                {
                    case 0:
                        _score = "Love-All";
                        break;
                    case 1:
                        _score = "Fifteen-All";
                        break;
                    case 2:
                        _score = "Thirty-All";
                        break;
                    default:
                        _score = "Deuce";
                        break;
                }
            }
            else if (_player1Score >= 4 || _player2Score >= 4)
            {
                var minusResult = _player1Score - _player2Score;
                if (minusResult == 1) _score = "Advantage player1";
                else if (minusResult == -1) _score = "Advantage player2";
                else if (minusResult >= 2) _score = "Win for player1";
                else _score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _player1Score;
                    else { _score += "-"; tempScore = _player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            _score += "Love";
                            break;
                        case 1:
                            _score += "Fifteen";
                            break;
                        case 2:
                            _score += "Thirty";
                            break;
                        case 3:
                            _score += "Forty";
                            break;
                    }
                }
            }
            return _score;
        }
    }
}

