namespace Domain.Model.Mino
{
    public class Z_Mino : Mino
    {
        public Z_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(0, 0), new Block(1, 0), new Block(1, 1), new Block(2, 1) }, x, y, rotate)
        {}

        public override Mino Clone()
        {
            return new Z_Mino(this._x, this._y, this._rotate);
        }
    }
}