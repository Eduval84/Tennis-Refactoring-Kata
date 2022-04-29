namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Score;
        private int _player1Score;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _playWords = { "Love", "Fifteen", "Thirty", "Forty" };
        private string _score;

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (CheckIfPlayersScoreIsLessThan4AndTheSumOfAllAreLessThan6())
            {
                _score = _playWords[_player1Score];
                return (_player1Score == _player2Score) ? _score + "-All" : _score + "-" + _playWords[_player2Score];
            }

            if (CheckIfPlayer1AndPlayer2ScoresAreEqual())
                return "Deuce";

            _score = _player1Score > _player2Score ? _player1Name : _player2Name;
            return ((_player1Score - _player2Score) * (_player1Score - _player2Score) == 1) ? "Advantage " + _score : "Win for " + _score;
        }

        private bool CheckIfPlayer1AndPlayer2ScoresAreEqual()
        {
            return _player1Score == _player2Score;
        }

        private bool CheckIfPlayersScoreIsLessThan4AndTheSumOfAllAreLessThan6()
        {
            return _player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

    }
}

