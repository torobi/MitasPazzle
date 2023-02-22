using Domain.UseCase;
using UnityEngine;

namespace Adapter.Controller
{
    public class ClearRuleController : IDropController
    {
        private RuleGameClearUseCase _useCase;

        public ClearRuleController(RuleGameClearUseCase useCase)
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