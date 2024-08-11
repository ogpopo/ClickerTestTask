using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.States
{
    public class PlayGameplayState: IState
    {
        private readonly IAssetProvider _assetProvider;

        public PlayGameplayState(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public UniTask Enter()
        {
            return default;
        }
        
        public async UniTask Exit()
        {
            await _assetProvider.ReleaseAssetsByLabel(AssetLabels.GameplayState);
        }
    }
}