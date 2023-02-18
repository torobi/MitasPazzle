using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;

namespace Adapter.Presenter
{
    public class RulePageRenderer : IRulePageRenderer
    {
        private IPageDotView _pageDotView;
        // private IPageMoveArrowView _pageMoveArrowView;

        RulePageRenderer(IPageDotView pageDotView, IPageMoveArrowView pageMoveArrowView)
        {
            _pageDotView = pageDotView;
            // _pageMoveArrowView = pageMoveArrowView;
        }
        
        public void UpdatePage(RuleBook ruleBook)
        {
            _pageDotView.UpdateLight(ruleBook.currentPage);
            // _pageMoveArrowView.UpdateLight(ruleBook);
        }
    }
}