using CodeBase.UI.HUD;
using Zenject;

namespace CodeBase.Services.EnergyService
{
    public class EnergyService : IEnergyService, IInitializable
    {
        // TODO: вынести в конфиг и инициализировать
        private readonly int _maxValue;
        private int _currentValue;

        private readonly IHUDRoot _hudRoot;

        public EnergyService(IHUDRoot hudRoot)
        {
            _hudRoot = hudRoot;
            _maxValue = 1000;
        }

        public void Initialize()
        {
            _currentValue = _maxValue;
            
            _hudRoot.ChangeVariableByType(HUDElementType.MaxEnergy, _maxValue);
            _hudRoot.ChangeVariableByType(HUDElementType.CurrentlyEnergy, _currentValue);
        }
        
        public bool TryReduceEnergy(int valueReduction)
        {
            if (_currentValue == 0)
            {
                return false;
            }

            _currentValue -= valueReduction;

            if (_currentValue < 0)
            {
                _currentValue = 0;
            }
            
            _hudRoot.ChangeVariableByType(HUDElementType.CurrentlyEnergy, _currentValue);

            return true;
        }
    }
}