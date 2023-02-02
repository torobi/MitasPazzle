using Domain.Model;
using Domain.Model.Minos;

namespace Domain.IPresenter
{
    public interface IBoardRenderer
    {
        void Render(Board board, Mino currentMino);
        void RenderGameOverBoard(Board board, Mino currentMino);
    }
}