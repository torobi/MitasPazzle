using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;
using UnityEngine;
using Zenject;

namespace Adapter.Presenter
{
    public class ClearRuleBoardRenderer : IBoardRenderer
    {
        private IBoardView _boardView;

        ClearRuleBoardRenderer([Inject(Id = "gameClear")]IBoardView boardView)
        {
            _boardView = boardView;
        }
        
        public void Render(Board board, Mino currentMino)
        {
            const float ATTIC_BLOCK_ALPHA = 0.5f;

            var state = MergeBoardAndCurrentMino(board, currentMino);
            for (var y = 0; y < board.ATTIC_HEIGHT ; y++)
            {
                for (var x = 0; x < board.WIDTH; x++)
                {
                    if (state[y, x] == Board.State.Block)
                    {
                        _boardView.SetStateAt(x, y, state[y, x]);
                        _boardView.SetAlphaAt(x, y, ATTIC_BLOCK_ALPHA);
                    }
                    else
                    {
                        _boardView.SetAlphaAt(x, y, 0);
                    }
                }
            }
            for (var y = board.ATTIC_HEIGHT; y < board.HEIGHT; y++)
            {
                for (var x = 0; x < board.WIDTH; x++)
                {
                    _boardView.SetStateAt(x, y, state[y, x]);
                }
            }

        }

        public void RenderGameOverBoard(Board board, Mino currentMino)
        {
            throw new System.NotImplementedException();
        }

        private Board.State[,] MergeBoardAndCurrentMino(Board board, Mino currentMino)
        {
            var state = board.board;
            var blocks = currentMino.CalcBlocks();
            foreach (var block in blocks)
            {
                if ((block.y < 0 || block.y >= board.HEIGHT) || (block.x < 0 || block.x >= board.WIDTH)) continue;
                if (state[block.y, block.x] == Board.State.Trap)
                {
                    state[block.y, block.x] = Board.State.BlockOnTrap;
                }
                else
                {
                    state[block.y, block.x] = Board.State.Block;
                }
            }

            return state;
        }
    }
}