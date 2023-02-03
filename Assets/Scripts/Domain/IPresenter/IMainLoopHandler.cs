namespace Domain.IPresenter
{
    public interface IMainLoopHandler
    {
        bool IsPaused();
        void Pause();
        void Resume();
        void ResetTiming();
    }
}