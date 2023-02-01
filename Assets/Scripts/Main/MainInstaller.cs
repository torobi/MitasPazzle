using Adapter.Controller;
using Adapter.Presenter;
using Domain.IPresenter;
using Domain.Model;
using Domain.Service.Mino;
using Domain.UseCase;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // domain
        Container.Bind<Board>().AsSingle();
        Container.Bind<Keep>().AsSingle();
        Container.Bind<Trash>().AsSingle();
        
        // Service
        Container.Bind<CurrentMino>().AsSingle();
        Container.Bind<NextMinoHandler>().FromInstance(new NextMinoHandler(new MinoFactory())).AsSingle();
        
        // UseCase
        Container.Bind<UserUseCase>().AsSingle();
        Container.Bind<GameUseCase>().AsSingle();
        
        // Presenter
        Container.Bind<IBoardRenderer>().To<BoardRenderer>().AsSingle();
        // Container.Bind<IKeepRenderer>().To<KeepRenderer>();
        // Container.Bind<INextMinosRenderer>().To<NextMinosRenderer>();
        // Container.Bind<ITrashRenderer>().To<TrashRenderer>();

        Container.Bind<KeyboardController>().AsSingle();
    }
}