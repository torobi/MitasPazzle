using Domain.UseCase;

namespace Adapter.Controller
{
    public class ResultButtonController
    {
        private ResultUseCase _resultUseCase;

        ResultButtonController(ResultUseCase resultUseCase)
        {
            _resultUseCase = resultUseCase;
        }

        public void ClickBackTitleButton()
        {
            _resultUseCase.BackToTitle();
        }

        public void ClickRetryButton()
        {
            _resultUseCase.Retry();    
        }
    }
}