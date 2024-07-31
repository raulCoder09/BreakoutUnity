using System;
using _Scripts;
using Controllers;
using UnityEngine;

namespace GameObjects
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private int xLimit=33;
        [SerializeField] private Mode controlMode;
        private static float _speedPaddle=30f;

        internal static float SpeedPaddle
        {
            get => _speedPaddle;
            set => _speedPaddle = value;
        }
        private Vector3 _mousePosition2D;
        private Vector3 _mousePosition3D;
        

        private enum Mode
        {
            Keyboard,
            Mouse
        }
        
        private void Update()
        {
            if (!GameManager.IsInterfaceGameActive) return;
                switch (controlMode)
            {
                case Mode.Mouse:
                {
                    _mousePosition2D = Input.mousePosition;
                    if (Camera.main != null) _mousePosition2D.z = -Camera.main.transform.position.z;
                    if (Camera.main != null) _mousePosition3D = Camera.main.ScreenToWorldPoint(_mousePosition2D);
                    var currentPosition = transform.position;
                    currentPosition.x = _mousePosition3D.x;
                    if (currentPosition.x < -xLimit)
                    {
                        currentPosition.x = -xLimit;
                    }
                    else if ((currentPosition.x > xLimit))
                    {
                        currentPosition.x = xLimit;
                    }
                    transform.position = currentPosition;
                    break;
                }
                case Mode.Keyboard:
                {
                    var currentPosition = transform.position;
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        if (currentPosition.x< -xLimit)
                        {
                            currentPosition.x = -xLimit;
                        }
                        else
                        {
                            transform.Translate(Vector3.up * (_speedPaddle * Time.deltaTime));
                        }
                
                    }else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        if (currentPosition.x> xLimit)
                        {
                            currentPosition.x = xLimit;
                        }
                        else
                        {
                            transform.Translate(Vector3.down * (_speedPaddle * Time.deltaTime));
                        }
                    }

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                ReboundBall(collision);
            }
        }
    
        private void ReboundBall(Collision collision)
        {
            var direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            //collision.rigidbody.linearVelocity = collision.gameObject.GetComponent < Ball > ().SpeedBall * direction;
            collision.rigidbody.linearVelocity = Ball.SpeedBall * direction;
        }
    }
}
