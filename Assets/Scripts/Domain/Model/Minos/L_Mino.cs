namespace Domain.Model.Mino
{
    public class L_Mino : Minos.Mino
    {
        public L_Mino(int x, int y, int rotate = 0): 
            base( new[] { new Block(1, 0), new Block(-1, 1), new Block(0, 1), new Block(1, 1) }, x, y, rotate)
        {}

        public override Minos.Mino Clone()
        {
            return new L_Mino(this._x, this._y, this._rotate);
        }
    }
}