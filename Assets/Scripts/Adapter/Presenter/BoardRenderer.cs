using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;
using UnityEngine;
using Zenject;

namespace Adapter.Presenter
{
    public class BoardRenderer: IBoardRenderer
    {
        [Inject]
        private IBoardView _boardView;

        public void Render(Board board, Mino currentMino)
        {
            var state = TrimBoardState(MergeBoardAndCurrentMino(board, currentMino));
            for (int y = 0; y < Board.ROOM_HEIGHT; y++)
            {
                for (int x = 0; x < Board.WIDTH; x++)
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
                if ((block.y < 0 || block.y >= Board.HEIGHT) || (block.x < 0 || block.x >= Board.WIDTH)) continue;
                state[block.y, block.x] = Board.State.Block;
            }

            return state;
        }

        private Board.State[,] TrimBoardState(Board.State[,] state)
        {
            var trimmedState = new Board.State[Board.ROOM_HEIGHT, Board.WIDTH];
            for (int i = 0; i < Board.ROOM_HEIGHT; i++)
            {
                for (int j = 0; j < Board.WIDTH; j++)
                {
                    trimmedState[i, j] = state[i + Board.ATTIC_HEIGHT, j];
                }
            }

            return trimmedState;
        }
    }
}