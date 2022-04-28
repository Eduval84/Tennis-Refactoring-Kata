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

            EqualScoreHandle();
            GeneralScoreHandle();
            GeneralScoreHandlePointLess4();
            AdvantageScore();
            DeterminesWinningPlayer();
            return _score;
        }

        private void DeterminesWinningPlayer()
        {
            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                _score = "Win for player1";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                _score = "Win for player2";
            }
        }

        private void AdvantageScore()
        {
            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                _score = "Advantage player1";
            }
            else if (_p2Point > _p1Point && _p1Point >= 3)
            {
                _score = "Advantage player2";
            }
        }

        private void GeneralScoreHandlePointLess4()
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
                _score = _p1Res + "-" + _p2Res;
            }

            if (_p2Point <= _p1Point || _p2Point >= 4) return;

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
            _score = _p1Res + "-" + _p2Res;
        }

        private void GeneralScoreHandle()
        {
            if (_p1Point <= 0 && _p2Point <= 0) return;

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
                _score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point != 0) return;

            _p2Res = _p2Point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => _p2Res
            };

            _p1Res = "Love";
            _score = _p1Res + "-" + _p2Res;
        }

        private void EqualScoreHandle()
        {
            if (!EqualPlayerPoints()) return;
            if (_p1Point < 3)
            {
                _score = _p1Point switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => _score
                };
                _score += "-All";
            }
            else
                _score = "Deuce";
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

