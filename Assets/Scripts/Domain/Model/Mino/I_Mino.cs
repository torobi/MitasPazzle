namespace Domain.Model.Mino
{
    public class I_Mino : Mino
    {
        public I_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(0, 1), new Block(1, 1), new Block(2, 1) }, x, y, rotate)
        {}

        public override Mino Clone()
        {
            return new I_Mino(this._x, this._y, this._rotate);
        }
    }
}