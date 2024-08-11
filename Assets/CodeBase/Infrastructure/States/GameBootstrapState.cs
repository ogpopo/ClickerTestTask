using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ILogService _log;
        private readonly LoadingCurtainProxy _loadingCurtainProxy;
        private readonly IAssetProvider _assetProvider;

        public GameBootstrapState(GameStateMachine gameStateMachine,
            IAssetProvider assetProvider,
            ILogService log,
            LoadingCurtainProxy loadingCurtainProxy)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _log = log;
            _loadingCurtainProxy = loadingCurtainProxy;
        }

        public async UniTask Enter()
        {
            _log.Log("BootstrapState Enter");

            await InitServices();

            _gameStateMachine.Enter<GameplayState>().Forget();
        }

        private async UniTask InitServices()
        {
            // init global services that may need initialization in some order here
            await _assetProvider.InitializeAsync();
            await _loadingCurtainProxy.InitializeAsync();
        }

        public UniTask Exit() =>
            default;
    }
}