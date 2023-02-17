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
    }
}