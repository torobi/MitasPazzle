namespace Domain.Service.Mino
{
    public class CurrentMino
    {
        private Model.Minos.Mino _currentMino;

        public void Set(Model.Minos.Mino mino)
        {
            this._currentMino = mino;
        }

        public Model.Minos.Mino Get()
        {
            return this._currentMino;
        }

        public Model.Minos.Mino Swap(Model.Minos.Mino mino)
        {
            var beforeMino = _currentMino;
            _currentMino = mino;
            return beforeMino;
        }
    }
}