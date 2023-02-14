using Domain.ITransition;

namespace Domain.UseCase
{
    public class ResultUseCase
    {
        private ITransitionHandler _transitionHandler;

        ResultUseCase(ITransitionHandler transitionHandler)
        {
            _transitionHandler = transitionHandler;
        }
        
        public void BackToTitle()
        {
            _transitionHandler.GoTo(Destination.TitleScene);
        }

        public void Retry()
        {
            _transitionHandler.GoTo(Destination.MainScene);
        }
    }
}