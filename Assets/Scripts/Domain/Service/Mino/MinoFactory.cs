using System.Collections.Generic;
using Domain.Model;
using Domain.Model.Mino;

namespace Domain.Service.Mino
{
    public class MinoFactory
    {
        public static readonly int START_X = Board.WIDTH/2;
        public static readonly int START_Y = 1;
        public static readonly int START_ROTATE = 0;
        private Dictionary<ShapeName, Model.Minos.Mino> _minosDict = new ();
        public enum ShapeName {
            T,
            V, 
            I, 
            L, 
            J, 
            O, 
            S, 
            Z
        }
        
        public MinoFactory()
        {
            DefMinos();
        }
        
        public Model.Minos.Mino MakeMino(ShapeName shapeName)
        {
            return this._minosDict[shapeName].Clone();
        }

        public int MinoNum()
        {
            return _minosDict.Count;
        }

        public Model.Minos.Mino[] GetAllMinos()
        {
            var minos = new Model.Minos.Mino[_minosDict.Count];
            var i = 0;
            foreach (var mino in _minosDict.Values)
            {
                minos[i] = mino.Clone();
                i++;
            }
            
            return minos;
        }

        private void DefMinos()
        {
            this._minosDict.Add(ShapeName.I, new I_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.J, new J_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.L, new L_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.O, new O_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.S, new S_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.T, new T_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.V, new V_Mino(START_X, START_Y, START_ROTATE));
            this._minosDict.Add(ShapeName.Z, new Z_Mino(START_X, START_Y, START_ROTATE));
        }
        
    }
}
