using Adapter.IView;
using Domain.IPresenter;
using Domain.Model;

namespace Adapter.Presenter
{
    public class RulePageRenderer : IRulePageRenderer
    {
        private IPageDotView _pageDotView;
        private IPageContainerView _pageContainerView;
        // private IPageMoveArrowView _pageMoveArrowView;

        RulePageRenderer(IPageDotView pageDotView, IPageContainerView pageContainerView)
        {
            _pageDotView = pageDotView;
            _pageContainerView = pageContainerView;
            // _pageMoveArrowView = pageMoveArrowView;
        }
        
        public void UpdatePage(RuleBook ruleBook)
        {
            _pageDotView.UpdateLight(ruleBook.currentPage);
            _pageContainerView.PageSwitch(ruleBook.currentPage);
            // _pageMoveArrowView.UpdateLight(ruleBook);
        }
    }
}