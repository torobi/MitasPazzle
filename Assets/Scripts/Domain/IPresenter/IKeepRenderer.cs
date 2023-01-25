#nullable enable
using Domain.Model.Minos;

namespace Domain.IPresenter
{
    public interface IKeepRenderer
    {
        void Render(Mino? keepMino);
    }
}