namespace Domain.Model.Mino
{
    public class T_Mino : Mino
    {
        public T_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(1, 0), new Block(0, 1), new Block(1, 1), new Block(2, 1) }, x, y, rotate)
        {}

        public override Mino Clone()
        {
            return new T_Mino(this._x, this._y, this._rotate);
        }
    }
}