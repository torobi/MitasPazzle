using System;

namespace Domain.Model
{
    public class Block : IEquatable<Block>
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

        public bool Equals(Block other)
        {
            if (other is null) return false;
            return (this._x, this._y) == (other.x, other.y);
        }
        
        //Object.Equalsのオーバーライド
        public override bool Equals(object obj) => Equals(obj as Block);
        //Object.GetHashCodeのオーバーライド
        public override int GetHashCode() => (_x, _y).GetHashCode();
        //演算子（==,!=）のオーバーロード
        public static bool operator ==(Block l, Block r) => l?.Equals(r) ?? (r is null);
        public static bool operator !=(Block l, Block r) => !(l == r);
    }
}
