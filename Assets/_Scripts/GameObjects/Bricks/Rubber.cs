using _Scripts;

namespace GameObjects.Bricks
{
    public class Rubber : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 9* _factorMode;
            BlockPoints = 9;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 9 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
