namespace Domain.Model.Mino
{
    public class O_Mino : Mino
    {
        public O_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(0,0), new Block(1, 0), new Block(1, 0), new Block(1, 1) }, x, y, rotate)
        {}

        public override Mino Clone()
        {
            return new O_Mino(this._x, this._y, this._rotate);
        }
    }
}