namespace Domain.Model.Mino
{
    public class V_Mino : Mino
    {
        public V_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(1, 0), new Block(0, 1), new Block(1, 1) }, x, y, rotate)
        {}

        public override Mino Clone()
        {
            return new V_Mino(this._x, this._y, this._rotate);
        }
    }
}