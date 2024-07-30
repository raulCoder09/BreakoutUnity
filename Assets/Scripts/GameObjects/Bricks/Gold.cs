namespace GameObjects.Bricks
{
    public class Gold : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 6* _factorMode;;
            BlockPoints = 6;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 6 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
