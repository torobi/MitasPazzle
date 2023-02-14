using Adapter.IView;
using Adapter.Transition;
using Domain.ITransition;
using UnityEngine;
using Zenject;

public class TransitionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITransitionView>().To<TransitionView>().FromResource("TransitionView").AsSingle();
        Container.Bind<ITransitionHandler>().To<TransitionHandler>().AsSingle();
    }
}