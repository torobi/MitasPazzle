using Domain.IPresenter;
using Domain.Model;
using Domain.Service;
using Domain.Service.Mino;
using UnityEngine;

namespace Domain.UseCase
{
    public class GameUseCase
    {
        private IMainLoopHandler _loopHandler;
        
        private IBoardRenderer _boardRenderer;
        private INextMinosRenderer _nextMinosRenderer;
        private IKeepRenderer _keepRenderer;
        private ITrashRenderer _trashRenderer;
        private IResultRenderer _resultRenderer;

        private ScoreCalculator _scoreCalculator;
        private CurrentMino _currentMino;
        private NextMinoHandler _nextMinoHandler;
        
        private Board _board;
        private Keep _keep;
        private Trash _trash;
        
        public GameUseCase(
            IMainLoopHandler loopHandler,
            IBoardRenderer boardRenderer,
            INextMinosRenderer nextMinosRenderer,
            IKeepRenderer keepRenderer,
            ITrashRenderer trashRenderer,
            IResultRenderer resultRenderer,
            ScoreCalculator scoreCalculator,
            CurrentMino currentMino,
            NextMinoHandler nextMinoHandler,
            Board board,
            Keep keep,
            Trash trash
        )
        {
            _loopHandler = loopHandler;
            _boardRenderer = boardRenderer;
            _nextMinosRenderer = nextMinosRenderer;
            _keepRenderer = keepRenderer;
            _trashRenderer = trashRenderer;
            _resultRenderer = resultRenderer;
            _scoreCalculator = scoreCalculator;
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

        /**
         * これ以上下がれない場合ミノを設置、currentMinoを更新、TrashとKeepをRefresh
         * 設置した場合trueを返す
         */
        public bool PutMinoIfNeeded()
        {
            // 落下可能なら設置しない
            if (_currentMino.CanDrop(_board)) return false;

            if (_board.IsOnTrap(_currentMino.Get()))
            {
                GameOver();
                return true;
            }

            if (_board.IsOnAttic(_currentMino.Get()))
            {
                GameClear();
                return true;
            }
            
            _board.PutMino(_currentMino.Get());
            var nextMino = _nextMinoHandler.Pop();
            _currentMino.Set(nextMino);
            
            _nextMinosRenderer.Render(_nextMinoHandler.GetNextMinos());
            _boardRenderer.Render(_board, _currentMino.Get());
            
            RefreshTrash();
            RefreshKeep();

            return true;
        }

        private void GameOver()
        {
            Debug.Log("game over.");
            _loopHandler.Pause();
            _board.PutMino(_currentMino.Get());
            _resultRenderer.RenderGameOver();
        }

        private void GameClear()
        {
            Debug.Log("game clear!");
            _loopHandler.Pause();
            _board.PutMino(_currentMino.Get());
            _resultRenderer.RenderGameClear(_scoreCalculator.Calc(_board));
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