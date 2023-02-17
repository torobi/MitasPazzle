using Adapter.Controller;
using Domain.UseCase;
using UnityEngine;
using Zenject;

public class RuleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // UseCase
        Container.Bind<RuleUseCase>().AsSingle();
        
        // Controller
        Container.Bind<RuleButtonController>().AsSingle();
    }
}