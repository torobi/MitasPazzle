using Domain.Model.Minos;

namespace Adapter.IView
{
    public interface IKeepView
    {
        public void SetBlank();
        public void SetMino(Mino mino);
    }
}