
namespace Domain.Model.Minos
{
    public abstract class Mino
    {
        private readonly Block[] _shape; 
        protected int _x, _y;
        protected int _rotate;

        private readonly int _startX, _startY, _startRotate;

        protected Mino(Block[] shape, int x, int y, int rotate=0)
        {
            this._startX = x;
            this._startY = y;
            this._startRotate = rotate;
            
            this._shape = shape;
            this._x = x;
            this._y = y;
            this._rotate = rotate;
        }

        public abstract Mino Clone();

        private Block[] CopyShape()
        {
            var copy = new Block[this._shape.Length];
            for (var i = 0; i < this._shape.Length; i++)
            {
                copy[i] = this._shape[i].copy();
            }

            return copy;
        }

        public void Reset()
        {
            this._x = _startX;
            this._y = _startY;
            this._rotate = _startRotate;
        }

        public void Drop()
        {
            this._y++;
        }

        public void MoveRight()
        {
            this._x++;
        }

        public void MoveLeft()
        {
            this._x--;
        }

        public void TurnRight()
        {
            this._rotate = (this._rotate + 1) % 4;
        }

        public void TurnLeft()
        {
            this._rotate = ((this._rotate + 4) - 1 ) % 4;
        }

        public Block[] CalcBlocks()
        {
            Block[] blocks = CopyShape();
            for (int i = 0; i < this._rotate; i++)
            {
                for (int j = 0; j < blocks.Length; j++)
                {
                    blocks[j] = new Block(-(blocks[j].y), blocks[j].x);
                }
            }

            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new Block(blocks[i].x + this._x, blocks[i].y + this._y);
            }

            return blocks;
        }
    }
}
