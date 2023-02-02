using System.Linq;
using Util.Array;

namespace Domain.Service.Mino
{
    public class NextMinoHandler
    {
        private readonly MinoFactory _factory;
        private readonly Model.Minos.Mino[] _nextMinos;
        private int _index = 0;
        private readonly int _variationNum;

        public NextMinoHandler(MinoFactory factory)
        {
            _factory = factory;
            _variationNum = _factory.MinoNum();
            _nextMinos = GetInitialNextMinos();
        }

        public Model.Minos.Mino Pop()
        {
            var poppedMino = _nextMinos[_index].Clone();
            _index++;

            if (_index >= _variationNum)
            {
                Reload();
            }
            
            return poppedMino;
        }

        public Model.Minos.Mino[] GetNextMinos()
        {
            var minos = new Model.Minos.Mino[_variationNum];
            for (var i = 0; i < _variationNum; i++)
            {
                minos[i] = _nextMinos[i + _index].Clone();
            }

            return minos;
        }

        private void Reload()
        {
            // 後半を前半に移動
            for (int i = 0; i < _variationNum; i++)
            {
                _nextMinos[i] = _nextMinos[i + _variationNum].Clone();
            }
            
            // 後半に新規ミノを追加
            var addedMinos = _factory.GetAllMinos();
            addedMinos.Shuffle();
            for (int i = 0; i < _variationNum; i++)
            {
                _nextMinos[i+_variationNum] = addedMinos[i].Clone();
            }

            _index = 0;
        }

        private Model.Minos.Mino[] GetInitialNextMinos()
        {
            var next1 = _factory.GetAllMinos();
            next1.Shuffle();
            var next2 = _factory.GetAllMinos();
            next2.Shuffle();
            
            return next1.Concat(next2).ToArray();
        }
    }
}