using Adapter.IView;
using Domain.IPresenter;

namespace Adapter.Presenter
{
    public class MainLoopHandler : IMainLoopHandler
    {
        private IMainLoopView _mainLoopView;
        private bool _isPaused = false;

        MainLoopHandler(IMainLoopView mainLoopView)
        {
            _mainLoopView = mainLoopView;
        }
        
        public void Pause()
        {
            _isPaused = true;
            _mainLoopView.Pause();
        }

        public void Resume()
        {
            _isPaused = false;
            _mainLoopView.Resume();
        }

        public void ResetTiming()
        {
            _isPaused = false;
            _mainLoopView.ResetTiming();
        }

        public bool IsPaused()
        {
            return _isPaused;
        }
    }
}