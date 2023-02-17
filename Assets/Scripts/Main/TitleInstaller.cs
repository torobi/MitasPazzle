using Adapter.Controller;
using Domain.UseCase;
using UnityEngine;
using Zenject;

public class TitleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // UseCase
        Container.Bind<TitleUseCase>().AsSingle();
        
        // Controller
        Container.Bind<TitleButtonController>().AsSingle();
    }
}