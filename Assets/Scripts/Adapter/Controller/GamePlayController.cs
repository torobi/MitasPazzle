using Domain.UseCase;
using UnityEngine;

namespace Adapter.Controller
{
    public class GamePlayController
    {
        private GameUseCase _useCase;

        public GamePlayController(GameUseCase useCase)
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