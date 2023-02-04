using Adapter.IView;
using Domain.IPresenter;

namespace Adapter.Presenter
{
    public class TrashRenderer : ITrashRenderer
    {
        private ITrashView _trashView;

        TrashRenderer(ITrashView trashView)
        {
            _trashView = trashView;
        }
        
        public void UpdateTrashRemain(int remain)
        {
            _trashView.UpdateTrashRemain(remain);
        }
    }
}