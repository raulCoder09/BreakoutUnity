using _Scripts.Controllers;
using Assets._Scripts;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace _Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private DataManager dataManager;
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
            set => _playerLives = value;
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
        internal static void UpdatePlayerLives(byte lives, GameData gameData)
        {
            _playerLives = lives;
            if (_playerLives == 0)
            {
                Destroy(GameObject.Find("GameObjects"));
                UiController.ShowLoser(gameData);
                //ToDo game time
            }
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
            //loadData
            for (var i = 0 ; i < 5 ; i++)
            {
                _gameRoot.Q<Label>("HighScore").text = $"High score: {gameData.HighScoreData[UiController.LevelNumber-1]}";
            }
            gameData.CurrentScoreData[UiController.LevelNumber-1] = 0;
            _gameRoot.Q<Label>("CurrentScore").text = $"Current score: {gameData.CurrentScoreData[UiController.LevelNumber-1]}";
        }

        private void Update( )
        {
            var levelIndex = UiController.LevelNumber - 1;
            _gameRoot.Q<Label>("CurrentScore").text = $"Current score: {gameData.CurrentScoreData[levelIndex]}";
            _gameRoot.Q<Label>("LivesString").text = $"Lives X{_playerLives}";

            if (gameData.CurrentScoreData[levelIndex] > gameData.HighScoreData[levelIndex])
            {
                gameData.HighScoreData[levelIndex] = gameData.CurrentScoreData[levelIndex];
                _gameRoot.Q<Label>("HighScore").text = $"High score: {gameData.HighScoreData[levelIndex]}";
            }
            if (_isInterfaceGameActive && _isGameStarted)
            {
                _bricks = GameObject.Find("Bricks");
                if (_bricks != null)
                {
                    _bricksCount = _bricks.transform.childCount;
                }

                if (_bricksOnLevel == 0 || _bricksCount == 0)
                {
                    Destroy(GameObject.Find("GameObjects"));
                    Destroy(GameObject.Find("Ball"));
                    UiController.ShowWin(gameData);
                    // ToDo: guardar el tiempo de juego
                }
            }
        }

        internal void RemoveLife()
        {
            var life = UiController.GameRoot.Q<VisualElement>($"Life{_playerLives}");
            if (life == null) return;
            var livesPanel = life.parent;
            livesPanel.Remove(life);
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


}
