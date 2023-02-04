using Adapter.IView;
using Domain.IPresenter;
using Domain.Model.Minos;

namespace Adapter.Presenter
{
    public class NextMinosRenderer: INextMinosRenderer
    {
        private INextMinosView _nextMinosView;

        NextMinosRenderer(INextMinosView nextMinosView)
        {
            _nextMinosView = nextMinosView;
        }
        
        public void Render(Mino[] nextMinos)
        {
            _nextMinosView.UpdateMinos(nextMinos);
        }
    }
}