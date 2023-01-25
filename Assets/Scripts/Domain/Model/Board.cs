using UnityEngine;

namespace Domain.Model
{
    public class Board
    {
        public static readonly int WIDTH = 13;
        public static readonly int ATTIC_HEIGHT = 3;
        public static readonly int ROOM_HEIGHT = 12;
        public static readonly int HEIGHT = ATTIC_HEIGHT + ROOM_HEIGHT;
        private State[,] _board = new State[HEIGHT,WIDTH]; // 0=空白, 1=ブロック, 2=不可マス

        public enum State
        {
            Blank,
            Block,
            Trap
        }

        public void InitState()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    _board[i,j] = State.Blank;
                }
                if (i%2==1) break;
            
                var trapNum = Random.Range(0, WIDTH);
                _board[i, trapNum] = State.Trap;
            }
        }
    
        public State[,] board => CopyBoard();
        public State[,] OutputBoard => CopyRoomBoard();
    
        public void PutMino(Minos.Mino mino)
        {
            var blocks = mino.CalcBlocks();
            foreach (var b in blocks)
            {
                if ((b.y < 0 || b.y >= HEIGHT) || (b.x < 0 || b.x >= WIDTH))
                {
                    Debug.LogError("盤外にミノを設置できない\n"+blocks.ToString());
                    return;
                }

                this._board[b.y, b.x] = State.Block;
            }
        }

        private State[,] CopyBoard()
        {
            var copy = new State[HEIGHT, WIDTH];
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    copy[i, j] = _board[i, j];
                }
            }

            return copy;
        }

        private State[,] CopyRoomBoard()
        {
            var copy = new State[ROOM_HEIGHT, WIDTH];
            for (int i = 0; i < ROOM_HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    copy[i, j] = _board[i + ATTIC_HEIGHT, j];
                }
            }

            return copy;
        }

        public bool CanPut(Minos.Mino mino)
        {
            var blocks = mino.CalcBlocks();
            foreach (var b in blocks)
            {
                if ((b.y < 0 || b.y >= HEIGHT) || (b.x < 0 || b.x >= WIDTH)) return false;
                if (_board[b.y, b.x] == State.Block) return false;
            }

            return true;
        }

        public bool IsOnTrap(Minos.Mino mino)
        {
            var blocks = mino.CalcBlocks();
            foreach (var b in blocks)
            {
                if ((b.y < 0 || b.y >= HEIGHT) || (b.x < 0 || b.x >= WIDTH))
                {
                    Debug.LogError("盤外にミノを設置できない\n"+blocks.ToString());
                    return false;
                }
                if (_board[b.y, b.x] == State.Trap) return true;
            }

            return false;
        }
    }
}
