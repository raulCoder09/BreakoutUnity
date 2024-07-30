using System;
using UnityEngine;

namespace GameObjects.Bricks
{
    public class Bronze : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 4* _factorMode;
            BlockPoints = 4;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 4 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
