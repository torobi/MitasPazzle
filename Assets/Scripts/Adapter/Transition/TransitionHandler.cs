using Adapter.IView;
using Domain.ITransition;

namespace Adapter.Transition
{
    public class TransitionHandler : ITransitionHandler
    {
        private ITransitionView _transitionView;

        TransitionHandler(ITransitionView transitionView)
        {
            _transitionView = transitionView;
        }
        
        public void GoTo(Destination destination)
        {
            _transitionView.GoTo(destination);
        }
    }
}