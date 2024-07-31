using _Scripts;
using UnityEngine;

namespace Ui.GameOver
{
    public class GameOver : MonoBehaviour
    {
        internal static int TotalScore()
        {
            var totalScore = 0;
            for (var i = 0; i < 5; i++)
            {
                totalScore +=ScoreData.CurrentScoreData[i];
            }
            return totalScore;
        }
    }
}
