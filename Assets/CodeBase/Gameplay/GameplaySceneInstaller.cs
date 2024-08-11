using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Start game scene installer");

            Container.BindInterfacesTo<GameplaySceneBootstraper>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();
            Container.Bind<SceneStateMachine>().AsSingle();

            ServicesInstaller.Install(Container);
        }
    }
}