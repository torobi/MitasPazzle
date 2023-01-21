using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;
using Domain.Service.Mino;

namespace Domain.UseCase
{
    public class UserUseCase
    {
        private IBoardRenderer _boardRenderer;
        private IKeepRenderer _keepRenderer;
        private INextMinosRenderer _nextMinosRenderer;
        private ITrashRenderer _trashRenderer;
        
        private CurrentMino _currentMino;
        private NextMinoHandler _nextMinoHandler;
        
        private Board _board;
        private Keep _keep;
        private Trash _trash;

        public void TryTrash()
        {
            if (_trash.CanTrash())
            {
                _trash.TrashMino();
                _trashRenderer.UpdateTrashRemain(_trash.Remain());
                _currentMino.Set(_nextMinoHandler.Pop());
                _boardRenderer.Render(_board, _currentMino.Get());
            }
        }

        public void TryKeep()
        {
            if (_keep.CanKeep())
            {
                if (_keep.AlreadyKept())
                {
                    var beforeCurrentMino = _currentMino.Swap(_keep.PopKeptMino()); 
                    _keep.SetKeepMino(beforeCurrentMino);
                    _boardRenderer.Render(_board, _currentMino.Get());
                }
                else
                {
                    _keep.SetKeepMino(_currentMino.Get());
                    _currentMino.Set(_nextMinoHandler.Pop());
                    _boardRenderer.Render(_board, _currentMino.Get());
                }
            }
        }
        
        public void HardDrop()
        {
            _currentMino.TryHardDrop(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
        public void TryMoveRight()
        {
            _currentMino.TryMoveRight(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
        public void TryMoveLeft()
        {
            _currentMino.TryMoveLeft(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }

        public void TryDrop()
        {
            _currentMino.TryDrop(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
    }
}