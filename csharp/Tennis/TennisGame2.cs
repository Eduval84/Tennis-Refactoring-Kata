namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = "";
        private string _p2Res = "";

        public TennisGame2(string player1Name, string player2Name)
        {
            _p1Point = 0;
        }

        public string GetScore()
        {
            var score = "";
            score = EqualScoreHandle(score);

            if (_p1Point > 0 && _p2Point == 0)
            {
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > 0 && _p1Point == 0)
            {
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = "Win for player2";
            }
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

