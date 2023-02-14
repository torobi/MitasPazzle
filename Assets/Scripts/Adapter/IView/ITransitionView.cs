using Domain.ITransition;

namespace Adapter.IView
{
    public interface ITransitionView
    {
        public void GoTo(Destination destination);
    }
}