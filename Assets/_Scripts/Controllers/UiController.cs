using GameObjects;
using Ui.GameOver;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.Controllers
{
    public class UiController : MonoBehaviour
    {
        private static UIDocument _gameUIDocument;
        private static VisualElement _gameRoot;
        public static VisualElement GameRoot 
        { 
            get=>_gameRoot; 
            set=>_gameRoot=value;
        }
        
        private static UIDocument _gameOverUIDocument;
        private static VisualElement _gameOverRoot;
        
        private static UIDocument _pauseAndMenuUIDocument;
        private static VisualElement _pauseAndMenuRoot;
        
        private static UIDocument _welcomeUIDocument;
        private static VisualElement _welcomeRoot;
        
        private static UIDocument _winnerUIDocument;
        private static VisualElement _winnerRoot;
        
        private static UIDocument _loserUIDocument;
        private static VisualElement _loserRoot;
        private static bool _loserUiActive;

        internal static bool LoserUiActive
        {
            get => _loserUiActive;
            set => _loserUiActive = value;
        }
        
        private static UIDocument _optionsUIDocument;
        private static VisualElement _optionsRoot;
        
        private static UIDocument _levelsUIDocument;
        private static VisualElement _levelsRoot;

        private static int _levelNumber=1;

        internal static int LevelNumber
        {
            get => _levelNumber;
            set => _levelNumber = value;
        }
        
        


        private void Awake()
        {
            _gameUIDocument = FindUIDocument("Game");
            if (_gameUIDocument!=null)
            {
                _gameRoot = _gameUIDocument.rootVisualElement;
            }
            
            _gameOverUIDocument = FindUIDocument("GameOver");
            if (_gameOverUIDocument!=null)
            {
                _gameOverRoot = _gameOverUIDocument.rootVisualElement;
            }
            
            _pauseAndMenuUIDocument = FindUIDocument("PauseAndMenu");
            if (_pauseAndMenuUIDocument!=null)
            {
                _pauseAndMenuRoot = _pauseAndMenuUIDocument.rootVisualElement;
            }
            
            _welcomeUIDocument = FindUIDocument("Welcome");
            if (_welcomeUIDocument!=null)
            {
                _welcomeRoot = _welcomeUIDocument.rootVisualElement;
            }
            
            _winnerUIDocument = FindUIDocument("Winner");
            if (_winnerUIDocument!=null)
            {
                _winnerRoot = _winnerUIDocument.rootVisualElement;
            }
            
            _loserUIDocument = FindUIDocument("Loser");
            if (_loserUIDocument!=null)
            {
                _loserRoot = _loserUIDocument.rootVisualElement;
            }
            
            _optionsUIDocument = FindUIDocument("Options");
            if (_optionsUIDocument!=null)
            {
                _optionsRoot = _optionsUIDocument.rootVisualElement;
            }
            
            _levelsUIDocument = FindUIDocument("Levels");
            if (_levelsUIDocument!=null)
            {
                _levelsRoot = _levelsUIDocument.rootVisualElement;
            }
        }
        
        private void OnEnable()
        {
            ConfigureUIElements();
        }
        
        private void Start()
        {
            HideAllScreens();
            _welcomeRoot.style.display = DisplayStyle.Flex;
            
            if (PlayerPrefs.HasKey("ModeGame"))
            {
                GameManager.Mode = PlayerPrefs.GetString("ModeGame");
                _optionsRoot.Q<DropdownField>("Mode").value= PlayerPrefs.GetString("ModeGame");
            }
            else
            {
                GameManager.Mode = "Easy";
                _optionsRoot.Q<DropdownField>("Mode").value = GameManager.Mode;
            }
            if (PlayerPrefs.HasKey("SpeedBall"))
            {
                _optionsRoot.Q<Slider>("Speed").value = PlayerPrefs.GetFloat("SpeedBall");
                Ball.SpeedBall = PlayerPrefs.GetFloat("SpeedBall");
            }
            else
            {
                Ball.SpeedBall = 26.0f;
            }
        }
        
        private static void HideAllScreens()
        {
            _loserUiActive = false;
            GameManager.IsInterfaceGameActive = false;
            if (_welcomeRoot != null)
            {
                _welcomeRoot.style.display = DisplayStyle.None;
            }
            if (_gameRoot != null)
            {
                _gameRoot.style.display = DisplayStyle.None;
            }
            if (_gameOverRoot != null)
            {
                _gameOverRoot.style.display = DisplayStyle.None;
            }
            
            if (_pauseAndMenuRoot != null)
            {
                _pauseAndMenuRoot.style.display = DisplayStyle.None;
            }
               
            if (_winnerRoot != null)
            {
                _winnerRoot.style.display = DisplayStyle.None;
            }
            if (_loserRoot != null)
            {
                _loserRoot.style.display = DisplayStyle.None;
            }
            if (_optionsRoot != null)
            {
                _optionsRoot.style.display = DisplayStyle.None;
            }  
            if (_levelsRoot != null)
            {
                _levelsRoot.style.display = DisplayStyle.None;
            }  
        }

        private void ConfigureUIElements()
        {
            if (_gameRoot != null)
            {
                var buttonMenu = _gameRoot.Q<Button>("ButtonMenu");
                if (buttonMenu!=null)
                {
                    buttonMenu.clicked += ShowPauseAndMenu;
                }
            }

            if (_gameOverRoot!=null)
            {
                var buttonPlayAgain = _gameOverRoot.Q<Button>("PlayAgain");
                if (buttonPlayAgain!=null)
                {
                    buttonPlayAgain.clicked += PlayAgain;
                }
                
                var buttonLevelsMenu = _gameOverRoot.Q<Button>("LevelsMenu");
                if (buttonLevelsMenu!=null)
                {
                    buttonLevelsMenu.clicked += ShowLevelsMenu;
                }

                var buttonExit = _gameOverRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }
            
            if (_pauseAndMenuRoot!=null)
            {
                var buttonResume = _pauseAndMenuRoot.Q<Button>("Resume");
                if (buttonResume!=null)
                {
                    buttonResume.clicked += ShowInterfaceGame;
                }
                var buttonLevelsMenu = _pauseAndMenuRoot.Q<Button>("LevelsMenu");
                if (buttonLevelsMenu!=null)
                {
                    buttonLevelsMenu.clicked += ShowLevelsMenu;
                }

                var buttonOptions = _pauseAndMenuRoot.Q<Button>("Options");
                if (buttonOptions!=null)
                {
                    buttonOptions.clicked += ShowOptions;
                }

                var buttonExit = _pauseAndMenuRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }

            if (_welcomeRoot!=null)
            {
                var buttonLaunch = _welcomeRoot.Q<Button>("Launch");
                if (buttonLaunch!=null)
                {
                    buttonLaunch.clicked += ShowLevelsMenu;
                }

                var buttonExit = _welcomeRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }
            if (_winnerRoot != null)
            {
                var buttonNextLevel = _winnerRoot.Q<Button>("NextLevel");
                if (buttonNextLevel != null)
                {
                    buttonNextLevel.clicked += GoToNextLevel;
                }
                
                
                var buttonLevelsMenu = _winnerRoot.Q<Button>("LevelsMenu");
                if (buttonLevelsMenu!=null)
                {
                    buttonLevelsMenu.clicked += ShowLevelsMenu;
                }

                var buttonExit = _winnerRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }

            if (_loserRoot!=null)
            {
                var buttonTryAgain = _loserRoot.Q<Button>("TryAgain");
                if (buttonTryAgain!=null)
                {
                    buttonTryAgain.clicked += TryAgain;
                }

                var buttonExit = _loserRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }

            if (_optionsRoot!=null)
            {
                var buttonBack = _optionsRoot.Q<Button>("Back");
                if (buttonBack!=null)
                {
                    buttonBack.clicked += ShowLevelsMenu;
                }
                
                var dropDownMode  = _optionsRoot.Q<DropdownField>("Mode");
                if (dropDownMode!=null)
                {
                    dropDownMode.RegisterValueChangedCallback(evt =>
                    {
                        ChangeMode(evt.newValue);
                    });
                }

                var sliderSpeed = _optionsRoot.Q<Slider>("Speed");
                if (sliderSpeed!=null)
                {
                    sliderSpeed.RegisterValueChangedCallback(evt =>
                    {
                        ChangeSpeed(evt.newValue);
                    });
                }
            }
            if (_levelsRoot!=null)
            {
                var buttonLevel1 = _levelsRoot.Q<Button>("Level1");
                if (buttonLevel1!=null)
                {
                    buttonLevel1.clicked += ShowLevel1;
                }
                
                var buttonLevel2 = _levelsRoot.Q<Button>("Level2");
                if (buttonLevel2!=null)
                {
                    buttonLevel2.clicked += ShowLevel2;
                }
                
                var buttonLevel3 = _levelsRoot.Q<Button>("Level3");
                if (buttonLevel3!=null)
                {
                    buttonLevel3.clicked += ShowLevel3;
                }
                
                var buttonLevel4 = _levelsRoot.Q<Button>("Level4");
                if (buttonLevel4!=null)
                {
                    buttonLevel4.clicked += ShowLevel4;
                }
                
                var buttonLevel5 = _levelsRoot.Q<Button>("Level5");
                if (buttonLevel5!=null)
                {
                    buttonLevel5.clicked += ShowLevel5;
                }
                
                

                var buttonWelcome = _levelsRoot.Q<Button>("Welcome");
                if (buttonWelcome!=null)
                {
                    buttonWelcome.clicked += ShowWelcome;
                }
                var buttonOptions = _levelsRoot.Q<Button>("Options");
                if (buttonOptions!=null)
                {
                    buttonOptions.clicked += ShowOptions;
                }

                var buttonExit = _levelsRoot.Q<Button>("Exit");
                if (buttonExit!=null)
                {
                    buttonExit.clicked += QuitApplication;
                }
            }
        }
        
        internal static void ShowLoser()
        {
            HideAllScreens();
            _loserRoot.Q<Label>("Score").text = $"Your score: {ScoreData.CurrentScoreData[LevelNumber-1]}";
            _loserRoot.Q<Label>("HighScoreLevel").text = $"High score level: {LevelNumber}: {ScoreData.HighScoreData[LevelNumber-1]}";
            _loserRoot.style.display = DisplayStyle.Flex;
            _loserUiActive = true;
        }
        internal static void ShowWin()
        {
            HideAllScreens();
            if (_levelNumber<5)
            {
                _winnerRoot.Q<Label>("Score").text = $"Your score: {ScoreData.CurrentScoreData[LevelNumber-1]}";
                _winnerRoot.style.display = DisplayStyle.Flex;
                SceneManager.LoadScene($"Level{_levelNumber}");
                _levelNumber++;
                var levelButton = _levelsRoot.Q<Button>($"Level{_levelNumber}");
                levelButton.SetEnabled(true);
            }
            else
            {
                SceneManager.LoadScene($"Level{_levelNumber}");
                _gameOverRoot.style.display = DisplayStyle.Flex;
                _gameOverRoot.Q<Label>("FinalScore").text = $"Your score: {GameOver.TotalScore()}";
            }

        }

        private void ChangeSpeed(float evtNewValue)
        {
            Ball.SpeedBall = evtNewValue;
            PlayerPrefs.SetFloat("SpeedBall",Ball.SpeedBall);
        }

        private void ChangeMode(string evtNewValue)
        {
            GameManager.Mode=evtNewValue;
            PlayerPrefs.SetString("ModeGame",GameManager.Mode);
        }
        private void TryAgain()
        {
            var livesPanel = _gameRoot.Q<VisualElement>("LivesPanel");
            var life1 = _gameRoot.Q<VisualElement>("Life1");
            if (life1==null)
            {
                life1 = new VisualElement
                {
                    name = "Life1"
                };
                life1.AddToClassList("Lives");
                livesPanel.Add(life1);
            }
            var life2 = _gameRoot.Q<VisualElement>("Life2");
            if (life2==null)
            {
                life2 = new VisualElement
                {
                    name = "Life2"
                };
                life2.AddToClassList("Lives");
                livesPanel.Add(life2);
            }
            var life3 = _gameRoot.Q<VisualElement>("Life3");
            if (life3==null)
            {
                life3 = new VisualElement
                {
                    name = "Life3"
                };
                life3.AddToClassList("Lives");
                livesPanel.Add(life3);
            }


            
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName==$"Level{_levelNumber}")
            {
                SceneManager.LoadScene($"Level{_levelNumber}");
            }
            GameManager.PlayerLives = 3;
            ScoreData.CurrentScoreData[LevelNumber-1]= 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        

        private void ShowLevelsMenu()
        {
            HideAllScreens();
            _levelsRoot.style.display = DisplayStyle.Flex;
        }

        private void ShowOptions()
        {
            HideAllScreens();
            _optionsRoot.style.display = DisplayStyle.Flex;
        }
        private void ShowLevel1()
        {
            _levelNumber = 1;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level1")
            {
                SceneManager.LoadScene($"Level1");
            }
            GameManager.PlayerLives = 3;
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
            ScoreData.CurrentScoreData[LevelNumber-1] = 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        
        private void ShowLevel2()
        {
            _levelNumber = 2;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level2")
            {
                SceneManager.LoadScene($"Level2");
            }
            GameManager.PlayerLives = 3;
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
            ScoreData.CurrentScoreData[LevelNumber-1] = 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        
        private void ShowLevel3()
        {
            _levelNumber = 3;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level3")
            {
                SceneManager.LoadScene($"Level3");
            }
            GameManager.PlayerLives = 3;
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
            ScoreData.CurrentScoreData[LevelNumber-1] = 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        
        private void ShowLevel4()
        {
            _levelNumber = 4;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level4")
            {
                SceneManager.LoadScene($"Level4");
            }
            GameManager.PlayerLives = 3;
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
            ScoreData.CurrentScoreData[LevelNumber-1] = 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        
        private void ShowLevel5()
        {
            _levelNumber = 5;
            var currentScene = SceneManager.GetActiveScene();
            var sceneName = currentScene.name;
            if (sceneName!="Level5")
            {
                SceneManager.LoadScene($"Level5");
            }
            GameManager.PlayerLives = 3;
            _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
            ScoreData.CurrentScoreData[LevelNumber-1] = 0;
            ShowInterfaceGame();
            GameManager.IsGameStarted = false;
        }
        
        private void GoToNextLevel()
        {
            var livesPanel = _gameRoot.Q<VisualElement>("LivesPanel");
            var life1 = _gameRoot.Q<VisualElement>("Life1");
            if (life1==null)
            {
                life1 = new VisualElement
                {
                    name = "Life1"
                };
                life1.AddToClassList("Lives");
                livesPanel.Add(life1);
            }
            var life2 = _gameRoot.Q<VisualElement>("Life2");
            if (life2==null)
            {
                life2 = new VisualElement
                {
                    name = "Life2"
                };
                life2.AddToClassList("Lives");
                livesPanel.Add(life2);
            }
            var life3 = _gameRoot.Q<VisualElement>("Life3");
            if (life3==null)
            {
                life3 = new VisualElement
                {
                    name = "Life3"
                };
                life3.AddToClassList("Lives");
                livesPanel.Add(life3);
            }
            if (_levelNumber<=5)
            {
                GameManager.PlayerLives = 3;
                _gameRoot.Q<Label>("HighScore").text = $"High score: {ScoreData.HighScoreData[LevelNumber-1]}";
                ScoreData.CurrentScoreData[LevelNumber-1] = 0;
                HideAllScreens();
                _gameRoot.style.display = DisplayStyle.Flex;
                SceneManager.LoadScene($"Level{_levelNumber}");
                GameManager.IsInterfaceGameActive = true;
                GameManager.IsGameStarted = false;
            }
            else
            {
                Debug.Log("No more levels");
            }

        }
        private void ShowInterfaceGame()
        {
            HideAllScreens();
            _gameRoot.style.display = DisplayStyle.Flex;
            GameManager.IsInterfaceGameActive = true;
        }

        private void ShowWelcome()
        {
            HideAllScreens();
            _welcomeRoot.style.display = DisplayStyle.Flex;
        }

        private void QuitApplication()
        {
            Application.Quit();
        }

        private void PlayAgain()
        {
            ShowLevel1();
        }

        private void ShowPauseAndMenu()
        {
            HideAllScreens();
            _pauseAndMenuRoot.style.display = DisplayStyle.Flex;
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
