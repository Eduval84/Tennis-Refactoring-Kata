namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = "";
        private string _p2Res = "";
        private string _score = "";

        public TennisGame2(string player1Name, string player2Name)
        {
            _p1Point = 0;
        }

        public string GetScore()
        {
            _score = "";
            _score = EqualScoreHandle(_score);

            _score = GeneralScoreHandle(_score);

            _score = GeneralScoreHandlePointLess4(_score);

            _score = AdvantageScore(_score);

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                _score = "Win for player1";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                _score = "Win for player2";
            }
            return _score;
        }

        private string AdvantageScore(string score)
        {
            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }
            else if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            return score;
        }

        private string GeneralScoreHandlePointLess4(string score)
        {
            if (_p1Point > _p2Point && _p1Point < 4)
            {
                _p1Res = _p1Point switch
                {
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };
                _p2Res = _p2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => _p2Res
                };
                score = _p1Res + "-" + _p2Res;
            }

            if (_p2Point <= _p1Point || _p2Point >= 4) return score;

            _p2Res = _p2Point switch
            {
                2 => "Thirty",
                3 => "Forty",
                _ => _p2Res
            };
            _p1Res = _p1Point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                _ => _p1Res
            };
            score = _p1Res + "-" + _p2Res;

            return score;
        }

        private string GeneralScoreHandle(string score)
        {
            if (_p1Point <= 0 && _p2Point <= 0) return score;

            if (_p2Point == 0)
            {
                _p1Res = _p1Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };
                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point != 0) return score;

            _p2Res = _p2Point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => _p2Res
            };

            _p1Res = "Love";
            score = _p1Res + "-" + _p2Res;

            return score;
        }

        private string EqualScoreHandle(string score)
        {
            if (!EqualPlayerPoints()) return score;
            if (_p1Point < 3)
            {
                score = _p1Point switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => score
                };
                score += "-All";
            }
            else
                score = "Deuce";
            return score;
        }

        private bool EqualPlayerPoints()
        {
            return _p1Point == _p2Point;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                _p1Point++;
            else
                _p2Point++;
        }

    }
}

