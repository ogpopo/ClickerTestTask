using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using CodeBase.UI.HUD;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.States
{
    public class StartGameplayState : IState
    {
        private readonly SceneStateMachine _sceneStateMachine;
        private readonly HUDProxy _hudProxy;
        private readonly IAssetProvider _assetProvider;
        
        public StartGameplayState(SceneStateMachine sceneStateMachine, HUDProxy hudProxy, IAssetProvider assetProvider)
        {
            _sceneStateMachine = sceneStateMachine;
            _hudProxy = hudProxy;
            _assetProvider = assetProvider;
        }

        public async UniTask Enter()
        {
            await _hudProxy.InitializeAsync();
            await _assetProvider.WarmupAssetsByLabel(AssetLabels.GameplayState);
            _sceneStateMachine.Enter<PlayGameplayState>().Forget();
        }
        
        public UniTask Exit()
        {
            return default;
        }
    }
}