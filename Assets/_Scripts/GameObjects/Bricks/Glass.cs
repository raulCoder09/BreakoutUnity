using _Scripts;
using _Scripts.Controllers;
using Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace GameObjects.Bricks
{
    public class Glass : MonoBehaviour
    {
        protected int _resistance;
        internal int Resistance
        {
            get=>_resistance;
            set=>_resistance=value;
        }
        private UnityEvent _increaseScore;
        protected  int BlockPoints;
        private GameObject _gameManagerObject;
        private GameManager _gameManager;
        protected static int _factorMode=1;
        internal static int FactorMode
        {
            get=>_factorMode;
            set=>_factorMode=value;
        }

        protected string _previousMode;

        private void Awake()
        {
            _gameManagerObject = GameObject.Find("GameManager");
            if (_gameManagerObject==null)
            {
                Debug.Log($"error find object {_gameManagerObject.name}");
            }
            else
            {
                _gameManager = _gameManagerObject.GetComponent<GameManager>();
            }
            
        }

        private void Start()
        {
            Initialization();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                ReboundBall(collision);
            }
        }
    
        private void Update()
        {
            CheckAndHandleBlock();
            UpdateDifficulty();
        }

        private void ReboundBall(Collision collision)
        {
            var direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            collision.rigidbody.linearVelocity = Ball.SpeedBall * direction;
            _resistance--;
        }

        private void CheckAndHandleBlock()
        {
            if (_resistance <= 0)
            {
                ScoreData.CurrentScoreData[UiController.LevelNumber-1] += BlockPoints;
                _gameManager.BricksOnLevel--;
                Destroy(gameObject);
            }
        }

        protected virtual void Initialization()
        {
            Difficulty();
            _resistance = 1*_factorMode;
            BlockPoints = 1;
            _gameManager.BricksOnLevel++;
        }
        
        protected void Difficulty()
        {
            switch (GameManager.Mode)
            {
                case "Easy":
                    _factorMode = 1;
                    break;
                case "Normal":
                    _factorMode = 2;
                    break;
                case "Hard":
                    _factorMode = 3;
                    break;
                default:
                    break;
            }
        }
        
        protected virtual void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 1 * _factorMode;
            _previousMode = GameManager.Mode;
        }

    }
}
