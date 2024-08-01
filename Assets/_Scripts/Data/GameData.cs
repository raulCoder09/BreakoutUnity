using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "GameData",menuName = "ScriptableObjects/GameData",order = 1)]
    public class GameData : ScriptableObject
    {
        [SerializeField]
        private List<int> highScoreData = new List<int>(5){0,0,0,0,0};
        internal List<int> HighScoreData
        {
            get => highScoreData;
            set => highScoreData = value;
        }
        [SerializeField]
        private List<int> currentScoreData = new List<int>(5){0,0,0,0,0};
        internal List<int> CurrentScoreData
        {
            get => currentScoreData;
            set => currentScoreData = value;
        }
        [SerializeField]
        private int finalScore;
        internal int FinalScore {
            get => finalScore;
            set => finalScore = value;
        }
        [SerializeField]
        private float speed=26.0f;
        internal float Speed{
            get => speed;
            set => speed = value;
        }
        [SerializeField]
        private string difficulty= "Easy";

        internal string Difficulty {
            get => difficulty; 
            set => difficulty = value; 
        }
    }
}
