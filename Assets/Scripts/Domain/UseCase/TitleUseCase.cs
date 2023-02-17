using Domain.ITransition;

namespace Domain.UseCase
{
    public class TitleUseCase
    {
        private ITransitionHandler _transitionHandler;

        TitleUseCase(ITransitionHandler transitionHandler)
        {
            _transitionHandler = transitionHandler;
        }

        public void GoToRule()
        {
            _transitionHandler.GoTo(Destination.RuleScene);
        }

        public void Play()
        {
            _transitionHandler.GoTo(Destination.MainScene);
        }
    }
}