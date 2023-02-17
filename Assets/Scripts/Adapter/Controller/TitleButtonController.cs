using Domain.UseCase;

namespace Adapter.Controller
{
    public class TitleButtonController
    {
        private TitleUseCase _titleUseCase;

        TitleButtonController(TitleUseCase titleUseCase)
        {
            _titleUseCase = titleUseCase;
        }

        public void ClickRuleButton()
        {
            _titleUseCase.GoToRule();
        }

        public void ClickPlayButton()
        {
            _titleUseCase.Play();    
        }
    }
}