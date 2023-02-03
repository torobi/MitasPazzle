namespace Domain.Model.Mino
{
    public class O_Mino : Minos.Mino
    {
        public O_Mino(int x, int y, int rotate = 0): 
            base(new[] { new Block(-1,0), new Block(0, 0), new Block(-1, 1), new Block(0, 1) }, x, y, rotate)
        {}

        public override void TurnRight()
        {
            this._rotate = 0;
        }

        public override void TurnLeft()
        {
            this._rotate = 0;
        }

        public override Minos.Mino Clone()
        {
            return new O_Mino(this._x, this._y, this._rotate);
        }
    }
}