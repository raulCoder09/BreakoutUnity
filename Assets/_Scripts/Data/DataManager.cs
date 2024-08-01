using System.IO;
using UnityEngine;

namespace _Scripts.Data
{
    internal class DataManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        private string _filePath;

        private void Awake( )
        {
            _filePath = Path.Combine(Application.persistentDataPath,"gamedata.json");
        }

        internal void SaveGameData( )
        {
            GameDataSerializable data = new GameDataSerializable(gameData);
            string jsonData = JsonUtility.ToJson(data,true);
            File.WriteAllText(_filePath,jsonData);
            Debug.Log("Game data saved to " + _filePath);
        }

        internal void LoadGameData( )
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                GameDataSerializable data = JsonUtility.FromJson<GameDataSerializable>(jsonData);

                gameData.HighScoreData = data.highScoreData;
                gameData.CurrentScoreData = data.currentScoreData;
                gameData.FinalScore = data.finalScore;
                gameData.Speed = data.speed;
                gameData.Difficulty = data.difficulty;

                Debug.Log($"Game data loaded from {_filePath}") ;
            }
            else
            {
                Debug.LogWarning($"No save file found at {_filePath}");
            }
        }
    }
}

