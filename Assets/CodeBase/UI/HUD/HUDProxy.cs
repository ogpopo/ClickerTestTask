using CodeBase.Infrastructure;
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.HUD
{
    public class HUDProxy : IHUDRoot
    {
        private HUDRoot.Factory _factory;
        private IHUDRoot impl;

        public HUDProxy(HUDRoot.Factory factory) =>
            _factory = factory;

        public async UniTask InitializeAsync() => 
            impl = await _factory.Create(InfrastructureAssetPath.HUDRoot);
        
        public void ChangeVariableByType(HUDElementType changedType, int newValue)
        {
            impl.ChangeVariableByType(changedType, newValue);
        }
    }
}