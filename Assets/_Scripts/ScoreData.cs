using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ScoreData 
    {
        [SerializeField]private static List<int> _highScoreData = new List<int>(5){0,0,0,0,0};
        internal static List<int> HighScoreData
        {
            get => _highScoreData;
            set => _highScoreData = value;
        }
        internal static void AddHighScoreData(int highScoreData)
        {
            _highScoreData.Add(highScoreData);
        }
        
        [SerializeField]private static List<int> _currentScoreData = new List<int>(5){0,0,0,0,0};
        internal static List<int> CurrentScoreData
        {
            get => _currentScoreData;
            set => _currentScoreData = value;
        }
        internal static void AddCurrentScoreData(int currentScore)
        {
            _highScoreData.Add(currentScore);
        }
    }
}
