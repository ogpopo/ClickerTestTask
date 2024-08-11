using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.UI.LoadingCurtain;
using CodeBase.Services.LogService;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILogService _log;
        private readonly IAssetProvider _assetProvider;

        public GameplayState(ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader, ILogService log, IAssetProvider assetProvider)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _log = log;
            _assetProvider = assetProvider;
        }

        public async UniTask Enter()
        {
            _log.Log("Game mode state enter");
            _loadingCurtain.Show();
            await _assetProvider.WarmupAssetsByLabel(AssetLabels.GameplayState);
            await _sceneLoader.Load(InfrastructureAssetPath.GameModeScene);
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            await _assetProvider.ReleaseAssetsByLabel(AssetLabels.GameplayState);
        }
    }
}