namespace GameObjects.Bricks
{
    public class Platinum : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 8* _factorMode;
            BlockPoints = 8;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 8 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
