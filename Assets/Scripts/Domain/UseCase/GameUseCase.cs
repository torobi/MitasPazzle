using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;

namespace Domain.UseCase
{
    public class GameUseCase
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
        
        public GameUseCase(
            IBoardRenderer boardRenderer,
            // IKeepRenderer keepRenderer,
            // INextMinosRenderer nextMinosRenderer,
            // ITrashRenderer trashRenderer,
            CurrentMino currentMino,
            NextMinoHandler nextMinoHandler,
            Board board,
            Keep keep,
            Trash trash
        )
        {
            _boardRenderer = boardRenderer;
            // _keepRenderer = keepRenderer;
            // _nextMinosRenderer = nextMinosRenderer;
            // _trashRenderer = trashRenderer;
            _currentMino = currentMino;
            _nextMinoHandler = nextMinoHandler;
            _board = board;
            _keep = keep;
            _trash = trash;
        }
        
        public void Drop()
        {
            _currentMino.TryDrop(_board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }

        public void PutMinoIfNeeded()
        {
            var mino = _currentMino.Get();
            mino.Drop();
            if (_board.CanPut(mino)) return;

            var nextMino = _nextMinoHandler.Pop();
            _board.PutMino(_currentMino.Get());
            _currentMino.Set(nextMino);
            
            _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos(null));
            _boardRenderer.Render(_board, _currentMino.Get());
            
            RefreshTrash();
            RefreshKeep();
        }

        private void RefreshTrash()
        {
            _trash.ReduceRemain();
            _trashRenderer.UpdateTrashRemain(_trash.Remain());
        }

        private void RefreshKeep()
        {
            _keep.UnlockKeep();
        }
    }
}