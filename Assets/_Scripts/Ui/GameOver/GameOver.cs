using _Scripts;
using UnityEngine;

namespace Ui.GameOver
{
    public class GameOver : MonoBehaviour
    {
        internal static int TotalScore(GameData gameData)
        {
            var totalScore = 0;
            for (var i = 0; i < 5; i++)
            {
                totalScore += gameData.HighScoreData[i];
            }
            return totalScore;
        }
    }
}
