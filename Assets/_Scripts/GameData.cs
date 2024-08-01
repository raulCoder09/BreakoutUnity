using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameData",menuName = "ScriptableObjects/GameData",order = 1)]
public class GameData : ScriptableObject
{
    [SerializeField]
    private List<int> _levelsScores= new List<int>(5) { 0,1,2,3,4 };
    internal List<int> LevelsScores {
        get => _levelsScores;
        set => _levelsScores = value;
    }
    [SerializeField]
    private int _finalScore;
    internal int FinalScore {
        get => _finalScore;
        set => _finalScore = value;
    }
    [SerializeField]
    private float _speed;
    internal float Speed{
        get => _speed;
        set => _speed = value;
    }
    [SerializeField]
    private int _difficulty;

    internal int Difficulty {
        get => _difficulty; 
        set => _difficulty = value; 
    }
}
