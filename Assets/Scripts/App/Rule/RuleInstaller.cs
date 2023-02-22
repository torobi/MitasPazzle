using Adapter.Controller;
using Adapter.IView;
using Adapter.Presenter;
using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;
using Domain.UseCase;
using UnityEngine;
using Zenject;

public class RuleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var clearBoard = new Board(5, 5, 2);
        clearBoard.ClearState();
        var clearCurrentMino = new CurrentMino();
        var gameOverBoard = new Board(5, 5, 2);
        gameOverBoard.ClearState();
        gameOverBoard.ChangeState(2, gameOverBoard.HEIGHT-1, Board.State.Trap);
        var gameOverCurrentMino = new CurrentMino();
        
        // Domain
        Container.Bind<RuleBook>().AsSingle();
        Container.Bind<Board>().FromInstance(clearBoard).WhenInjectedInto<RuleGameClearUseCase>();
        Container.Bind<Board>().FromInstance(gameOverBoard).WhenInjectedInto<RuleGameOverUseCase>();
        Container.Bind<NextMinoHandler>().FromInstance(new NextMinoHandler(new MinoFactory(clearBoard.WIDTH/2, 0))).AsSingle();
        
        // Service
        Container.Bind<CurrentMino>().WithId("gameClear").FromInstance(clearCurrentMino);
        Container.Bind<CurrentMino>().WithId("gameOver").FromInstance(gameOverCurrentMino);
        
        // UseCase
        Container.Bind<RuleUseCase>().AsSingle();
        Container.Bind<RuleGameClearUseCase>().AsSingle();
        Container.Bind<RuleGameOverUseCase>().AsSingle();
        
        // Presenter
        Container.Bind<IMainLoopHandler>().To<MainLoopHandler>().AsSingle();
        Container.Bind<IBoardRenderer>().To<ClearRuleBoardRenderer>().AsSingle().WhenInjectedInto<RuleGameClearUseCase>();
        Container.Bind<IBoardRenderer>().To<GameOverRuleBoardRenderer>().AsSingle()
            .WhenInjectedInto<RuleGameOverUseCase>();
        Container.Bind<IRulePageRenderer>().To<RulePageRenderer>().AsSingle();
        
        // Controller
        Container.Bind<RuleButtonController>().AsSingle();
        // IDropControllerはListで取得
        Container.Bind<IDropController>().To<ClearRuleController>().AsSingle();
        Container.Bind<IDropController>().To<GameOverRuleController>().AsSingle();
    }
}