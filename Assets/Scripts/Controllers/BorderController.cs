using UnityEngine;

namespace Controllers
{
    public class BorderController : MonoBehaviour
    {
       [Header("Editor Settings")] 
         private float radio=1.0f;

        private bool _isHoldOnScreen=false;
        [Header("Dynamic settings")] 
        private bool _isOnScreen=true;

        private float widhtCamera;
        private float heigtCamera;
        private bool _isOutputLeft, _isOutputRight, _isOutputUp, _isOutputDown;

        internal bool IsOutputLeft { get=>_isOutputLeft; set=>_isOutputLeft=value; }
        internal bool IsOutputRight { get=>_isOutputRight; set=>_isOutputRight=value; }
        internal bool IsOutputUp { get=>_isOutputUp; set=>_isOutputUp=value; }
        internal bool IsOutputDown { get=>_isOutputDown; set=>_isOutputDown=value; }

        private void Awake()
        {
                heigtCamera = Camera.main!.orthographicSize;
                widhtCamera = Camera.main.aspect * heigtCamera;
        }

        private void LateUpdate()
        {
                var position = transform.position;
                _isOnScreen = true;
                _isOutputLeft= _isOutputRight= _isOutputUp= _isOutputDown=false;
                if (position.x>widhtCamera-radio)
                {
                        position.x = widhtCamera - radio;
                        _isOutputRight = true;
                }

                if (position.x< -widhtCamera-radio)
                {
                        position.x = -widhtCamera - radio;
                        _isOutputLeft = true;
                }

                if (position.y>heigtCamera-radio)
                {
                        position.y = heigtCamera - radio;
                        _isOutputUp = true;
                }
                if (position.y<-heigtCamera-radio)
                {
                        position.y = -heigtCamera - radio;
                        _isOutputDown = true;
                }
                _isOnScreen=!(_isOutputLeft|| _isOutputRight|| _isOutputUp|| _isOutputDown);
                if (_isHoldOnScreen && !_isOnScreen)
                {
                        transform.position = position;
                        _isOnScreen = true;
                }
        }

        private void OnDrawGizmos()
        {
                if (!Application.isPlaying)return;
                var borderSize = new Vector3(widhtCamera * 2, heigtCamera * 2, 0.1f);
                Gizmos.DrawWireCube(Vector3.zero,borderSize);
        }
    }
}
