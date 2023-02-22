using Domain.UseCase;

namespace Adapter.Controller
{
    public class GameOverRuleController : IDropController
    {
        private RuleGameOverUseCase _useCase;

        public GameOverRuleController(RuleGameOverUseCase useCase)
        {
            _useCase = useCase;
        }

        public void Drop()
        {
            var putted = _useCase.PutMinoIfNeeded();
            if (!putted)
            {
                _useCase.Drop();
            }
        }
    }
}