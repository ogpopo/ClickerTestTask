using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.ClickProvider;
using CodeBase.Services.CurrencyAccountService;
using CodeBase.Services.EnergyService;
using CodeBase.UI.HUD;
using Cysharp.Threading.Tasks;
using Zenject;

namespace CodeBase.Gameplay
{
    public class ServicesInstaller : Installer<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<string, UniTask<HUDRoot>, HUDRoot.Factory>()
                .FromFactory<PrefabFactoryAsync<HUDRoot>>();
            
            Container.BindInterfacesAndSelfTo<HUDProxy>().AsSingle();
            
            Container.BindInterfacesTo<EnergyService>().AsSingle();
            Container.BindInterfacesTo<CurrencyAccountService>().AsSingle();
            Container.BindInterfacesTo<ClickProvider>().AsSingle();
        }
    }
}