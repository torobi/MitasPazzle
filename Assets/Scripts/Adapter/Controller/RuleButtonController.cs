using Domain.UseCase;

namespace Adapter.Controller
{
    public class RuleButtonController
    {
        private RuleUseCase _ruleUseCase;

        RuleButtonController(RuleUseCase ruleUseCase)
        {
            _ruleUseCase = ruleUseCase;
        }

        public void ClickBackTitleButton()
        {
            _ruleUseCase.BackToTitle();
        }

        public void ClickRightArrowButton()
        {
            _ruleUseCase.TryGoToNextPage();
        }

        public void ClickLeftArrowButton()
        {
            _ruleUseCase.TryGoToPrevPage();
        }

        public void ClickPageDotButton(int pageNum)
        {
            _ruleUseCase.TryGoToPage(pageNum);
        }
    }
}