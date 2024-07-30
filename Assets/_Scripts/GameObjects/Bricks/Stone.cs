namespace GameObjects.Bricks
{
    public class Stone : Glass
    {
        protected override void Initialization()
        {
            base.Initialization();
            _resistance = 3* _factorMode;
            BlockPoints = 3;
        }
        protected override void UpdateDifficulty()
        {
            if (_previousMode == GameManager.Mode) return;
            Difficulty();
            _resistance = 3 * _factorMode;
            _previousMode = GameManager.Mode;
        }
    }
}
