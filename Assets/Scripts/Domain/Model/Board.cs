using System.Linq;
using UnityEngine;

namespace Domain.Model
{
    public class Board
    {
        public const int DEFAULT_ROOM_HEIGHT = 12;
        public const int DEFAULT_ATTIC_HEIGHT = 3;
        public const int DEFAULT_HEIGHT = DEFAULT_ROOM_HEIGHT + DEFAULT_ATTIC_HEIGHT;
        public const int DEFAULT_WIDTH = 13;
        
        public readonly int WIDTH;
        public readonly int ATTIC_HEIGHT;
        public readonly int ROOM_HEIGHT;
        public readonly int HEIGHT;
        private State[,] _board; // 0=空白, 1=ブロック, 2=不可マス

        public enum State
        {
            Blank,
            Block,
            Trap,
            BlockOnTrap
        }

        public Board(int width = DEFAULT_WIDTH, int roomHeight = DEFAULT_ROOM_HEIGHT, int atticHeight = DEFAULT_ATTIC_HEIGHT)
        {
            WIDTH = width;
            ROOM_HEIGHT = roomHeight;
            ATTIC_HEIGHT = atticHeight;
            HEIGHT = roomHeight + atticHeight;
            _board = new State[HEIGHT,WIDTH]; 
            
            InitState();
        }

        public void InitState()
        {
            for (int i = ATTIC_HEIGHT; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    _board[i,j] = State.Blank;
                }
            }
            
            CreateTraps();
        }

        private void CreateTraps()
        {
            for (int i = 0; i < WIDTH; i++)
            {
                var trapNum = Random.Range(ATTIC_HEIGHT, HEIGHT);
                _board[trapNum, i] = State.Trap;
            }
        }
    
        public State[,] board => CopyBoard();

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

        public bool IsOnAttic(Minos.Mino mino)
        {
            var blocks = mino.CalcBlocks();
            return blocks.Any(b => b.y < ATTIC_HEIGHT);
        }

        public void ClearState()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    _board[i,j] = State.Blank;
                }
            }
        }
    }
}
