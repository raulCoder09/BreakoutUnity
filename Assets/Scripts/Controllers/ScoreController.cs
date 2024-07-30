// using ScriptableObjects;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// namespace Controllers
// {
//     public class ScoreController : MonoBehaviour
//     {
//         [SerializeField] private Scores scores; 
//         private UIDocument _gameUIDocument;
//         private VisualElement _gameRoot;
//
//         private void Awake()
//         {
//             _gameUIDocument = FindUIDocument("Game");
//             if (_gameUIDocument != null)
//             {
//                 _gameRoot = _gameUIDocument.rootVisualElement;
//             }
//         }
//
//         private void Start()
//         {
//             scores.Load();
//             Scores.CurrentScore = 0;
//             _gameRoot.Q<Label>("CurrentScore").text = $"Current score: {Scores.CurrentScore}";
//             _gameRoot.Q<Label>("HighScore").text = $"High score: {Scores.HighScore}";
//         }
//
//         private void Update()
//         {
//             _gameRoot.Q<Label>("CurrentScore").text = $"Current score: {Scores.CurrentScore}";
//             if (Scores.CurrentScore>Scores.HighScore)
//             {
//                 Scores.HighScore = Scores.CurrentScore;
//                 if (_gameRoot!=null)
//                 {
//                     _gameRoot.Q<Label>("HighScore").text = $"High score: {Scores.HighScore}";
//                 }
//             }
//             scores.Save();
//         }
//         
//         private UIDocument FindUIDocument(string nameUiDocument)
//         {
//             var uiDocument = GameObject.Find(nameUiDocument)?.GetComponent<UIDocument>();
//             if (uiDocument==null)
//             {
//                 Debug.Log($"Error {nameUiDocument} UI Document");
//             }
//
//             return uiDocument;
//         }
//     }
// }
