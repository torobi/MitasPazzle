#nullable enable
namespace Domain.Model
{
    public class Keep
    {
        private Minos.Mino? _keptMino;
        private bool _canKeep = true;

        public void UnlockKeep()
        {
            this._canKeep = true;
        }
        public void SetKeepMino(Minos.Mino mino)
        {
            this._canKeep = false;
            this._keptMino = mino;
        }

        public Minos.Mino? PopKeptMino()
        {
            this._canKeep = false;
            if (_keptMino == null) return null;
            
            var mino = _keptMino.Clone();
            _keptMino = null;
            return mino;
        }
    }
}