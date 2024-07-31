using _Scripts;

namespace GameObjects.Bricks
{
    public class Wood : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 2* _factorMode;
            BlockPoints = 2;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 2 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
