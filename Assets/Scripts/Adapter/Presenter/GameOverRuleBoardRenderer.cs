using System.Collections.Generic;
using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;
using UnityEngine;
using Zenject;

namespace Adapter.Presenter
{
    public class GameOverRuleBoardRenderer : IBoardRenderer
    {
        private IBoardView _boardView;

        GameOverRuleBoardRenderer([Inject(Id = "gameOver")] IBoardView boardView)
        {
            _boardView = boardView;
        }

        public void RenderGameOverBoard(Board board, Mino currentMino)
        {
            Render(board, currentMino);
            var blocksOnTrap = GetBlocksOnTrap(board, currentMino);
            foreach (var block in blocksOnTrap)
            {
                _boardView.SetBlockOnTrapAt(block.x, block.y);
            }
        }

        private Block[] GetBlocksOnTrap(Board board, Mino mino)
        {
            var blocks = new List<Block>();
            foreach (var b in mino.CalcBlocks())
            {
                if (board.board[b.y,b.x] == Board.State.Trap)
                {
                    blocks.Add(b.copy());
                }
            }

            return blocks.ToArray();
        }

        public virtual void Render(Board board, Mino currentMino)
        {
            var state = TrimBoardState(board, MergeBoardAndCurrentMino(board, currentMino));
            
            for (int y = 0; y < board.ROOM_HEIGHT; y++)
            {
                for (int x = 0; x < board.WIDTH; x++)
                {
                    _boardView.SetStateAt(x, y, state[y, x]);
                }
            }
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

        private Board.State[,] TrimBoardState(Board board, Board.State[,] state)
        {
            var trimmedState = new Board.State[board.ROOM_HEIGHT, board.WIDTH];
            for (int i = 0; i < board.ROOM_HEIGHT; i++)
            {
                for (int j = 0; j < board.WIDTH; j++)
                {
                    trimmedState[i, j] = state[i + board.ATTIC_HEIGHT, j];
                }
            }

            return trimmedState;
        }
    }
}