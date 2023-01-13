
public class Mino
{
    private readonly Block[] _shape; 
    private int _x, _y;
    private int _rotate;

    public Mino(Block[] shape, int x, int y, int rotate=0)
    {
        this._shape = shape;
        this._x = x;
        this._y = y;
        this._rotate = rotate;
    }

    private Block[] CopyShape()
    {
        Block[] copy = new Block[this._shape.Length];
        for (int i = 0; i < this._shape.Length; i++)
        {
            copy[i] = this._shape[i].copy();
        }

        return copy;
    }

    public void Drop()
    {
        this._y++;
    }

    public void TurnRight()
    {
        this._rotate = (this._rotate + 1) % 4;
    }

    public void TurnLeft()
    {
        this._rotate = (this._rotate - 1) % 4;
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
