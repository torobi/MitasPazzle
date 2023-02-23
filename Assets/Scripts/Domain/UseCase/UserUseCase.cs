using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;
using Domain.Service.Mino;
using UnityEngine;
using Zenject;

namespace Domain.UseCase
{
    public class UserUseCase
    {
        private IMainLoopHandler _loopHandler;
        private IBoardRenderer _boardRenderer;
        private IKeepRenderer _keepRenderer;
        private INextMinosRenderer _nextMinosRenderer;
        private ITrashRenderer _trashRenderer;
        
        private CurrentMino _currentMino;
        private NextMinoHandler _nextMinoHandler;
        
        private Board _board;
        private Keep _keep;
        private Trash _trash;
        
        public UserUseCase(
            IMainLoopHandler loopHandler,
            IBoardRenderer boardRenderer,
            IKeepRenderer keepRenderer,
            INextMinosRenderer nextMinosRenderer,
            ITrashRenderer trashRenderer,
            CurrentMino currentMino,
            NextMinoHandler nextMinoHandler,
            Board board,
            Keep keep,
            Trash trash
            )
        {
            _loopHandler = loopHandler;
            _boardRenderer = boardRenderer;
            _keepRenderer = keepRenderer;
            _nextMinosRenderer = nextMinosRenderer;
            _trashRenderer = trashRenderer;
            _currentMino = currentMino;
            _nextMinoHandler = nextMinoHandler;
            _board = board;
            _keep = keep;
            _trash = trash;
        }
        
        public void TryTrash()
        {
            if (_loopHandler.IsPaused()) return;
            if (_trash.CanTrash())
            {
                _trash.TrashMino();
                _trashRenderer.UpdateTrashRemain(_trash.Remain());
                _currentMino.Set(_nextMinoHandler.Pop());
                _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos());
                _boardRenderer.Render(_board, _currentMino.Get());
                _loopHandler.ResetTiming();
            }
        }

        public void TryKeep()
        {
            if (_loopHandler.IsPaused()) return;
            if (_keep.CanKeep())
            {
                if (_keep.AlreadyKept())
                {
                    var beforeCurrentMino = _currentMino.Swap(_keep.PopKeptMino());
                    _keep.SetKeepMino(beforeCurrentMino);
                    _keepRenderer.Render(_keep.GetKeptMino());
                    _boardRenderer.Render(_board, _currentMino.Get());
                }
                else
                {
                    _keep.SetKeepMino(_currentMino.Get());
                    _keepRenderer.Render(_keep.GetKeptMino());
                    _currentMino.Set(_nextMinoHandler.Pop());
                    _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos());
                    _boardRenderer.Render(_board, _currentMino.Get());
                }
                _loopHandler.ResetTiming();
            }
        }
        
        public void HardDrop()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryHardDrop(this._board);
            _board.PutMino(_currentMino.Get());
            _currentMino.Set(_nextMinoHandler.Pop());
            _boardRenderer.Render(_board, _currentMino.Get());
            _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos());
            _trash.ReduceRemain();
            _trashRenderer.UpdateTrashRemain(_trash.Remain());
            _keep.UnlockKeep();
            _loopHandler.ResetTiming();
        }
        
        public void TryMoveRight()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryMoveRight(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
        public void TryMoveLeft()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryMoveLeft(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }

        public void TryTurnRight()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryTurnRight(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
        public void TryTurnLeft()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryTurnLeft(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }

        public void TryDrop()
        {
            if (_loopHandler.IsPaused()) return;
            _currentMino.TryDrop(this._board);
            _boardRenderer.Render(_board, _currentMino.Get());
            _loopHandler.ResetTiming();
        }
    }
}