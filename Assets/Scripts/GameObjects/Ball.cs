using Controllers;
using UnityEngine;
using UnityEngine.Events;

namespace GameObjects
{
    public class Ball : MonoBehaviour
    { 
        private static float _speedBall = 20.0f;

        internal static float SpeedBall
        {
            get => _speedBall; 
            set => _speedBall = value;
        }
        private Vector3 _lastPosition = Vector3.zero;
        private Vector3 _direction = Vector3.zero;
        private Rigidbody _rigidbody;
        private BorderController _control;
        internal UnityEvent BallDestroyed;
        
        private GameObject _gameManagerObject;
        private GameManager _gameManager;

        private Vector3 _storedVelocity;

        private void Awake()
        {
            _control = GetComponent<BorderController>();
            _gameManagerObject = GameObject.Find("GameManager");
            if (_gameManagerObject == null)
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
            var startPosition = GameObject.FindGameObjectWithTag("Paddle").transform.position;
            startPosition.y += 3;
            transform.position = startPosition;
            transform.SetParent(GameObject.FindGameObjectWithTag("Paddle").transform);
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (GameManager.IsInterfaceGameActive)
            {
                if (_storedVelocity != Vector3.zero)
                {
                    _rigidbody.linearVelocity = _storedVelocity;
                    _storedVelocity = Vector3.zero;
                }

                if (_control.IsOutputDown)
                {
                    BallDestroyed?.Invoke();
                    ResetBall();
                    _gameManager.RemoveLife();
                    GameManager.PlayerLives--;
                }

                if (_control.IsOutputUp)
                {
                    _direction = transform.position - _lastPosition;
                    _direction.y *= -1;
                    _direction = _direction.normalized;
                    _rigidbody.linearVelocity = _speedBall * _direction;
                    _control.IsOutputUp = false;
                    _control.enabled = false;
                    Invoke(nameof(EnableControl), 0.5f);
                }
                if (_control.IsOutputLeft)
                {
                    _direction = transform.position - _lastPosition;
                    _direction.x *= -1;
                    _direction = _direction.normalized;
                    _rigidbody.linearVelocity = _speedBall * _direction;
                    _control.IsOutputLeft = false;
                    _control.enabled = false;
                    Invoke(nameof(EnableControl), 0.5f);
                }
                if (_control.IsOutputRight)
                {
                    _direction = transform.position - _lastPosition;
                    _direction.x *= -1;
                    _direction = _direction.normalized;
                    _rigidbody.linearVelocity = _speedBall * _direction;
                    _control.IsOutputRight = false;
                    _control.enabled = false;
                    Invoke(nameof(EnableControl), 0.5f);
                }

                LaunchBall();
            }
            else
            {
                if (_storedVelocity != Vector3.zero) return;
                _storedVelocity = _rigidbody.linearVelocity;
                _rigidbody.linearVelocity = Vector3.zero;
            }
        }
        
        private void EnableControl()
        {
            _control.enabled = true;
        }

        private void FixedUpdate()
        {
            _lastPosition = transform.position;
        }

        private void LateUpdate()
        {
            if (_direction != Vector3.zero) _direction = Vector3.zero;
        }

        internal void LaunchBall()
        {
            if (!Input.GetKey(KeyCode.Space)) return;
            if (GameManager.IsGameStarted) return;
            GameManager.IsGameStarted = true;
            transform.SetParent(null);
            _rigidbody.linearVelocity = _speedBall * Vector3.up;
        }

        internal void ResetBall()
        {
            _rigidbody.linearVelocity = Vector3.zero;
            var paddle = GameObject.Find("Paddle").transform;
            transform.SetParent(paddle);
            var ballPosition = paddle.position;
            ballPosition.y += 3;
            transform.position = ballPosition;
            GameManager.IsGameStarted = false;
        }
    }
}
