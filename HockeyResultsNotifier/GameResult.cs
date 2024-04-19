using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyResultsNotifier
{
    public class GameResult
    {
        public string teamOne;
        public string teamTwo;

        public string teamOneScore;
        public string teamTwoScore;

        public GameResult(string team1, string team2, string teamOneScore, string teamTwoScore)
        {
            teamOne = team1;
            teamTwo = team2;
            this.teamOneScore = teamOneScore;
            this.teamTwoScore = teamTwoScore;
        }

        public override string ToString()
        {
            return $"Team1: {teamOne}\nTeam2: {teamTwo}\nscore: {teamOneScore} - {teamTwoScore}";
        }
    }
}
