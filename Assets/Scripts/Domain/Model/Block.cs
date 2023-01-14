namespace Domain.Model
{
    public class Block
    {
        private int _x, _y;

        public Block(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int x => _x;
        public int y => _y;

        public Block copy()
        {
            return new Block(_x, _y);
        }
    }
}
