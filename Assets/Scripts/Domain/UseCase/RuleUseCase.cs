using Domain.IPresenter;
using Domain.ITransition;
using Domain.Model;

namespace Domain.UseCase
{
    public class RuleUseCase
    {
        private ITransitionHandler _transitionHandler;
        private RuleBook _ruleBook;
        private IRulePageRenderer _rulePageRenderer;

        RuleUseCase(ITransitionHandler transitionHandler, RuleBook ruleBook, IRulePageRenderer rulePageRenderer)
        {
            _transitionHandler = transitionHandler;
            _ruleBook = ruleBook;
            _rulePageRenderer = rulePageRenderer;
        }

        public void BackToTitle()
        {
            _transitionHandler.GoTo(Destination.TitleScene);
        }

        public void TryGoToNextPage()
        {
            if (_ruleBook.CanOpenNextPage())
            {
                _ruleBook.OpenNextPage();
                _rulePageRenderer.UpdatePage(_ruleBook);
            }
        }

        public void TryGoToPrevPage()
        {
            if (_ruleBook.CanOpenPrevPage())
            {
                _ruleBook.OpenPrevPage();
                _rulePageRenderer.UpdatePage(_ruleBook);
            }
        }

        public void TryGoToPage(int pageNum)
        {
            if (_ruleBook.CanOpen(pageNum))
            {
                _ruleBook.OpenPage(pageNum);
                _rulePageRenderer.UpdatePage(_ruleBook);
            }
        }
    }
}