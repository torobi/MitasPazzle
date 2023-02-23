using Domain.UseCase;

namespace Adapter.Controller
{
    public class MainButtonController
    {
        private GameUseCase _useCase;
        
        public MainButtonController(GameUseCase useCase)
        {
            _useCase = useCase;
        }

        public void ClickBackTitleButton()
        {
            _useCase.BackToTitle();
        }
    }
}