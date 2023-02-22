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
    [SerializeField] private BoardView gameClearRuleBoardView;
    [SerializeField] private BoardView gameOverRuleBoardView;
    
    public override void InstallBindings()
    {
        var clearBoard = new Board(5, 5, 2);
        clearBoard.ClearState();
        var clearCurrentMino = new CurrentMino();
        var gameOverBoard = new Board(5, 5, 0);
        var gameOverCurrentMino = new CurrentMino();
        
        // Domain
        Container.Bind<RuleBook>().AsSingle();
        Container.Bind<Board>().FromInstance(clearBoard).WhenInjectedInto<RuleGameClearUseCase>();
        Container.Bind<NextMinoHandler>().FromInstance(new NextMinoHandler(new MinoFactory(clearBoard.WIDTH/2, 0))).AsSingle();
        
        // Service
        Container.Bind<CurrentMino>().WithId("gameClear").FromInstance(clearCurrentMino);
        // Container.Bind<CurrentMino>().WithId("gameOver").FromInstance(gameOverCurrentMino).WhenInjectedInto<RuleGameOverUseCase>();
        
        // UseCase
        Container.Bind<RuleUseCase>().AsSingle();
        Container.Bind<RuleGameClearUseCase>().AsSingle();
        
        // Presenter
        Container.Bind<IMainLoopHandler>().To<MainLoopHandler>().AsSingle();
        Container.Bind<IBoardRenderer>().To<ClearRuleBoardRenderer>().AsSingle().WhenInjectedInto<RuleGameClearUseCase>();
        Container.Bind<IRulePageRenderer>().To<RulePageRenderer>().AsSingle();
        
        // Controller
        Container.Bind<RuleButtonController>().AsSingle();
        Container.Bind<IDropController>().To<ClearRuleController>().AsSingle();
    }
}