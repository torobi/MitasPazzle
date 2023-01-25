using Domain.Model.Minos;

namespace Domain.IPresenter
{
    public interface INextMinosRenderer
    {
        public void Render(Mino[] nextMinos);
    }
}