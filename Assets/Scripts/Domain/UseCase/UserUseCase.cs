using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;

namespace Domain.UseCase
{
    public class UserUseCase
    {
        private IBoardRenderer _boardRenderer;
        private IKeepRenderer _keepRenderer;
        private INextMinosRenderer _nextMinosRenderer;
        private ITrashRenderer _trashRenderer;
        
        private CurrentMino _currentMino;
        private NextMinoHandler _nextMinoHandler;
        
        private Board _board;
        private Keep _keep;
        private Trash _trash;

        public void TryTrash()
        {
            if (_trash.CanTrash())
            {
                _trash.TrashMino();
                _trashRenderer.UpdateTrashRemain(_trash.Remain());
                _currentMino.Set(_nextMinoHandler.Pop());
                _boardRenderer.Render(_board, _currentMino.Get());
            }
        }
    }
}