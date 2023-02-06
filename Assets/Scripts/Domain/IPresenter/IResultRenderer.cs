namespace Domain.IPresenter
{
    public interface IResultRenderer
    {
        public void RenderGameClear(int score);
        public void RenderGameOver();
    }
}