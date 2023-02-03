namespace Domain.Model.Mino
{
    public class I_Mino : Minos.Mino
    {
        public I_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(-1, 0), new Block(0, 0), new Block(1, 0) }, x, y, rotate)
        {}

        public override Minos.Mino Clone()
        {
            return new I_Mino(this._x, this._y, this._rotate);
        }
    }
}