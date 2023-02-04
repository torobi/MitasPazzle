using Domain.Model.Minos;

namespace Adapter.IView
{
    public interface INextMinosView
    {
        public void UpdateMinos(Mino[] minos);
    }
}