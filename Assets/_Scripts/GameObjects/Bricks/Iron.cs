namespace GameObjects.Bricks
{
    public class Iron : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 7* _factorMode;
            BlockPoints = 7;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 7 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
