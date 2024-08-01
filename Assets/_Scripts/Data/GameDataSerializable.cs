using System;
using System.Collections.Generic;

namespace _Scripts
{
    [Serializable]
    public class GameDataSerializable
    {
        public List<int> highScoreData;
        public List<int> currentScoreData;
        public int finalScore;
        public float speed;
        public string difficulty;
        public GameDataSerializable(GameData gameData)
        {
            highScoreData = new List<int>(gameData.HighScoreData);
            currentScoreData = new List<int>(gameData.CurrentScoreData);
            finalScore = gameData.FinalScore;
            speed = gameData.Speed;
            difficulty = gameData.Difficulty;
        }
    }
}
