using Cysharp.Threading.Tasks;
using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;
using UnityEngine;
using Zenject;

namespace Domain.UseCase
{
    public class RuleGameOverUseCase
    {
        private IBoardRenderer _boardRenderer;

        private CurrentMino _currentMino;
        private NextMinoHandler _nextMinoHandler;

        private Board _board;

        private bool _isSkip = false;

        RuleGameOverUseCase(
            IBoardRenderer boardRenderer,
            [Inject(Id = "gameOver")] CurrentMino currentMino,
            NextMinoHandler nextMinoHandler,
            Board board
        )
        {
            _boardRenderer = boardRenderer;
            _currentMino = currentMino;
            _nextMinoHandler = nextMinoHandler;
            _board = board;
        }

        public void Drop()
        {
            if (_isSkip) return;
            _currentMino.TryDrop(_board);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
        
        public bool PutMinoIfNeeded()
        {
            if (_isSkip) return true;
            if (_currentMino.CanDrop(_board)) return false;
            
            if (_board.IsOnTrap(_currentMino.Get()))
            {
                GameOver().Forget();
                return true;
            }
                        
            _board.PutMino(_currentMino.Get());
            var nextMino = _nextMinoHandler.Pop();
            _currentMino.Set(nextMino);
            
            _boardRenderer.Render(_board, _currentMino.Get());

            return true;
        }

        private async UniTaskVoid GameOver()
        {
            _isSkip = true;
            await UniTask.Delay(1250);
            _isSkip = false;
            Reset();
        }

        private void Reset()
        {
            _board = new Board(_board.WIDTH, _board.ROOM_HEIGHT, _board.ATTIC_HEIGHT);
            _board.ClearState();
            _board.ChangeState(2, _board.HEIGHT-1, Board.State.Trap);
            var mino = _nextMinoHandler.Pop();
            _currentMino.Set(mino);
            _boardRenderer.Render(_board, _currentMino.Get());
        }
        
    }
}