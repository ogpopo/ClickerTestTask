using CodeBase.Infrastructure;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.States;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindInfrastructureUI();

            BindGameStateMachine();
            
            BindLogService();

            BindAssetProvider();
        }

        private void BindAssetProvider()
        {
            Container.BindInterfacesTo<AssetProvider>().AsSingle();
        }

        private void BindLogService()
        {
            Container.BindInterfacesTo<LogService>().AsSingle();
        }

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstraper);
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
                .AsSingle();
        }

        private void BindSceneLoader() =>
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindInfrastructureUI()
        {
            BindLoadingCurtains();
        }

        private void BindLoadingCurtains()
        {
            Container.BindFactory<string, UniTask<LoadingCurtain>, LoadingCurtain.Factory>()
                .FromFactory<PrefabFactoryAsync<LoadingCurtain>>();

            Container.BindInterfacesAndSelfTo<LoadingCurtainProxy>().AsSingle();
        }

        private void BindGameStateMachine() =>
            GameStateMachineInstaller.Install(Container);
    }
}