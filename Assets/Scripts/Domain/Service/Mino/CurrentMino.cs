using Domain.Model;
using Domain.Model.Mino;

namespace Domain.Service.Mino
{
    public class CurrentMino
    {
        private Model.Minos.Mino _currentMino = new T_Mino(5, 0);

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
            var beforeMino = _currentMino.Clone();
            _currentMino = mino;
            return beforeMino;
        }

        public void TryHardDrop(Board board)
        {
            while (TryDrop(board))
            {
                
            }
        }
        public bool TryDrop(Board board)
        {
            var mino = this._currentMino.Clone();
            mino.Drop();
            return TryUpdate(board, mino);
        }
        public bool TryTurnLeft(Board board)
        {
            var mino = this._currentMino.Clone();
            mino.TurnLeft();
            return TryUpdate(board, mino);
        }
        
        public bool TryTurnRight(Board board)
        {
            var mino = this._currentMino.Clone();
            mino.TurnRight();
            return TryUpdate(board, mino);
        }

        public bool TryMoveLeft(Board board)
        {
            var mino = this._currentMino.Clone();
            mino.MoveLeft();
            return TryUpdate(board, mino);
        }
        
        public bool TryMoveRight(Board board)
        {
            var mino = this._currentMino.Clone();
            mino.MoveRight();
            return TryUpdate(board, mino);
        }

        private bool TryUpdate(Board board, Model.Minos.Mino mino)
        {
            if (!board.CanPut(mino)) return false;
            this._currentMino = mino;
            return true;
        }
    }
}