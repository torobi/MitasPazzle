using Adapter.Controller;
using Adapter.Presenter;
using Domain.IPresenter;
using Domain.Model;
using Domain.UseCase;
using UnityEngine;
using Zenject;

public class RuleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Domain
        Container.Bind<RuleBook>().AsSingle();
        
        // Service
        
        // UseCase
        Container.Bind<RuleUseCase>().AsSingle();
        
        // Presenter
        Container.Bind<IRulePageRenderer>().To<RulePageRenderer>().AsSingle();
        
        // Controller
        Container.Bind<RuleButtonController>().AsSingle();
    }
}