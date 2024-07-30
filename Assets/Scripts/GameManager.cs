using Controllers;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreData scoreData;
    
    private UIDocument _gameUIDocument;
    private VisualElement _gameRoot;
    
    private bool _youWin;
    private GameObject _bricks;

    internal GameObject Bricks
    {
        get => _bricks;
        set => _bricks = value;
    }

    private int _bricksCount;
    private static bool _isGameStarted;

    internal static bool IsGameStarted
    {
        get => _isGameStarted;
        set => _isGameStarted = value;
    }
    private byte _bricksOnLevel;

    internal byte BricksOnLevel
    {
        get=>_bricksOnLevel;
        set=> _bricksOnLevel=value;
    }
    
    private static byte _playerLives=3;

    internal static byte PlayerLives
    {
        get => _playerLives;
        set
        {
            _playerLives = value;
            if (_playerLives==0)
            {
                Destroy(GameObject.Find("GameObjects"));
                UiController.ShowLoser();
                //ToDo game time
            }
            
        }
    }
    private static bool _isInterfaceGameActive;

    internal static bool IsInterfaceGameActive
    {
        get=>_isInterfaceGameActive; 
        set=>_isInterfaceGameActive=value;
    }

    private static string _mode;

    internal static string Mode
    {
        get => _mode;
        set => _mode = value;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _gameUIDocument = FindUIDocument("Game");
        if (_gameUIDocument != null)
        {
            _gameRoot = _gameUIDocument.rootVisualElement;
        }
        var mainCamera=GameObject.Find("MainCamera");
        if (mainCamera != null)
        {
            DontDestroyOnLoad(mainCamera);
        }
        
        var directionalLight=GameObject.Find("DirectionalLight");
        if (directionalLight != null)
        {
            DontDestroyOnLoad(directionalLight);
        }
        
        var globalVolume=GameObject.Find("GlobalVolume");
        if (globalVolume != null)
        {
            DontDestroyOnLoad(globalVolume);
        }
        
        
        var ui=GameObject.Find("Ui");
        if (ui != null)
        {
            DontDestroyOnLoad(ui);
        }
        
        var controllers=GameObject.Find("Controllers");
        if (controllers != null)
        {
            DontDestroyOnLoad(controllers);
        }
    }

    private void Start()
    {
        //scores.Load();
        ScoreData.CurrentScoreData[UiController.LevelNumber-1] = 0;
        _gameRoot.Q
            <Label>("CurrentScore").text = $"Current score: {ScoreData.CurrentScoreData[UiController.LevelNumber-1]}";
        _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[UiController.LevelNumber-1]}";
    }

    private void Update()
    {
        _gameRoot.Q<Label>("CurrentScore").text = $"Current score: {ScoreData.CurrentScoreData[UiController.LevelNumber-1]}";
        _gameRoot.Q<Label>("LivesString").text = $"Lives X{_playerLives}";
        if (ScoreData.CurrentScoreData[UiController.LevelNumber-1]>ScoreData.HighScoreData[UiController.LevelNumber-1])
        {
            ScoreData.HighScoreData[UiController.LevelNumber-1] = ScoreData.CurrentScoreData[UiController.LevelNumber-1];
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[UiController.LevelNumber-1]}";
        }
        //scores.Save();
        
        if (_isInterfaceGameActive && _isGameStarted)
        {
            _bricks = GameObject.Find("Bricks");
            if (_bricks != null)
            {
                _bricksCount = _bricks.transform.childCount;
            }

            if (_bricksOnLevel==0||_bricksCount==0)
            {
                Destroy(GameObject.Find("GameObjects"));
                Destroy(GameObject.Find("Ball"));
                UiController.ShowWin();
                //ToDo game time
            }
        }
    }

    internal void RemoveLife()
    {
        var life = UiController.GameRoot.Q<VisualElement>($"Life{_playerLives}");
        if (life == null) return;
        var lifesPanel = life.parent;
        lifesPanel.Remove(life);
    }
    
    private UIDocument FindUIDocument(string nameUiDocument)
    {
        var uiDocument = GameObject.Find(nameUiDocument)?.GetComponent<UIDocument>();
        if (uiDocument==null)
        {
            Debug.Log($"Error {nameUiDocument} UI Document");
        }

        return uiDocument;
    }
    
    
}
