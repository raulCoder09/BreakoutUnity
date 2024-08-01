using _Scripts;
using System.IO;
using UnityEngine;

namespace Assets._Scripts
{
    internal class DataManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        private string filePath;

        private void Awake( )
        {
            filePath = Path.Combine(Application.persistentDataPath,"gamedata.json");
        }

        internal void SaveGameData( )
        {
            GameDataSerializable data = new GameDataSerializable(gameData);
            string jsonData = JsonUtility.ToJson(data,true);
            File.WriteAllText(filePath,jsonData);
            Debug.Log("Game data saved to " + filePath);
        }

        internal void LoadGameData( )
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                GameDataSerializable data = JsonUtility.FromJson<GameDataSerializable>(jsonData);

                gameData.HighScoreData = data.highScoreData;
                gameData.CurrentScoreData = data.currentScoreData;
                gameData.FinalScore = data.finalScore;
                gameData.Speed = data.speed;
                gameData.Difficulty = data.difficulty;

                Debug.Log("Game data loaded from " + filePath);
            }
            else
            {
                Debug.LogWarning("No save file found at " + filePath);
            }
        }
    }
}

