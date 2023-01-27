using Domain.Model;

namespace Adapter.IView
{
    public interface IBoardView
    {
        public void SetStateAt(int x, int y, Board.State state);
    }
}