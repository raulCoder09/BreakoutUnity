namespace GameObjects.Bricks
{
    public class Silver : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 10* _factorMode;
            BlockPoints = 10;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 10 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
