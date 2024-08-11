using CodeBase.Services.EnergyService;
using CodeBase.UI.HUD;
using Zenject;

namespace CodeBase.Services.CurrencyAccountService
{
    public class CurrencyAccountService : ICurrencyAccountService, IInitializable
    {
        private readonly IHUDRoot _hud;
        private readonly IEnergyService _energyService;

        private int _gem;

        public CurrencyAccountService(IHUDRoot hud, IEnergyService energyService)
        {
            _hud = hud;
            _energyService = energyService;
        }

        public void Initialize()
        {
            _hud.ChangeVariableByType(HUDElementType.Gem, _gem);
        }

        public void ChangeGemValue(int value)
        {
            if (value < 0 && _gem - value < 0)
            {
                return;
            }

            bool result = _energyService.TryReduceEnergy(1);
            if (result == false)
            {
                return;
            }
            
            _gem += value;
            _hud.ChangeVariableByType(HUDElementType.Gem, _gem);
        }
    }
}