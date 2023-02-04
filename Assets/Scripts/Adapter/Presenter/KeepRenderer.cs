#nullable enable
using Adapter.IView;
using Domain.IPresenter;
using Domain.Model.Minos;

namespace Adapter.Presenter
{
    public class KeepRenderer : IKeepRenderer
    {
        private IKeepView _keepView;

        KeepRenderer(IKeepView keepView)
        {
            _keepView = keepView;
        }
        
        public void Render(Mino? keepMino)
        {
            if (keepMino == null)
            {
                _keepView.SetBlank();
            }
            else
            {
                _keepView.SetMino(keepMino);
            }
        }
    }
}