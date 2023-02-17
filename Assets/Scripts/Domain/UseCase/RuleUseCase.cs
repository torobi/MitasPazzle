using Domain.ITransition;

namespace Domain.UseCase
{
    public class RuleUseCase
    {
        private ITransitionHandler _transitionHandler;

        RuleUseCase(ITransitionHandler transitionHandler)
        {
            _transitionHandler = transitionHandler;
        }

        public void BackToTitle()
        {
            _transitionHandler.GoTo(Destination.TitleScene);
        }

        public void GoToNextPage()
        {
            
        }

        public void GoToPrevPage()
        {
            
        }
    }
}