using Adapter.IView;
using Domain.IPresenter;

namespace Adapter.Presenter
{
    public class ResultRenderer : IResultRenderer
    {
        private IResultView _resultView;

        ResultRenderer(IResultView resultView)
        {
            _resultView = resultView;
        }
        
        public void RenderGameClear(int score)
        {
            _resultView.ShowGameClear(score);
        }

        public void RenderGameOver()
        {
            _resultView.ShowGameOver();
        }
    }
}