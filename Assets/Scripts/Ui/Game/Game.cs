using UnityEngine;

namespace Ui.Game
{
    public class Game : MonoBehaviour
    {
        private int _screenWidth;
        private int _screenHeight;
        
        
        void Update()
        {
             _screenWidth = Screen.width;
            _screenHeight = Screen.height;
        }
    }
}

