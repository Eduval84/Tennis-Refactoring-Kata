namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score;
        private int player2Score;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
            {
                return EqualScoreHandle();
            }

            if (player1Score >= 4 || player2Score >= 4)
            {
                return SetAdvantageOrWinGame();
            }

            return SetGeneralPointsScore();
        }

        private string SetGeneralPointsScore()
        {
            var score = "";
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1)
                    tempScore = player1Score;
                else
                {
                    score += "-";
                    tempScore = player2Score;
                }

                score += TempScorePlayerWord(tempScore);
            }

            return score;
        }

        private static string TempScorePlayerWord(int tempScore)
        {
            switch (tempScore)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
            }

            return "";
        }

        private string SetAdvantageOrWinGame() =>
            (player1Score - player2Score) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };

        private string EqualScoreHandle() =>
            player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
    }
}

