using _Scripts;

namespace GameObjects.Bricks
{
    public class Emerald : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 5* _factorMode;;
            BlockPoints = 5;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 5 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
