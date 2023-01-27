using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;
using Domain.Model.Minos;

namespace Adapter.Presenter
{
    public class BoardRenderer: IBoardRenderer
    {
        private IBoardView _boardView;

        public void Render(Board board, Mino currentMino)
        {
            var state = MergeBoardAndCurrentMino(board, currentMino);
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
            var state = board.OutputBoard;
            var blocks = currentMino.CalcBlocks();
            foreach (var block in blocks)
            {
                state[block.y, block.x] = Board.State.Block;
            }

            return state;
        }
    }
}